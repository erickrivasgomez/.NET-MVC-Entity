using System;
using System.Collections.Generic;
using System.Text;

namespace Training.API.Operations.Orders
{
    public class GetAllOrders
    {
        private readonly IOrdersRepository _OrdersRepository;

        public GetAll(IOrdersRepository ordersRepository)
        {
            _OrdersRepository = ordersRepository;
        }

        public async Task<List<DTO.Order>> Execute()
        {
            return await _OrdersRepository.GetAll();
        }
    }
}
