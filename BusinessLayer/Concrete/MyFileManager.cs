using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class MyFileManager : IMyFileService
    {
        IMyFileDal myFileDal;

        public MyFileManager(IMyFileDal myFileDal)
        {
            this.myFileDal = myFileDal;
        }

        public void Delete(MyFile Entity)
        {
            myFileDal.Delete(Entity);
        }

        public void Add(MyFile entity)
        {
            myFileDal.Insert(entity);
        }

        public List<MyFile> List()
        {
            return myFileDal.GetAll();
        }

        public void Edit(MyFile Entity)
        {
            throw new NotImplementedException();
        }
        public MyFile GetById(int id)
        {
            return myFileDal.Get(x => x.FileId==id);
        }
        public List<MyFile> GetByUser(int id)
        {
            return myFileDal.List(x=> x.UserId==id);
        }
    }
}
