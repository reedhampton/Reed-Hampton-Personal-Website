using System;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace ReedHampton.Models
{
    public class Image
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int AlbumId { get; set; }

        [Required]
        public string Title { get; set; }

        public string AltText { get; set; }

        [DataType(DataType.Html)]
        public string Caption { get; set; }

        [DataType(DataType.ImageUrl)]
        public string ImageUrl { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime? CreatedDate { get; set; }
    }
}