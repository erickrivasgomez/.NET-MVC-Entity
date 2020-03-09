using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Training.API.Contracts;
using Training.Data.Extensions;
using Training.DTO;

namespace Training.Data.Repositories
{
    public class OrdersRepository : IOrdersRepository
    {
        private readonly StoreContext _StoreContext;

        public OrdersRepository(StoreContext storeContext)
        {
            _StoreContext = storeContext;
        }
        public async Task<List<Order>> GetAllOrders()
        {
            var orders = await _StoreContext.Orders.Include(x => x.OrderProducts).ToListAsync();
            var ordersDTOList = orders.Select(x => x.ToDTO()).ToList();
            return ordersDTOList;
        }

        public async Task<Order> Create(DTO.Order order)
        {
            var orderTemp = order.ToDatabaseModel();

            Models.Order orderDB = new Models.Order()
            {
                UserId = orderTemp.UserId,
                OrderProducts = orderTemp.OrderProducts
            };


            var d = await _StoreContext.AddAsync(orderDB);
            await _StoreContext.SaveChangesAsync();
            return d.Entity.ToDTO();
        }

        public async Task<List<Order>> GetOrdersByUser(User user)
        {
            var orders = await _StoreContext.Orders.Include(x => x.OrderProducts).ToListAsync();
            var ordersDTOList = orders.Where(x => x.UserId.ToString().Equals((user.Id))).Select(x => x.ToDTO()).ToList();
            return ordersDTOList;
        }
    }
}
