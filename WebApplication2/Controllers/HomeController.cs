using BusinessLayer.Concrete;
using DataAccessLayer.EntityFrameWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EntityLayer.Concrete;

namespace WebApplication2.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        FormManager fm = new FormManager(new EFFormDal());
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }       
        [HttpPost]
        public ActionResult Index(Form form)
        {
            fm.Add(form);
            return View();
        }       
        public ActionResult Services()
        {
            return View();
        }
        public ActionResult Kisisel_Verilerin_Korunması()
        {
            return View();
        }
        public ActionResult Kisisel_Veri_Saklama()
        {
            return View();
        }
        public ActionResult Ozel_Nitelik()
        {
            return View();
        }
    }
}