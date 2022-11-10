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
    public class LawyerManager : ILawyerService
    {
        ILawyerDal lawyerDal;

        public LawyerManager(ILawyerDal lawyerDal)
        {
            this.lawyerDal = lawyerDal;
        }

        public void Add(Lawyer entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Lawyer Entity)
        {
            throw new NotImplementedException();
        }

        public void Edit(Lawyer Entity)
        {
            throw new NotImplementedException();
        }

        public List<Lawyer> List()
        {
            throw new NotImplementedException();
        }
    }
}
