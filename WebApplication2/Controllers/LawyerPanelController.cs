using BusinessLayer.Concrete;
using DataAccessLayer.EntityFrameWork;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication2.Controllers
{
    [Authorize]
    public class LawyerPanelController : Controller
    {
        FormManager fm = new FormManager(new EFFormDal());
        UserManager um = new UserManager(new EFUserDal());
        MyFileManager filem = new MyFileManager(new EFMyFileDal());

        public ActionResult Index()
        {
            List<Form> result = fm.List();
            return View(result);
        }
        public ActionResult ShowCustomers()
        {
            List<User> result = um.List();
            return View(result);
        }
        public ActionResult ListFilesByUser(int id)
        {
            var result = filem.GetByUser(id);
            return View(result);
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