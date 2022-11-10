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
    public class MechanicManager : IMechanicService
    {
        IMechanicDal mechanicDal;

        public MechanicManager(IMechanicDal mechanicDal)
        {
            this.mechanicDal = mechanicDal;
        }

        public void Add(Mechanic Entity)
        {
            mechanicDal.Insert(Entity);
        }

        public void Delete(Mechanic Entity)
        {
            mechanicDal.Delete(Entity);
        }

        public void Edit(Mechanic Entity)
        {
            mechanicDal.Update(Entity);
        }

        public List<Mechanic> List()
        {
            return mechanicDal.GetAll();
        }
        public Mechanic GetById(int id)
        {
            return mechanicDal.Get(x => x.MechanicId == id);
        }
    }
}
