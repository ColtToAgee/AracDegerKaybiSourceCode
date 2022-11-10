using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Lawyer
    {
        [Key]
        public int LawyerId { get; set; }
        [StringLength(200)]
        public string LawyerUsername { get; set; }
        [StringLength(200)]
        public string LawyerPassword { get; set; }
        public ICollection<User> Users { get; set; }
    }
}
