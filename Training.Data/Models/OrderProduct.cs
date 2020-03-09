﻿using System;

namespace Training.Data.Models
{
    public class OrderProduct
    {
        public Guid Id { get; set; }
        public int Quantity { get; set; }
        public Guid ProductId { get; set; }
        public Guid OrderId { get; set; }

    }
}
