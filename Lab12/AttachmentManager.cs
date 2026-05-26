using System.IO;

namespace Lab12
{
    public class AttachmentManager
    {
        private readonly string _attachmentsFolder = "Attachments";

        public AttachmentManager()
        {
            if (!Directory.Exists(_attachmentsFolder))
            {
                Directory.CreateDirectory(_attachmentsFolder);
            }
        }

        public string SaveAttachment(string sourceFilePath)
        {
            var fileName = Path.GetFileName(sourceFilePath);

            var destinationPath = Path.Combine(_attachmentsFolder, fileName);

            File.Copy(sourceFilePath, destinationPath, overwrite: true);

            return destinationPath;
        }
    }
}