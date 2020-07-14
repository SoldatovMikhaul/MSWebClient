using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using WebApplication2.Models;
using System.Web;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Data;
using System.Text;
using System.Management.Automation;

namespace WebApplication2.Controllers
{
    public class HomeController : Controller
    {
        public ApplicationContext db;
        public IWebHostEnvironment _appEnvironment;
        public UserViewModel uvm;
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
        public HomeController(ApplicationContext context, IWebHostEnvironment appEnvironment)
        {
            db = context;
            _appEnvironment = appEnvironment;
        }

        public async Task<IActionResult> Index()
        {
            return View(await db.t_Users.ToListAsync());
        }
        public IActionResult Create()
        {
            return View();
        }

        /*[HttpPost]
        public async Task<IActionResult> CreateChild(Models.Child child, ChildViewModel cvm, IFormFile uploadedFile)
        {
            if (uploadedFile != null)
            {
                string path = "/Files/" + GenRandomString("PASDFGHJKLZXCVBNMqwertyuiopasdfghjklzxcvbnm", 10) + ".jpg";
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
            //if (user.Birthday != null)
            // {
            child.Birthday.ToString();
            // }

            db.Child.Add(child);
            await db.SaveChangesAsync();
            return RedirectToAction("IndexChild");
        }*/

        [HttpPost]
        public async Task<IActionResult> Create(User user, UserViewModel uvm, IFormFile uploadedFile)
        {
            if (uploadedFile != null)
            {
                string path = "/Files/" + GenRandomString("QWERTYUIOPASDFGHJKLZXCVBNMqwertyuiopasdfghjklzxcvbnm", 10) + ".jpg";
                Console.WriteLine(path);
                using (var fileStream = new FileStream(_appEnvironment.WebRootPath + path, FileMode.Create))
                {
                    await uploadedFile.CopyToAsync(fileStream);
                }
                user.Path = path.ToString();
                Console.WriteLine(path);
            }

            if (uvm.Avatar !=  null)
            {
                byte[] imageData = null;
                using (var binaryReader = new BinaryReader(uvm.Avatar.OpenReadStream()))
                {
                    imageData = binaryReader.ReadBytes((int)uvm.Avatar.Length);
                }
                user.Avatar = imageData;
            }
            //if (user.Birthday != null)
            // {
                user.Birthday.ToString();
            // }

            db.t_Users.Add(user);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        /*[HttpPost]
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
            //if (user.Birthday != null)
            // {
            child.Birthday.ToString();
            // }

            db.Child.Add(child);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }*/

        public async Task<IActionResult> Details(int? id)
        {
            if (id != null)
            {
                User user = await db.t_Users.FirstOrDefaultAsync(p => p.Id == id);
                if (user != null)
                    return View(user);
            }
            return NotFound();
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id != null)
            {
                User user = await db.t_Users.FirstOrDefaultAsync(p => p.Id == id);
                if (user != null)
                    return View(user);
            }

            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Edit(User user, IFormFile uploadedFile, UserViewModel uvm)
        {
            if (uploadedFile != null)
            {
                string path = "/Files/" + GenRandomString("QWERTYUIOPASDFGHJKLZXCVBNMqwertyuiopasdfghjklzxcvbnm", 10) + ".jpg";
                Console.WriteLine(path);
                using (var fileStream = new FileStream(_appEnvironment.WebRootPath + path, FileMode.Create))
                {
                    await uploadedFile.CopyToAsync(fileStream);
                }
                user.Path = path.ToString();
                Console.WriteLine(path);
            }

            if (uvm.Avatar != null)
            {
                byte[] imageData = null;
                using (var binaryReader = new BinaryReader(uvm.Avatar.OpenReadStream()))
                {
                    imageData = binaryReader.ReadBytes((int)uvm.Avatar.Length);
                }
                user.Avatar = imageData;
            }

            db.t_Users.Update(user);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [HttpGet]
        [ActionName("Delete")]
        public async Task<IActionResult> ConfirmDelete(int? id)
        {
            if (id != null)
            {
                User user = await db.t_Users.FirstOrDefaultAsync(p => p.Id == id);
                if (user != null)
                    return View(user);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id != null)
            {
                User user = await db.t_Users.FirstOrDefaultAsync(p => p.Id == id);
                if (user != null)
                {
                    db.t_Users.Remove(user);
                    await db.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
            }


            return NotFound();
        }
    }
}
