namespace EventManager.Utilities
{
    public static class FileHelper
    {
        public static async Task<string> UploadFileAsync(IFormFile file, string directory, 
            IWebHostEnvironment hostEnvironment)
        {
            string uploadDir = Path.Combine(hostEnvironment.WebRootPath, directory);
            string fileName = Path.GetFileName(file.FileName);
            string filePath = Path.Combine(uploadDir, fileName);

            // Ensure directory exists
            Directory.CreateDirectory(uploadDir);

            using (FileStream fileStream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(fileStream);
            }

            return filePath;
        }
    }
}
