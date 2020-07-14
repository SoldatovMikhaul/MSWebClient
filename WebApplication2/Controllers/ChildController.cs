using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Models;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using Microsoft.AspNetCore.Http;
using System.Text;
using System;
using System.Web;

namespace WebApplication2.Controllers
{
    public class ChildController : Controller
    {
        public ApplicationContext db;
        public IWebHostEnvironment _appEnvironment;
        public ChildViewModel cvm;

        public enum male
        {
            Female,
            Male
        }
        string GenRandomString(string Alphabet, int Length)
        {
            Random rnd = new Random();
            StringBuilder sb = new StringBuilder(Length - 1);
            int Position = 0;
            for (int i = 0; i < Length; i++)
            {
                Position = rnd.Next(0, Alphabet.Length - 1);
                sb.Append(Alphabet[Position]);
            }
            return sb.ToString();
        }

        public ChildController(ApplicationContext context, IWebHostEnvironment appEnvironment)
        {
            db = context;
            _appEnvironment = appEnvironment;
        }
        public async Task<IActionResult> Index()
        {
            return View(await db.Child.ToListAsync());
        }
        public IActionResult Create()
        {
            return View();
        }

        //httppost-создает проблемы с ним страница не доступна без него - просто не найдена
        [HttpPost]
        public async Task<IActionResult> CreateChild(Models.Child child, ChildViewModel cvm, IFormFile uploadedFile)
        {
            if (uploadedFile != null)
            {
                string path = "/Files/" + GenRandomString("QWERTYUIOPASDFGHJKLZXCVBNMqwertyuiopasdfghjklzxcvbnm", 10) + ".jpg";
                Console.WriteLine(path);
                using (var fileStream = new FileStream(_appEnvironment.WebRootPath + path, FileMode.Create))
                {
                    await uploadedFile.CopyToAsync(fileStream);
                }
                child.Path = path.ToString();
                Console.WriteLine(path);
            }

            if (cvm.Avatar != null)
            {
                byte[] imageData = null;
                using (var binaryReader = new BinaryReader(cvm.Avatar.OpenReadStream()))
                {
                    imageData = binaryReader.ReadBytes((int)cvm.Avatar.Length);
                }
                child.Avatar = imageData;
            }
            child.Birthday.ToString();
            db.Child.Add(child);
            await db.SaveChangesAsync();
            //return RedirectToAction("Index");
            return Redirect("Index");
        }

    }
}