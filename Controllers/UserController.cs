using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Users.Models;
namespace Users.Controllers
{
    public class UserController : Controller
    {
        static List<Person> users = new List<Person>()
        {
               new Person { PersonUid="16114054", Name="Rishikesh Chaudhary", Age=20, Mobile="9305189406", Email="RChaudhary@magnitude.com",Id=1},
        };
        private int id;

        // GET: Person
        public ActionResult Index()
        {
            return View(users);
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(Person per)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View("Create", per);
                }
                users.Add(per);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Details(int id)
        {
            Person per = users.Find(emp => emp.Id == id);
            return View(per);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            Person per = users.Find(emp => emp.Id == id);
            return View(per);
        }

        [HttpPost]

        public ActionResult Edit(Person per)
        {
            try
            {
                Person user = users.Find(x => x.Id == per.Id);
                user.PersonUid = per.PersonUid;
                user.Name = per.Name;
                user.Age = per.Age;
                user.Mobile = per.Mobile;
                user.Email = per.Email;
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        [HttpGet]
        public ActionResult Delete(Person per)
        {
            Person user = users.Find(x => x.Id == per.Id);
            return View(user);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            try
            {
                Person user = users.Find(x => x.Id == id);
                users.Remove(user);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
