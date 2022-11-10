using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class MyFile
    {
        [Key]
        public int FileId { get; set; }
        [StringLength(200)]
        public string MyFileName { get; set; }
        [StringLength(200)]
        public string MyFilePath { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }


    }
}
