using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ReedHampton.Models
{
    public class AboutMeViewModel
    {
        [Display(Name = "Flip Board Title")]
        public string FlipBoardTitle { get; set; }

        [Display(Name = "Flip Board SubTitle")]
        public string FlipBoardSubTitle { get; set; }

        [Required]
        [Display(Name = "Description")]
        public string Description { get; set; }

        [DataType(DataType.Upload)]
        [Display(Name = "Flip Board Thumbnail")]
        public HttpPostedFileBase FlipBoardThumbnailUpload { get; set; }
    }
}