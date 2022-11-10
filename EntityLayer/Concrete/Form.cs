using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Form
    {
        [Key]
        public int FormId { get; set; }
        [StringLength(100)]
        public string NameSurname { get; set; }
        [StringLength(100)]
        public string Email { get; set; }
        [StringLength(100)]
        public string Telephone { get; set; }
        [StringLength(100)]
        public string CarModel { get; set; }
        [StringLength(100)]
        public string CarYear { get; set; }
        [StringLength(100)]
        public string CarKm { get; set; }
        [StringLength(100)]
        public string CarCrash { get; set; }
    }
}
