using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Book_My_Show.Models
{
    public class Movie
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal ImbdRating { get; set; }

        [EnumDataType(typeof(MovieCategory))]
        public string Category { get; set; }

        
        [EnumDataType(typeof(MovieGenre))]
        public string Genre { get; set; }

        
        public DateTime ReleaseDate { get; set; }

        
        public string ActorName { get; set; }


        public string ActressName { get; set; }

        public string ThemePhotoPath { get; set; }
    }
}
