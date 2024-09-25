using Microsoft.AspNetCore.Mvc;
using ShopEase.Entities;
using System.ComponentModel.DataAnnotations;

namespace ShopEase.Models.RequestModels
{
    public class CreateProductRequestModel
    {
        public string ProductName { get; set; }
        public string Description { get; set; }
        public Guid CategoryId { get; set; }
        public Guid SellerId { get; set; }
        public Decimal Price { get; set; }
        public DateTime CreateDate { get; set; }
        public Guid CreateBy { get; set; }
        public DateTime? UpdateDate { get; set; }
        public Guid? UpdateBy { get; set; }
        public bool IsDeleted { get; set; }
    }
}
