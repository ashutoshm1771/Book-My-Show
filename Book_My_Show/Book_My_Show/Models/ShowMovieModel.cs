using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Book_My_Show.Models
{
    public class ShowMovieModel
    {
        public string Time { get; set; }

        [ForeignKeyAttribute("Theatre")]
        public int TheatreId { get; set; }

        [ForeignKeyAttribute("Movie")]
        public int MovieId { get; set; }

        public string Name { get; set; }
    }
}
