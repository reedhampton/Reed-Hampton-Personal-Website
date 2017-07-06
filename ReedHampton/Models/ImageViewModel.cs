using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web;
using System.Web.Mvc;

namespace ReedHampton.Models
{
    public class ImageViewModel
    {
        [Required]
        public string Title { get; set; }

        public string AltText { get; set; }

        [DataType(DataType.Html)]
        public string Caption { get; set; }

        [DataType(DataType.Upload)]
        public HttpPostedFileBase ImageUpload { get; set; }

        public IEnumerable<SelectListItem> Albums { get; set; }

        [Required]
        [Display(Name = "Album Name")]
        public string AlbumName { get; set; }
    }
}