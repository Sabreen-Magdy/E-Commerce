using Microsoft.AspNetCore.Http;

namespace Services
{
    public static class Static
    {
        public static void SaveImage(string newName, string file)
        {
            if (file == null)
                throw new ArgumentNullException();
            newName = "./wwwroot/Images/"+ newName + ".png" /*+ file.FileName.Split('.').Last()*/;

            var base64Data = file.Contains(",") ? file.Split(',')[1] : file;

            byte[] fileBytes = Convert.FromBase64String(base64Data);

            File.WriteAllBytes(newName, fileBytes);
           
            //using (var stream = File.Create(newName))
            //{
            //    file.CopyTo(stream);
            //}
        }
    }
}
