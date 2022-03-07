using ASPDemoMvc.Data;
using ASPDemoMvc.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace ASPDemoMvc.Controllers
{
    public class LoginController : Controller
    {
        private readonly ApplicationDbContext db;

        public LoginController(ApplicationDbContext db)
        {
            this.db = db;
        }
        public IActionResult Index()
        {
            return View();
        }

 
        public IActionResult isValid(LoginModel model)
        {
            UsersModel userModel = new UsersModel();
            userModel.emailid = model.email;
            userModel.password = model.password;

            IEnumerable<UsersModel> users = db.users;
            
            foreach(var user in users)
            {
                if(userModel.emailid == user.emailid)
                {
                    if (userModel.password == user.password)
                    {
                        HttpContext.Session.SetString("curuser",user.Id.ToString());
                        return RedirectToAction("Index", "Home");
                    }
                }
            }

            return RedirectToAction("Error", new { err = "Invalid Email id or password" });
            
            
        }

        public string Error(string err)
        {

            return "Error: " + err;

        }
    }
}
