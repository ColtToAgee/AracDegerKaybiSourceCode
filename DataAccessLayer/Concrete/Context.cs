using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete
{
    public class Context:DbContext
    {
        public DbSet<User> Users { get; set; } 
        public DbSet<Form> Forms { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<MyFile> MyFiles { get; set; }
        public DbSet<Mechanic> Mechanics { get; set; }
        public DbSet<Lawyer> Lawyers { get; set; }
    }
}
