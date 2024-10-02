using Microsoft.AspNetCore.Mvc;
using ShopEase.Entities;
using System.ComponentModel.DataAnnotations;

namespace ShopEase.Models.RequestModels
{
    public class CreateProductRequestModel
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
        [Range(1, int.MaxValue)]
        public int Quantity { get; set; }
        [Required]
        public Guid SellerId { get; set; }
        [Required]
        [Range(0, int.MaxValue)]
        public Decimal Price { get; set; }
        [Required]
        public DateTime CreatedOn { get; set; }
        [Required]
        public Guid CreatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public Guid? UpdatedBy { get; set; }
        [Required]
        public bool IsDeleted { get; set; }
    }
}
