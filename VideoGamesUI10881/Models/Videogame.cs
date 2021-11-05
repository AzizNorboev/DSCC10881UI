using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VideoGamesUI10881.Models
{
    public class Videogame
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Genre { get; set; }

        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Price must be a numeric value (i. e. 20.99)")]
        public string Price { get; set; }
        [Required]
        public string Publisher { get; set; }
    }
}