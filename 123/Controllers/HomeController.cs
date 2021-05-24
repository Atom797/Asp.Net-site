using _123.Models;
using Sitecore.FakeDb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static DataLibrary.Logic.UsersDB;

namespace _123.Controllers
{
    public class HomeController : Controller
    {
        // главная страница
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
        // окно регистрации 
        public ActionResult Create()
        {
            return View();
        }
        // окно регистрации с введенными данными
        [HttpPost]
        public ActionResult Create(UsersModel model)
        {
            if(ModelState.IsValid)
            {
                createUser(model.Email, model.Phone, model.name, model.surname, model.age, model.city, model.announcement, model.Password);
                return RedirectToAction("Index");
            }
            return View();
        }
        // показать объявления
        public ActionResult viewUsers()
        {
            var data = loadUsers();
            List<UsersModel> users = new List<UsersModel>();
            foreach(var el in data)
            {
                users.Add(new UsersModel
                {
                    Phone = el.Phone,
                    Email = el.Email,
                    name = el.name,
                    surname = el.surname,
                    age = el.age,
                    city = el.city,
                    announcement = el.announcement,
                    Password = el.password

                }) ;
            }
            return View(users);
        }
        // поиск объявления по городу
        public ActionResult Poisk(string country)
        {
            UsersModel mod = new UsersModel();
            var data = CitySearch(country);
            List<UsersModel> users = new List<UsersModel>();
            foreach (var el in data)
            {
                users.Add(new UsersModel
                {
                    Phone = el.Phone,
                    Email = el.Email,
                    name = el.name,
                    surname = el.surname,
                    age = el.age,
                    city = el.city,
                    announcement = el.announcement,
                    Password = el.password

                });
            }
            return View(users);
        }
        //окно авторизации
        public ActionResult Аuthorization()
        {
            return View();
        }
        //окно авторизации с введенными данными
        //[HttpPost]
        //public ActionResult Аuthorization(Аuthorization model)
        //{
        //    if (model.Email.Length != 0 && model.Password.Length != 0)
        //    {
        //        Loginaccount(model.Email, model.Password);
        //        TempData["Message"] = model.Email;
        //        TempData["Message2"] = model.Password;
        //        return View("Loginaccount");

        //    }
        //    return View();
        //}

        ////вывод информации авторизованного пользователя
        //public ActionResult Loginaccount(string login, string password)
        //{
        //    var data = Ассaccount(login, password);

        //    List<UsersModel> users = new List<UsersModel>();
        //    foreach (var el in data)
        //    {
        //        users.Add(new UsersModel
        //        {
        //            Phone = el.Phone,
        //            Email = el.Email,
        //            name = el.name,
        //            surname = el.surname,
        //            age = el.age,
        //            city = el.city,
        //            announcement = el.announcement,
        //            Password = el.password

        //        });
        //    }
        //    return View(users);

        //}
        //окно для заявок



        [HttpPost]
        public ActionResult Аuthorization(Аuthorization model)
        {

            if (model.Email.Length != 0 && model.Password.Length != 0)
            {
                var data = Ассaccount(model.Email, model.Password);
                UsersModel asd = new UsersModel();
                foreach (var ey in data)
                {
                    asd.Phone = ey.Phone;

                }
                if (asd.Phone != null)
                {
                    TempData["Message"] = model.Email;
                    TempData["Message2"] = model.Password;
                    Loginaccount(model.Email, model.Password);
                    return View("Loginaccount");
                }
                else
                    return View("Аuthorization");
            }
            return View();
        }

        //вывод информации авторизованного пользователя
        public ActionResult Loginaccount(string login, string password)
        {
            var data = Ассaccount(login, password);

            List<UsersModel> users = new List<UsersModel>();
            foreach (var el in data)
            {
                users.Add(new UsersModel
                {
                    Phone = el.Phone,
                    Email = el.Email,
                    name = el.name,
                    surname = el.surname,
                    age = el.age,
                    city = el.city,
                    announcement = el.announcement,
                    Password = el.password

                });
            }
            return View(users);

        }



        public ActionResult Delete()
        {
            ViewBag.Message = TempData["Message"];
            ViewBag.Message2 = TempData["Message2"];
            string email = ViewBag.Message;
            string password = ViewBag.Message2;
            Deletes(email, password);
            return View("Index");
        }




        public ActionResult Request()
        {
            return View();
        }


        // заполненное окно для заявок
        [HttpPost]
        public ActionResult Request(RequestModel model)
        {
            if (ModelState.IsValid)
            {
                createRequest(model.annemail, model.email, model.phone, model.name, model.surname, model.age, model.request);
                return RedirectToAction("Index");
            }
            return View();
        }

        //вывод заявок
        public ActionResult viewRequest()
        {
            ViewBag.Message = TempData["Message"];
            ViewBag.Message2 = TempData["Message2"];
            string email= ViewBag.Message;
            string password = ViewBag.Message2;
            var data = loadUReq(email, password);
            List<RequestModel> req = new List<RequestModel>();
            foreach (var el in data)
            {
                req.Add(new RequestModel
                {
                    annemail = el.annemail,
                    email = el.email,
                    phone = el.phone,
                    name = el.name,
                    surname = el.surname,
                    age = el.age,
                    request = el.request

                });
            }
            
            return View(req);
        }


        public ActionResult Places()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Places(PlacesModel model)
        {
            if (ModelState.IsValid)
            {
                createPlace(model.city, model.place, model.description);
                return RedirectToAction("listPlaces");
            }
            return View();
        }


        public ActionResult listPlaces(string city)
        {
            var data = Searchplace(city);
            List<PlacesModel> pla = new List<PlacesModel>();
            foreach (var el in data)
            {
                pla.Add(new PlacesModel
                {
                    city = el.city,
                    place = el.place,
                    description = el.description

                });
            }
            return View(pla);
        }


    }
}