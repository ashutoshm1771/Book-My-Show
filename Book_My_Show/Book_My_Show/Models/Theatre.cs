using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Book_My_Show.Models
{
    public class Theatre
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is mandatory")]
        public string Name { get; set; }

        [EnumDataType(typeof(City))]
        public string City { get; set; }

    }
}
