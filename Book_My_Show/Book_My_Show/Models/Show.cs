﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Book_My_Show.Models
{
    public class Show
    {
        public string Time { get; set; }

        // Data annotation 
        [ForeignKeyAttribute("Theatre")]
        public int TheatreId { get; set; }

        [ForeignKeyAttribute("Movie")]
        public int MovieId { get; set; }
    }
}
