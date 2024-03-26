using Microsoft.AspNetCore.Http;

namespace Services
{
    public static class Static
    {
        public static void SaveImage(string newName, IFormFile file)
        {
            if (file == null)
                throw new ArgumentNullException();
            newName = "./wwwroot/Images/"+ newName + "." + file.FileName.Split('.').Last();
           
            using (var stream = File.Create(newName))
            {
                file.CopyTo(stream);
            }
        }
    }
}
