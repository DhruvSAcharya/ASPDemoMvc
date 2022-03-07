using ASPDemoMvc.Data;
using ASPDemoMvc.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text.Json;

namespace ASPDemoMvc.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext db;

        public HomeController(ApplicationDbContext db)
        {
            this.db = db;
        }

        public IActionResult Index()
        {
            string str = HttpContext.Session.GetString("curuser");
            if(str != null)
            {
                int id = int.Parse(str);
                if (id != 0)
                {
                    UsersModel curuser = db.users.Find(id);
                    return View();
                }
            }
            

            return RedirectToAction("Index","Login");
            
        }

        public IActionResult SaveData(ServiceRequest sr)
        {
            if (ModelState.IsValid)
            {
                string str = HttpContext.Session.GetString("curuser");
                if (str != null)
                {
                    int id = int.Parse(str);
                    if (id != 0)
                    {
                        sr.userid = id;
                    }
                }
                if (sr.fName != null && sr.userid != 0)
                {
                    db.serviceRequests.Add(sr);
                    db.SaveChanges();
                    return RedirectToAction("DisplayRequest");
                }
                return RedirectToAction("Error", new { err = "Error while saving data" });
            }
            return RedirectToAction("Index");
            
        }


        public IActionResult DisplayRequest()
        {
            IEnumerable<ServiceRequest> alluser = db.serviceRequests;
            string str = HttpContext.Session.GetString("curuser");
            List<ServiceRequest> list = new List<ServiceRequest>();
            if (str != null)
            {
                int id = int.Parse(str);
                if (id != 0)
                {
                    foreach (ServiceRequest sr in alluser)
                    {
                        if(sr.userid == id)
                        {
                            list.Add(sr);
                        }
                        
                    }
                }
            }
            IEnumerable<ServiceRequest> obj = list;
            return View(obj);
        }

        public IActionResult DeleteRequest(int id)
        {
            ServiceRequest obj = db.serviceRequests.Find(id);

            //ServiceRequest Obj = JsonSerializer.Deserialize<ServiceRequest>(str);
            return View(obj);
        }

        public IActionResult DeleteData(ServiceRequest sr)
        {
            string str = HttpContext.Session.GetString("curuser");
            if (str != null)
            {
                int id = int.Parse(str);
                if (id != 0)
                {
                    sr.userid = id;
                }
            }

            if (sr.Id != 0 && sr.userid != 0)
            {
                db.serviceRequests.Remove(sr);
                db.SaveChanges();
                return RedirectToAction("DisplayRequest", "Home");
            }

            return RedirectToAction("Error", new { err = "Error while Deleting data" });
        }

        public IActionResult UpdateRequest(int id)
        {
            ServiceRequest obj = db.serviceRequests.Find(id);
            return View(obj);
        }

        public IActionResult UpdateData(ServiceRequest sr)
        {
            string str = HttpContext.Session.GetString("curuser");
            if (str != null)
            {
                int id = int.Parse(str);
                if (id != 0)
                {
                    sr.userid = id;
                }
            }
            if (sr.Id != 0 && sr.userid != 0)
            {
                db.serviceRequests.Update(sr);
                db.SaveChanges();
                return RedirectToAction("DisplayRequest");
            }
            return RedirectToAction("Error", new { err = "Error while updating data" });

        }

        public IActionResult Logout()
        {
            HttpContext.Session.Remove("curuser");
            return RedirectToAction("Index", "Login");

        }
        public string Error(string err)
        {

            return "Error: " + err;

        }

    }
}
