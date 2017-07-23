using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ReedHampton.Models
{
    public class AboutMe
    {
        [Key]
        [Required]
        public int id { get; set; }

        [Display(Name = "Flip Board Title")]
        public string FlipBoardTitle { get; set; }

        [Display(Name = "Flip Board SubTitle")]
        public string FlipBoardSubTitle { get; set; }

        [DataType(DataType.ImageUrl)]
        [Display(Name = "Flip Board Thumbnail")]
        public string FlipboardThumnbailUrl { get; set; }

        [Required]
        [Display(Name = "Description")]
        public string Description { get; set; }

    }
}