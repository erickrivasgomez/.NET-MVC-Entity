using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Training.API.Contracts;
using Training.DTO;
using Training.Data.Extensions;

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
            var orders = await _StoreContext.Orders.ToListAsync();
            var ordersDTOList = orders.Select(x => x.ToDTO()).ToList();
            return ordersDTOList;
        }
    }
}
