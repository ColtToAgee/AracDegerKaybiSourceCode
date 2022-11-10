using BusinessLayer.Concrete;
using DataAccessLayer.EntityFrameWork;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication2.Controllers
{
    [Authorize(Roles = "A")]
    public class AdminPanelController : Controller
    {
        UserManager um = new UserManager(new EFUserDal());
        FormManager fm = new FormManager(new EFFormDal());
        MechanicManager mm = new MechanicManager(new EFMechanicDal());
        MyFileManager filem=new MyFileManager(new EFMyFileDal());
        public ActionResult Index()
        {
            List<Form> result = fm.List();
            return View(result);
        }
        public ActionResult DeleteForm(int id)
        {
            var value=fm.GetById(id);
            fm.Delete(value);
            return RedirectToAction("Index");
        }
        public ActionResult ListUsers()
        {
            List<User> result = um.List();
            return View(result);
        }
        public ActionResult ListUsersByMechanic(int id)
        {
            List<User> result = um.GetByMechanic(id);
            return View(result);
        }
        [HttpGet]
        public ActionResult AddUser()
        {
            List<SelectListItem> valuemechanic = (from x in mm.List()
                                              select new SelectListItem
                                              {
                                                  Text = x.MechanicUserName,
                                                  Value = x.MechanicId.ToString()
                                              }
                                              ).ToList();
            ViewBag.vm=valuemechanic;
            return View();
        }
        [HttpPost]
        public ActionResult AddUser(User p)
        {
            um.Add(p);
            return RedirectToAction("ListUsers");
        }
        public ActionResult DeleteUser(int id)
        {
            var value=um.GetById(id);
            um.Delete(value);
            return RedirectToAction("ListUsers");
        }
        [HttpGet]
        public ActionResult EditUser(int id)
        {
            var result = um.GetById(id);
            return View(result);
        }
        [HttpPost]
        public ActionResult EditUser(User p)
        {
            um.Edit(p);
            return RedirectToAction("ListUsers");
        }
        public ActionResult ListMechanic()
        {
            List<Mechanic> result = mm.List();
            return View(result);
        }
        [HttpGet]
        public ActionResult AddMechanic()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddMechanic(Mechanic p)
        {
            mm.Add(p);
            return RedirectToAction("ListMechanic");
        }
        [HttpGet]
        public ActionResult EditMechanic(int id)
        {
            var value = mm.GetById(id);
            return View(value);
        }
        [HttpPost]
        public ActionResult EditMechanic(Mechanic p)
        {
            mm.Edit(p);
            return RedirectToAction("ListMechanic");
        }
        public ActionResult DeleteMechanic(int id)
        {
            var value=mm.GetById(id);
            mm.Delete(value);
            return RedirectToAction("ListMechanic");
        }
        public ActionResult ListFiles()
        {
            var result = filem.List();
            return View(result);
        }
        public ActionResult ListFilesByUser(int id)
        {
            var result = filem.GetByUser(id);
            return View(result);
        }
        [HttpGet]
        public ActionResult AddFile()
        {
            List<SelectListItem> valueuser = (from x in um.List()
                                              select new SelectListItem
                                              {
                                                  Text = x.Username,
                                                  Value=x.UserId.ToString()
                                              }
                                              ).ToList();
            ViewBag.vu=valueuser;
            return View();
        }
        [HttpPost]
        public ActionResult AddFile(HttpPostedFileBase file,MyFile p)
        {
            if(file.ContentLength > 0)
            {
                string _FileName = Path.GetFileName(file.FileName);
                string _path = Path.Combine(Server.MapPath("~/UploadedFiles"), _FileName);
                file.SaveAs(_path);
                p.MyFileName= _FileName;
                p.MyFilePath= _path;
                filem.Add(p);
            }
            return RedirectToAction("ListFiles");
        }
        public ActionResult DeleteFile(int id)
        {
            var value = filem.GetById(id);
            filem.Delete(value);
            return RedirectToAction("ListFiles");
        }
        public ActionResult DownloadFile(int id)
        {
            var value = filem.GetById(id);
            byte[] filebytes = GetFile(value.MyFilePath);
            return File(filebytes, System.Net.Mime.MediaTypeNames.Application.Octet, value.MyFilePath);
        }
        byte[] GetFile(string s)
        {
            System.IO.FileStream fs = System.IO.File.OpenRead(s);
            byte[] data = new byte[fs.Length];
            int br = fs.Read(data, 0, data.Length);
            if (br != fs.Length)
                throw new System.IO.IOException(s);
            return data;
        }
    }
}