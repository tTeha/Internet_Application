﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Projects_Management_System.Models;


namespace Projects_Management_System.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult register()
        {

            return View();
        }



        [HttpPost]
        public ActionResult register(User user)
        {
          
            if (ModelState.IsValid)
            {
                byte[] data = new byte[user.File.ContentLength];
                user.File.InputStream.Read(data, 0, user.File.ContentLength);
                user.Photo = data;
               
                using (Managment db = new Managment())
                {
                    if (!db.Users.Any(e=>e.Email==user.Email))
                    {
                        db.Users.Add(user);
                        db.SaveChanges();
                        return RedirectToAction("login", "Home");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Email Already Esist ");

                    }

                }
             
            }
          
            return View();
        }


































        [HttpGet]
        public ActionResult login()
        {
            return View();
        }
        [HttpPost]
        public  ActionResult login(User user)
        {
            using (Managment db = new Managment())
            {
                var usr = db.Users.FirstOrDefault(x => x.User_Name == user.User_Name && x.password == user.password);
                if (usr !=null )
                {
                    Session["userID"] = usr.ID.ToString();
                    Session["username"] = usr.User_Name.ToString();
                    return RedirectToAction("Index", "Home", new { area = "Customers" });

                }
                else
                {
                    ModelState.AddModelError("", "User name or password is wrong ");
                }
            }
            return View();
        }
    }
}