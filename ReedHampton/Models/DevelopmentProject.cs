using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ReedHampton.Models
{
    public class DevelopmentProject
    {
        [Key]
        public int id { get; set; }

        //-----------------------For Image------------------------------------------//

        [DataType(DataType.ImageUrl)]
        public string ProjectImageUrl { get; set; }

        //-----------------------In Thumbnail view------------------------------------------//

        [Required]
        public string ShortName { get; set; }

        [Required]
        public string ShortDescription { get; set; }

        //-----------------------In exanded view------------------------------------------//

        [Required]
        public string LongName { get; set; }
        
        [Required]
        public string Category { get; set; }

        [Required]
        public string Date { get; set; }

        [Required]
        public string LongDescription { get; set; }

        [Required]
        public string SkillsNeeded { get; set; }

        public string GitHubUrl { get; set; }

        public string ProjectUrl { get; set; }
    }
}