using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ReedHampton.Models
{
    public class ContactInformation
    {
        [Key]
        [Required]
        public int id { get; set; }

        [Display(Name = "Contact Name")]
        public string ContactName { get; set; }

        [EmailAddress]
        [Display(Name = "Primary Email")]
        public string PrimaryEmail { get; set; }

        [EmailAddress]
        [Display(Name = "Secondary Email")]
        public string SecondaryEmail { get; set; }

        [RegularExpression(@"^http(s?)\:\/\/[0-9a-zA-Z]([-.\w]*[0-9a-zA-Z])*(:(0-9)*)*(\/?)([a-zA-Z0-9\-\.\?\,\'\/\\\+&amp;%\$#_]*)?$", ErrorMessage = "URL format is wrong")]
        [Display(Name = "GitHub")]
        public string GitHubLink { get; set; }

        [RegularExpression(@"^http(s?)\:\/\/[0-9a-zA-Z]([-.\w]*[0-9a-zA-Z])*(:(0-9)*)*(\/?)([a-zA-Z0-9\-\.\?\,\'\/\\\+&amp;%\$#_]*)?$", ErrorMessage = "URL format is wrong")]
        [Display(Name = "LinkedIn")]
        public string LinkedInLink { get; set; }

        [RegularExpression(@"^http(s?)\:\/\/[0-9a-zA-Z]([-.\w]*[0-9a-zA-Z])*(:(0-9)*)*(\/?)([a-zA-Z0-9\-\.\?\,\'\/\\\+&amp;%\$#_]*)?$", ErrorMessage = "URL format is wrong")]
        [Display(Name = "Facebook")]
        public string FacebookLink { get; set; }
    }
}