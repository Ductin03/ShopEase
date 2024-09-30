﻿using ClothingStore.Entities;

namespace ShopEase.Entities
{
    public class OderDetails : BaseEntity
    {
        public Guid OderId { get; set; }
        public Guid ProductId { get; set; }
        public Decimal Price { get; set; }
        public int Quantity { get; set; }
    }
}
