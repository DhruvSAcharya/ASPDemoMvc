using ASPDemoMvc.Data;
using ASPDemoMvc.Models;
using Microsoft.AspNetCore.Mvc;

namespace ASPDemoMvc.Controllers
{
    public class RegistrationController : Controller
    {

        private readonly ApplicationDbContext db;

        public RegistrationController(ApplicationDbContext db)
        {
            this.db = db;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult SaveData(Registration rs)
        {
            UsersModel userModel = null;
            if (rs.password == rs.confirmpassword)
            {
                userModel = new UsersModel();
                userModel.emailid = rs.email;
                userModel.password = rs.password;
            }
            else
            {
                return RedirectToAction("Error", new { err = "Password And Confirm Password is not Same" });
            }

            if(userModel != null)
            {
                db.users.Add(userModel);
                db.SaveChanges();
                return RedirectToAction("Index", "Login");
            }

            return RedirectToAction("Error" , new {err = "Registration failed" });
            
        }

        public string Error(string err)
        {

            return "Error: " + err;

        }


    }
}
