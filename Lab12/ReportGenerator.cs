using Lab12;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using System.IO;

namespace Lab12
{
    public class ReportGenerator
    {
        public void ExportSessionToPdf(Session session, string destinationPath)
        {
            QuestPDF.Settings.License = LicenseType.Community;

            Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Size(PageSizes.A4);
                    page.Margin(2, Unit.Centimetre);
                    page.PageColor(Colors.White);
                    page.DefaultTextStyle(x => x.FontSize(12));

                    page.Header()
                        .Text($"Raport Analityczny: {session.Title}")
                        .SemiBold().FontSize(20).FontColor(Colors.Blue.Darken2);

                    page.Content().PaddingVertical(1, Unit.Centimetre).Column(col =>
                    {
                        col.Item().Text($"Data utworzenia sesji: {session.CreationDate:dd.MM.yyyy HH:mm}");
                        col.Item().PaddingTop(15).Text("Zapisane działania i wyniki:").Bold();

                        foreach (var entry in session.Entries)
                        {
                            col.Item().PaddingTop(10).Text($"- {entry.Description}");

                            if (!string.IsNullOrEmpty(entry.AttachmentPath))
                            {
                                col.Item().PaddingLeft(15)
                                   .Text($"[Załączony plik: {Path.GetFileName(entry.AttachmentPath)}]")
                                   .FontColor(Colors.Grey.Medium);
                            }
                        }
                    });

                    page.Footer()
                        .AlignCenter()
                        .Text(x =>
                        {
                            x.Span("Strona ");
                            x.CurrentPageNumber();
                            x.Span(" z ");
                            x.TotalPages();
                        });
                });
            }).GeneratePdf(destinationPath);
        }
    }
}