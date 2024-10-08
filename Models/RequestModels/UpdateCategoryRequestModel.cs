﻿using System.ComponentModel.DataAnnotations;

namespace ShopEase.Models.RequestModels
{
    public class UpdateCategoryRequestModel
    {
        [Required]
        public Guid CategoryId { get; set; }
        [Required]
        [MaxLength(250)]
        public string CategoryName { get; set; }
        [Required]
        [MaxLength(250)]
        public string Description { get; set; }
        [Required]
        public Guid SubCategoryId { get; set; }
        [Required]
        public DateTime UpdatedOn { get; set; }
        [Required]
        public Guid UpdatedBy { get; set; }

    }
}
