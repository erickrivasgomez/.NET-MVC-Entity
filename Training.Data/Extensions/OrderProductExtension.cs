using System;
using System.Collections.Generic;

namespace Training.Data.Extensions
{
    public static class OrderProductExtension
    {
        
        public static DTO.OrderProduct ToDTO(this Models.OrderProduct orderProduct)
        {
            return new DTO.OrderProduct
            {
                Id = orderProduct.Id.ToString(),
                Quantity = orderProduct.Quantity,
                Product = orderProduct.Product.ToDTO()
            };
        }
        public static Models.OrderProduct ToDatabaseModel(this DTO.OrderProduct u)
        {
            return new Models.OrderProduct
            {
                Id = Guid.Parse(u.Id),
                Quantity = u.Quantity,
                Product = u.Product.ToDatabaseModel(),
                Order = new Models.Order()
            };
        }
    }
}
