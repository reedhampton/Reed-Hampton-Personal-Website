using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ReedHampton.Models
{
    public class ProfessionalDocumentsViewModel
    {
        [Required]
        [Display(Name = "Document Name")]
        public string Title { get; set; }

        [Required]
        [Display(Name = "Document Description")]
        public string Description { get; set; }

        [DataType(DataType.Upload)]
        [Display(Name = "File Upload")]
        public HttpPostedFileBase FileUpload { get; set; }
    }
}