using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Book_My_Show.Models
{
    public class FileUpload
    {
        public IFormFile CoverPhoto { get; set; }

        public IFormFile ThemePhoto { get; set; }

        public string Movie { get; set; }
    }
}
