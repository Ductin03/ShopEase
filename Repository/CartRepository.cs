﻿using ClothingStore.Entities;
using Microsoft.EntityFrameworkCore;
using ShopEase.Entities;
using ShopEase.Models.ResponseModel;

namespace ShopEase.Repository
{
    public class CartRepository : ICartRepository
    {
        private readonly ShopEaseDbContext _context;
        public CartRepository(ShopEaseDbContext context)
        {
            _context = context;
        }
        public Task AddCart(AddCart addCart)
        {
            _context.AddCarts.Add(addCart);
            return Task.FromResult(true);
        }

        public async Task<CartSumResponseModel> GetCart(Guid userid)
        {
            var cart = await (from c in _context.AddCarts
                              join p in _context.Products on c.ProductId equals p.Id
                              where c.UserId == userid
                              select new
                              {
                                  CartId = c.Id,
                                  ProductId = c.ProductId,
                                  Price = c.Price,
                                  ProductName = p.ProductName,
                                  TotalPrice = c.Price * c.Quantity,
                                  Quantity = c.Quantity
                              }).ToListAsync();


            List<CartResponseModel> res = new List<CartResponseModel>();

            decimal totalPrice = 0;

            foreach (var item in cart)
            {
                res.Add(new CartResponseModel
                {
                    CartId = item.CartId,
                    ProductId = item.ProductId,
                    Quantity = item.Quantity,
                    Price = item.Price,
                    ProductName = item.ProductName

                });
                totalPrice += item.TotalPrice;

            }
            var response = new CartSumResponseModel
            {
                CartResponseModels = res,
                TotalPrice = totalPrice

            };

            return response;
        }

        public async Task<AddCart> GetByProductId(Guid id)
        {
            return await _context.AddCarts.FirstOrDefaultAsync(x=>x.ProductId==id);
        }

        public Task UpdateCart(AddCart updateCart)
        {
            _context.AddCarts.Update(updateCart);
            return Task.FromResult(true);
        }

    }
}
