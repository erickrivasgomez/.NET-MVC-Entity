namespace Training.Data.Extensions
{
    public static class OrderExtension
    {
        public static DTO.Order ToDTO(this Models.Order u)
        {
            return new DTO.Order
            {
                Id = u.Id.ToString(),
                UserId = u.UserId.ToString()
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
                UserId = Guid.Parse(u.UserId),
                OrderProducts = orderProductsModel
            };
        }
    }
}