using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace u21512338_HW03.Models
{
    public class FileModel
    {
        //filename
        [Display(Name = "File Name")]
        public string FileName { get; set; }

        //chosen files
        [Required(ErrorMessage = "Please select file.")]
        [Display(Name = "Browse File")]
        public HttpPostedFileBase[] Files { get; set; }

        //radio button type
        public string Type { get; set; }

        //image path
        public string Image { get; set; }

        //video path
        public string Vid { get; set; }

    }
}