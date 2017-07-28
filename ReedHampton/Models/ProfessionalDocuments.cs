using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ReedHampton.Models
{
    public class ProfessionalDocuments
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Document Name")]
        public string Title { get; set; }

        [Required]
        [Display(Name = "Document Description")]
        public string Description { get; set; }

        [Required]
        [Display(Name = "Icon")]
        public string Icon { get; set; }

        [DataType(DataType.ImageUrl)]
        [Display(Name = "Document URL")]
        public string FileURL { get; set; }

    }
}