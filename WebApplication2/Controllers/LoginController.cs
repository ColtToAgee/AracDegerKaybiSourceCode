using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFrameWork;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace WebApplication2.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }    
        [HttpGet]
        public ActionResult AdminLogin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AdminLogin(Admin p)
        {
            Context c = new Context();
            var adminuserinfo = c.Admins.FirstOrDefault(x => x.UserName == p.UserName && x.Password == p.Password);
            if (adminuserinfo != null)
            {
                FormsAuthentication.SetAuthCookie(adminuserinfo.UserName, false);
                Session["AdminUserName"] = adminuserinfo.UserName;
                return RedirectToAction("Index", "AdminPanel");
            }
            else
            {
                return RedirectToAction("Index");
            }

        }
        [HttpGet]
        public ActionResult UserLogin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult UserLogin(Mechanic p)
        {
            Context c = new Context();
            var userinfo = c.Mechanics.SingleOrDefault(x => x.MechanicUserName == p.MechanicUserName && x.MechanicPassword == p.MechanicPassword);
            if (userinfo != null)
            {
                FormsAuthentication.SetAuthCookie(userinfo.MechanicUserName, false);
                Session["UserName"] = userinfo.MechanicUserName;
                return RedirectToAction("Index", "UserPanel");
            }
            else
            {
                return RedirectToAction("UserLogin");
            }
        }
        [HttpGet]
        public ActionResult CustomerLogin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CustomerLogin(User p)
        {
            Context c = new Context();
            var userinfo = c.Users.SingleOrDefault(x => x.Username == p.Username && x.Password == p.Password);
            if (userinfo != null)
            {
                FormsAuthentication.SetAuthCookie(userinfo.Username, false);
                Session["CustomerUserName"] = userinfo.Username;
                return RedirectToAction("Index", "CustomerPanel");
            }
            else
            {
                return RedirectToAction("CustomerLogin");
            }
        }
        [HttpGet]
        public ActionResult LawyerLogin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult LawyerLogin(Lawyer p)
        {
            Context c = new Context();
            var userinfo = c.Lawyers.SingleOrDefault(x => x.LawyerUsername == p.LawyerUsername && x.LawyerPassword == p.LawyerPassword);
            if (userinfo != null)
            {
                FormsAuthentication.SetAuthCookie(userinfo.LawyerUsername, false);
                Session["LawyerUsername"] = userinfo.LawyerUsername;
                return RedirectToAction("Index", "LawyerPanel");
            }
            else
            {
                return RedirectToAction("LawyerLogin");
            }
        }
    }
}