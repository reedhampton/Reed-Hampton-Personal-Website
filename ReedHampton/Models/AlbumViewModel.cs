using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ReedHampton.Models
{
    public class AlbumViewModel
    {
        [Display(Name = "Album Title")]
        public string Name { get; set; }

        [DataType(DataType.Html)]
        [Display(Name = "Description")]
        public string Description { get; set; }

        [Required]
        [Display(Name = "Public")]
        public bool IsPublic { get; set; }

        [DataType(DataType.Upload)]
        [Display(Name = "Thumbnail")]
        public HttpPostedFileBase AlbumThumbnailUpload { get; set; }

    }
}