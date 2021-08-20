using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Book_My_Show.Models
{
    public class Ticket
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string UserName { get; set; }

        public int NumberOfSeats { get; set; }

        [ForeignKey("Show"), Column(Order = 0)]
        public string ShowTime { get; set; }

        [ForeignKey("Show"), Column(Order = 1)]
        public int TheatreId { get; set; }

        [ForeignKey("Show"), Column(Order = 2)]
        public int MovieId { get; set; }
    }
}
