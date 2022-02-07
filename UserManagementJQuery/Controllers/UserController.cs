using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserManagementJQuery.Models;
using UserManagementJQuery.Repository;

namespace UserManagementJQuery.Controllers
{
    public class UserController : Controller
    {

        public ActionResult GetUsers()
        {
            return View();
        }

        public JsonResult GetJson()
        {
            BookstoreManagementContext context = new BookstoreManagementContext();
            UserData userData = new UserData(context);

            var users = userData.GetUsers();
            List<string> jsonUser = new List<string>();
            foreach (var s in users)
            {
                var json = JsonConvert.SerializeObject(s);
                jsonUser.Add(json);
            }

            //var json = JsonConvert.SerializeObject();
            //return Json(jsonUser, JsonRequestBehavior.AllowGet);
            return Json(jsonUser);
        }

        [HttpGet]
        public ActionResult AddUser()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> AddUser(User user)
        {
            BookstoreManagementContext context = new BookstoreManagementContext();
            UserData userData = new UserData(context);
            await  userData.AddUser(user);

            return RedirectToAction("GetUsers");
        }



    }
}
