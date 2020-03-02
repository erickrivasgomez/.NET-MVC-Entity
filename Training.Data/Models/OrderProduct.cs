using System;

namespace Training.Data.Models
{
    public class OrderProduct
    {
        public Guid Id { get; set; }
        public int Quantity { get; set; }
        public Product Product { get; set; }

    }
}
