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
    public class UserPanelController : Controller
    {
        UserManager um = new UserManager(new EFUserDal());
        MyFileManager mfm = new MyFileManager(new EFMyFileDal());
        [Authorize]
        public ActionResult Index(string p)
        {
            Context c = new Context();
            p = (string)Session["UserName"];
            var userinfo = c.Mechanics.Where(x => x.MechanicUserName == p).Select(y => y.MechanicId).FirstOrDefault();
            var musteriler = um.GetByMechanic(userinfo);
            return View(musteriler);
        }
        [Authorize]
        public ActionResult Files(string p,int id)
        {
            Context c = new Context();
            p = (string)Session["UserName"];
            var dosyalar = mfm.GetByUser(id);
            return View(dosyalar);
        }
        [Authorize]
        public ActionResult Download(int id)
        {
            var value = mfm.GetById(id);
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