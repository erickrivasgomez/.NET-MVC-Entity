using System;
using System.Collections.Generic;

namespace Training.Data.Extensions
{
    public static class OrderExtension
    {
        public static DTO.Order ToDTO(this Models.Order u)
        {
            List<DTO.OrderProduct> orderProductsDTO = new List<DTO.OrderProduct>();
            foreach (Models.OrderProduct orderProduct in u.OrderProducts)
            {
                orderProductsDTO.Add(orderProduct.ToDTO());
            }

            return new DTO.Order
            {
                Id = u.Id.ToString(),
                UserId = u.UserId.ToString(),
                OrderProducts = orderProductsDTO
            };
        }

        public static Models.Order ToDatabaseModel(this DTO.Order u)
        {
            List<Models.OrderProduct> orderProductsModel = new List<Models.OrderProduct>();
            foreach (DTO.OrderProduct orderProduct in u.OrderProducts)
            {
                orderProductsModel.Add(orderProduct.ToDatabaseModel());
            }

            return new Models.Order
            {
                Id = Guid.Parse(u.Id),
                UserId = Guid.Parse(u.UserId),
                OrderProducts = orderProductsModel
            };
        }
    }
}