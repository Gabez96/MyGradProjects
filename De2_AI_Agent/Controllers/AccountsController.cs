using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using De2_AI_Agent.Models;
using De2_AI_Agent.TreeStore;

namespace De2_AI_Agent.Controllers
{
    public class AccountsController : Controller
    {
        // GET: Accounts
        DataStorage db = new DataStorage();
        public ActionResult Register()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Register(Users2 users)
        {
            Users us = new Users();
            AccomodationOwner accom = new AccomodationOwner();
            Student stu = new Student();

            if (ModelState.IsValid)
            {
                if (users.UsersType == "Student")
                {
                    stu.University = "University of Capetown";
                }
                else
                {
                    accom.phoneNumber = 0834979732;
                }

                us.name = users.name;
                us.password = users.password;
                us.username = users.username;

                db.Users.Add(us);
                try
                {
                    db.SaveChanges();
                    if (stu.University == null)
                    {
                        Users d = db.Users.Where(c => c.username == users.username).FirstOrDefault();
                        accom.UsersId = d.Id;
                        db.AccomodationOwner.Add(accom);
                        db.SaveChanges();
                    }
                    else
                    {
                        Users d = db.Users.Where(c => c.username == users.username).FirstOrDefault();
                        stu.UsersId = d.Id;
                        db.Student.Add(stu);
                        db.SaveChanges();
                    }

                }
                catch (Exception e)
                {

                }
            }
            ViewBag.Message = "Wrong!!";
            return View();
        }
    }
}