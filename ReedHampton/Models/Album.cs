using System;
using System.ComponentModel.DataAnnotations;

namespace ReedHampton.Models
{
    public class Album
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Album Title")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Description")]
        public string Description { get; set; }

        [Required]
        [Display(Name = "Public")]
        public bool IsPublic { get; set; }

        [DataType(DataType.DateTime)]
        [Display(Name = "Date Created")]
        public DateTime? CreatedDate { get; set; }
    }
}