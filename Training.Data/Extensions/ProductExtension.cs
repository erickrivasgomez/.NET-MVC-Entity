using System;
using System.Collections.Generic;
using System.Text;

namespace Training.Data.Extensions
{
    public static class ProductExtension
    {
        public static DTO.Product ToDTO(this Models.Product u)
        {
            return new DTO.Product
            {
                Id = u.Id.ToString(),
                Name = u.Name,
                Price = u.Price
            };
        }

        public static Models.Product ToDatabaseModel(this DTO.Product u)
        {
            return new Models.Product
            {
                Id = Guid.Parse(u.Id),
                Name = u.Name,
                Price = u.Price
            };
        }
    }
}
