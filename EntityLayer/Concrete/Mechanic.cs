using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Mechanic
    {
        [Key]
        public int MechanicId { get; set; }
        [StringLength(200)]
        public string MechanicUserName { get; set; }
        [StringLength(200)]
        public string MechanicPassword { get; set; }
        [StringLength(200)]
        public string MechanicPhone { get; set; }
        public ICollection<User> Users { get; set; }

    }
}
