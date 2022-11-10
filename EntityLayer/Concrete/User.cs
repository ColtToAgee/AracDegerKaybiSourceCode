using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        [StringLength(100)]
        public string Username { get; set; }
        [StringLength(100)]
        public string Password { get; set; }
        [StringLength(100)]
        public string PhoneNumber{ get; set; }
        public int MechanicId { get; set; }
        public virtual Mechanic Mechanic { get; set; }
        public ICollection<MyFile> Files { get; set; }
        public int? LawyerId { get; set; }
        public virtual Lawyer Lawyer { get; set; }
       

    }
}
