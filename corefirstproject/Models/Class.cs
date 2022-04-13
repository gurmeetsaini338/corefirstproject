using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace corefirstproject.Models
{
    public class Class
    {
       [key]
        public int Id { get; set; }

        [Required(ErrorMessage= "Required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Required")]
        public int Salary { get; set; }

        [Required(ErrorMessage = "Required")]
        public string City { get; set; }

        [Required(ErrorMessage = "Required")]
        public string Depart { get; set; }
    }
}
