namespace Lab12
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            txtSessionTitle = new TextBox();
            btnAddSession = new Button();
            lstSessions = new ListBox();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            txtEntryDescription = new TextBox();
            btnAddAttachment = new Button();
            label6 = new Label();
            lblAttachmentInfo = new Label();
            btnAddEntry = new Button();
            lstEntries = new ListBox();
            label7 = new Label();
            label8 = new Label();
            btnExportPdf = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(127, 81);
            label1.Name = "label1";
            label1.Size = new Size(119, 20);
            label1.TabIndex = 0;
            label1.Text = "Tytuł nowej sesji:";
            // 
            // txtSessionTitle
            // 
            txtSessionTitle.Location = new Point(127, 113);
            txtSessionTitle.Name = "txtSessionTitle";
            txtSessionTitle.Size = new Size(125, 27);
            txtSessionTitle.TabIndex = 1;
            // 
            // btnAddSession
            // 
            btnAddSession.Location = new Point(137, 167);
            btnAddSession.Name = "btnAddSession";
            btnAddSession.Size = new Size(94, 29);
            btnAddSession.TabIndex = 2;
            btnAddSession.Text = "Dodaj sesję";
            btnAddSession.UseVisualStyleBackColor = true;
            // 
            // lstSessions
            // 
            lstSessions.FormattingEnabled = true;
            lstSessions.Location = new Point(97, 249);
            lstSessions.Name = "lstSessions";
            lstSessions.Size = new Size(180, 124);
            lstSessions.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(121, 213);
            label2.Name = "label2";
            label2.Size = new Size(120, 20);
            label2.TabIndex = 4;
            label2.Text = "Lista sesji z bazy:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(519, 43);
            label3.Name = "label3";
            label3.Size = new Size(198, 20);
            label3.TabIndex = 5;
            label3.Text = "Panel Wpisów i Załączników:\r\n";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(97, 43);
            label4.Name = "label4";
            label4.Size = new Size(187, 20);
            label4.TabIndex = 6;
            label4.Text = "Panel Zarządzania Sesjami:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(468, 81);
            label5.Name = "label5";
            label5.Size = new Size(42, 20);
            label5.TabIndex = 7;
            label5.Text = "Opis:";
            // 
            // txtEntryDescription
            // 
            txtEntryDescription.Location = new Point(425, 113);
            txtEntryDescription.Multiline = true;
            txtEntryDescription.Name = "txtEntryDescription";
            txtEntryDescription.Size = new Size(125, 34);
            txtEntryDescription.TabIndex = 8;
            // 
            // btnAddAttachment
            // 
            btnAddAttachment.Location = new Point(411, 167);
            btnAddAttachment.Name = "btnAddAttachment";
            btnAddAttachment.Size = new Size(157, 49);
            btnAddAttachment.TabIndex = 9;
            btnAddAttachment.Text = "Dodaj plik FASTA/CSV...";
            btnAddAttachment.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(658, 107);
            label6.Name = "label6";
            label6.Size = new Size(98, 20);
            label6.TabIndex = 10;
            label6.Text = "Wybrany plik:";
            // 
            // lblAttachmentInfo
            // 
            lblAttachmentInfo.AutoSize = true;
            lblAttachmentInfo.Location = new Point(669, 145);
            lblAttachmentInfo.Name = "lblAttachmentInfo";
            lblAttachmentInfo.Size = new Size(0, 20);
            lblAttachmentInfo.TabIndex = 11;
            // 
            // btnAddEntry
            // 
            btnAddEntry.Location = new Point(436, 231);
            btnAddEntry.Name = "btnAddEntry";
            btnAddEntry.Size = new Size(103, 29);
            btnAddEntry.TabIndex = 12;
            btnAddEntry.Text = "Zapisz wpis";
            btnAddEntry.UseVisualStyleBackColor = true;
            // 
            // lstEntries
            // 
            lstEntries.FormattingEnabled = true;
            lstEntries.Location = new Point(632, 249);
            lstEntries.Name = "lstEntries";
            lstEntries.Size = new Size(180, 124);
            lstEntries.TabIndex = 13;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(632, 213);
            label7.Name = "label7";
            label7.Size = new Size(173, 20);
            label7.TabIndex = 14;
            label7.Text = "Wpisy dla wybranej sesji:";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(389, 397);
            label8.Name = "label8";
            label8.Size = new Size(108, 20);
            label8.TabIndex = 15;
            label8.Text = "Panel Eksportu:";
            // 
            // btnExportPdf
            // 
            btnExportPdf.Location = new Point(363, 438);
            btnExportPdf.Name = "btnExportPdf";
            btnExportPdf.Size = new Size(165, 29);
            btnExportPdf.TabIndex = 16;
            btnExportPdf.Text = "Generuj Raport PDF";
            btnExportPdf.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(856, 494);
            Controls.Add(btnExportPdf);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(lstEntries);
            Controls.Add(btnAddEntry);
            Controls.Add(lblAttachmentInfo);
            Controls.Add(label6);
            Controls.Add(btnAddAttachment);
            Controls.Add(txtEntryDescription);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(lstSessions);
            Controls.Add(btnAddSession);
            Controls.Add(txtSessionTitle);
            Controls.Add(label1);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtSessionTitle;
        private Button btnAddSession;
        private ListBox lstSessions;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private TextBox txtEntryDescription;
        private Button btnAddAttachment;
        private Label label6;
        private Label lblAttachmentInfo;
        private Button btnAddEntry;
        private ListBox lstEntries;
        private Label label7;
        private Label label8;
        private Button btnExportPdf;
    }
}
