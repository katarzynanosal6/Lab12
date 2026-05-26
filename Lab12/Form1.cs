using Lab12;
using Microsoft.EntityFrameworkCore;
using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Lab12
{
    public partial class Form1 : Form
    {
        private BioInfoDbContext _dbContext;
        private AttachmentManager _attachmentManager;
        private string _pendingAttachmentPath = string.Empty;

        public Form1()
        {
            InitializeComponent();

            PodepnijPrzyciski();

            try
            {
                _dbContext = new BioInfoDbContext();
                _dbContext.Database.EnsureCreated();
                _attachmentManager = new AttachmentManager();

                RefreshSessionList();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Błąd podczas uruchamiania bazy danych: {ex.Message}", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PodepnijPrzyciski()
        {
            this.btnAddSession.Click -= btnAddSession_Click;
            this.btnAddEntry.Click -= btnAddEntry_Click;
            this.btnAddAttachment.Click -= btnAddAttachment_Click;
            this.btnExportPdf.Click -= btnExportPdf_Click;
            this.lstSessions.SelectedIndexChanged -= lstSessions_SelectedIndexChanged;

            this.btnAddSession.Click += btnAddSession_Click;
            this.btnAddEntry.Click += btnAddEntry_Click;
            this.btnAddAttachment.Click += btnAddAttachment_Click;
            this.btnExportPdf.Click += btnExportPdf_Click;
            this.lstSessions.SelectedIndexChanged += lstSessions_SelectedIndexChanged;
        }

        private void btnAddSession_Click(object? sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSessionTitle.Text))
            {
                MessageBox.Show("Podaj tytuł sesji!", "Informacja", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var newSession = new Session { Title = txtSessionTitle.Text };
            _dbContext.Sessions.Add(newSession);
            _dbContext.SaveChanges();

            txtSessionTitle.Clear();
            RefreshSessionList();
        }

        private void lstSessions_SelectedIndexChanged(object? sender, EventArgs e)
        {
            RefreshEntryList();
        }

        private void btnAddEntry_Click(object? sender, EventArgs e)
        {
            if (lstSessions.SelectedItem == null)
            {
                MessageBox.Show("Wybierz sesję z listy po lewej stronie!", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtEntryDescription.Text))
            {
                MessageBox.Show("Wpisz treść wpisu!", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (lstSessions.SelectedItem is Session selectedSession)
            {
                string finalPath = string.Empty;

                if (!string.IsNullOrEmpty(_pendingAttachmentPath))
                {
                    finalPath = _attachmentManager.SaveAttachment(_pendingAttachmentPath);
                }

                var newEntry = new Entry
                {
                    Description = txtEntryDescription.Text,
                    AttachmentPath = finalPath,
                    SessionId = selectedSession.Id
                };

                _dbContext.Entries.Add(newEntry);
                _dbContext.SaveChanges();

                txtEntryDescription.Clear();
                _pendingAttachmentPath = string.Empty;
                lblAttachmentInfo.Text = "Brak załącznika";

                RefreshEntryList();
            }
        }

        private void btnAddAttachment_Click(object? sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Pliki biologiczne i grafiki (*.fasta;*.csv;*.png)|*.fasta;*.csv;*.png|Wszystkie pliki (*.*)|*.*";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    _pendingAttachmentPath = ofd.FileName;
                    lblAttachmentInfo.Text = $"Wybrano: {Path.GetFileName(_pendingAttachmentPath)}";
                }
            }
        }

        private void btnExportPdf_Click(object? sender, EventArgs e)
        {
            if (lstSessions.SelectedItem is Session selectedSession)
            {
                var sessionWithEntries = _dbContext.Sessions
                    .Include(s => s.Entries)
                    .FirstOrDefault(s => s.Id == selectedSession.Id);

                if (sessionWithEntries != null)
                {
                    var reportGen = new ReportGenerator();
                    string defaultFileName = $"Raport_{sessionWithEntries.Title.Replace(" ", "_")}.pdf";

                    reportGen.ExportSessionToPdf(sessionWithEntries, defaultFileName);
                    MessageBox.Show($"Wygenerowano raport: {defaultFileName}\n(Znajdziesz go w folderze z aplikacją)", "Sukces", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Wybierz sesję, z której chcesz wygenerować raport PDF!", "Informacja", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void RefreshSessionList()
        {
            lstSessions.Items.Clear();
            var sessions = _dbContext.Sessions.ToList();
            foreach (var session in sessions)
            {
                lstSessions.Items.Add(session);
            }
            lstSessions.DisplayMember = "Title";
        }

        private void RefreshEntryList()
        {
            lstEntries.Items.Clear();
            if (lstSessions.SelectedItem is Session selectedSession)
            {
                var entries = _dbContext.Entries.Where(e => e.SessionId == selectedSession.Id).ToList();
                foreach (var entry in entries)
                {
                    string attachmentText = string.IsNullOrEmpty(entry.AttachmentPath) ? "" : $" [Załączono plik: {Path.GetFileName(entry.AttachmentPath)}]";
                    lstEntries.Items.Add($"- {entry.Description}{attachmentText}");
                }
            }
        }
    }
}