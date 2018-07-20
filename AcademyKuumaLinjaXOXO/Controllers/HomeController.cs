using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AcademyKuumaLinjaXOXO.Models;


namespace AcademyKuumaLinjaXOXO.Controllers
{
    public class HomeController : Controller
    {
        AcademyChatEntities db = new AcademyChatEntities();
        Person user = new Person();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }


        public ActionResult ConnectToDB()
        {
            return View(db.Messages);
        }

        public ActionResult Luokäyttäjä(string nickname, string password)
        {
            List<Person> person = new List<Person>();
            person = db.People.ToList();
            bool isNickTaken = false;

            foreach (var item in person)
            {
                if (nickname == item.NickName)
                {
                    isNickTaken = true;
                }
            }

            if (isNickTaken == true)
            {
                return Content("Käyttäjänimi on jo käytössä");
            }
            else
            {
                user.NickName = nickname;
                user.Password = password;
                user.Description = "Master of the Universe!";
                db.People.Add(user);
                db.SaveChanges();
                HaePersonID();

            }

            return View("LähetäViesti");
        }
        public ActionResult Kirjaudu(string nickname, string password)
        {
            user.NickName = nickname;
            user.Password = password;

            var a = from u in db.People
                    where u.NickName == user.NickName &&
                    u.Password == user.Password
                    select u;

            if (a == null)
            {
                return Content("Käyttäjänimi ja salasana ei täsmää");
            }
            else
            {
                HaePersonID();
                return View("LähetäViesti");
            }
        }

        public ActionResult ListaaKäyttäjät()
        {
            List<Person> käyttäjät = db.People.ToList();
            return View(käyttäjät);

        }
        public ActionResult LähetäViesti(String viesti)
        {


            Message message = new Message();

            message.MessageText = viesti;
            message.SendTime = DateTime.Now.ToLocalTime();
            message.PrivateMessage = false;
            message.From_Person_Id = user.Person_Id;

            db.Messages.Add(message);
            db.SaveChanges();

            return View("LähetäViesti", db.Messages);
        }

        public void HaePersonID()
        {
            var a = from id in db.People
                    where id.NickName == user.NickName
                    select id.Person_Id;

            foreach (var item in a)
            {
                user.Person_Id = item;

            }
        }
    }
}