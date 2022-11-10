using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFrameWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication2.Controllers
{
    public class CustomerPanelController : Controller
    {
        MyFileManager filem = new MyFileManager(new EFMyFileDal());
        public ActionResult Index(string p)
        {
            Context c = new Context();
            p = (string)Session["CustomerUserName"];
            var id = c.Users.Where(x => x.Username == p).Select(y => y.UserId).FirstOrDefault();
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