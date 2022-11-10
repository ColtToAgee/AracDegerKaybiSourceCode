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
    public class UserManager : IUserService
    {
        IUserDal userDal;
        public UserManager(IUserDal userDal)
        {
            this.userDal = userDal;
        }

        public void Delete(User user)
        {
            userDal.Delete(user);
        }
        public User GetById(int id)
        {
            return userDal.Get(x => x.UserId == id);
        }

        public void Add(User user)
        {
            userDal.Insert(user);
        }

        public List<User> List()
        {
            return userDal.GetAll();
        }

        public void Edit(User user)
        {
            userDal.Update(user);
        }        
        public List<User> GetByMechanic(int id) 
        {
            return userDal.List(x => x.MechanicId == id);
        }
    }
}
