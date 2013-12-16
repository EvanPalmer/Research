using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using TheMvcApp.Aspects;
using TheMvcApp.Models;

namespace TheMvcApp.Controllers
{
    public class UserInfoController : Controller
    {
        //
        // GET: /UserInfo/
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Save(UserInfoModel model)
        {
            return PartialView(model);
        }

        [HttpGet]
        public ActionResult Users()
        {
            HttpContext.Response.Cookies.Add(new HttpCookie("XSRF-TOKEN", "evan"));
            var users = AllUserInfoModels;
            return Json(users, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [AngularAntiForgeryToken]
        public ActionResult Users(UserInfoModel model)
        {
            HttpContext.Response.Cookies.Add(new HttpCookie("XSRF-TOKEN", "evan")); 
            AllUserInfoModels.Add(model);
            return Json(new {success = true});
        }

        private static List<UserInfoModel> _users;
        private static List<UserInfoModel> AllUserInfoModels
        {
            get
            {
                if (_users != null) return _users;
                _users = new List<UserInfoModel>
                    {
                        new UserInfoModel
                            {
                                Age = 91,
                                EmailAddress = "oldguy_69@gmail.com",
                                Name = "John"
                            },
                        new UserInfoModel
                            {
                                Age = 19,
                                EmailAddress = "youngguy_69@gmail.com",
                                Name = "Mark"
                            }
                    };
                return _users;
            }
        }
    }


}
