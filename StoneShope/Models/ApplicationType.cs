﻿using System.ComponentModel.DataAnnotations;

namespace StoneShope.Models
{
    public class ApplicationType
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
