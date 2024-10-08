﻿using System.ComponentModel.DataAnnotations;

namespace ShopEase.Models.RequestModels
{
    public class AddCartRequestModel
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        public Guid ProductId { get; set; }
        [Required]
        public Guid UserId { get; set; }
        [Required]
        [Range(0, int.MaxValue)]
        public Decimal Price { get; set; }
        [Range(0, int.MaxValue)]
        [Required]
        public int Quantity { get; set; }
        [Required]
        public DateTime CreatedOn { get; set; }
        [Required]
        public Guid CreatedBy { get; set; }
        [Required]
        public bool IsDeleted { get; set; }
    }
}
