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
                ProductId = orderProduct.ProductId.ToString()
            };
        }
        public static Models.OrderProduct ToDatabaseModel(this DTO.OrderProduct u)
        {
            Models.OrderProduct nueva = new Models.OrderProduct
            {
                Quantity = u.Quantity,
                ProductId = Guid.Parse(u.ProductId)
            };
            var nueva2 = nueva;
            return nueva;
        }
    }
}
