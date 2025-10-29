using MiniStore.Modules.OrderManager.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniStore.Modules.OrderManager.Repository
{
    public class OrderRepository
    {



        public OrderDto ToOrderDto() {

            return new OrderDto(); }
     

      public void Insert(OrderDto orderDto) { }
        public void Update(OrderDto orderDto) {
        }
        public void Delete(OrderDto orderDto) { }
        public List<OrderDto> GetAll() {
            return new List<OrderDto>();
        }
        public void GetOrderById() { }

        public void FilterOrder(OrderFilterValues filterValues ) { }

        public void UpdateProductStock() { }

    }
}
