﻿using System.ComponentModel.DataAnnotations;

namespace ClothingStore.Entities
{
    public class Role : BaseEntity
    {
        [Required]
        [MaxLength(250)]
        public string RoleName { get; set; }

        [Required]
        [MaxLength(250)]
        public string Description { get; set; }

    }
}
