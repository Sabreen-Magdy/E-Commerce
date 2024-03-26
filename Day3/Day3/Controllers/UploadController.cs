using Microsoft.AspNetCore.Mvc;

namespace Day3.Controllers
{
    public class UploadController : Controller
    {
        //to make upload image in page
        public IActionResult Upload()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Upload(string name,IFormFile myFile)
        {
            if(myFile!=null&&name!=null)
            {
                string fileName = $"{name}.{myFile.FileName.Split('.').Last()}";
                using (FileStream f1 = new FileStream($"wwwroot/images/{fileName}", FileMode.Create))
                {


                    myFile.CopyTo(f1);
                }
                return Content("file is will BE UPLOAD success");
            }
            return View();
            
        }
    }
}
