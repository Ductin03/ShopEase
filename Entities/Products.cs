﻿using System.ComponentModel.DataAnnotations;

namespace ClothingStore.Entities
{
    public class Products : BaseEntity
    {
        [Required]
        [MaxLength(250)]
        public string ProductName { get; set; }

        [Required]
        [MaxLength(250)]
        public string Description { get; set; }

        [Required]
        public Guid CategoryId { get; set; }

        [Required]
        public Guid SellerId { get; set; }

        [Required]
        public Decimal Price { get; set; }



    }
}
