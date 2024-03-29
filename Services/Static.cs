using Microsoft.AspNetCore.Http;

namespace Services
{
    public static class Static
    {
        private static string root = "./wwwroot/Images/";
        public static void SaveImage(string newName, string file)
        {
            if (file == null)
                throw new ArgumentNullException();
            newName = root + newName /*+ file.FileName.Split('.').Last()*/;

            var base64Data = file.Contains(",") ? file.Split(',')[1] : file;

            byte[] fileBytes = Convert.FromBase64String(base64Data);

            File.WriteAllBytes(newName, fileBytes);
        }
        public static void DeleteImage(string filePath) =>
            File.Delete(root + filePath);
    }
}
