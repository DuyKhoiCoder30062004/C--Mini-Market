
using MiniStore.Modules.OrderManager.Dtos;
using MiniStore.Modules.OrderManager.Repository;


namespace MiniStore.Modules.OrderManager.Services
{
    internal class OrderService
    {
        private readonly OrderRepository repository;
        public OrderService() { 
           this.repository = new OrderRepository();
        }
        public void LoadOrderData()
        {
        }

        public void SearchOrder(string keySearch)
        {
        }

        public void DeleteOrder(string orderId)
        {
        }

        public void CreateOrder(OrderDto order)
        {
        }

        public void UpdateOrder(OrderDto order)
        {
        }

        public void GetOrderById(string orderId)
        {
        }

        public void DeleteManyOrder(List<string> ids)
        {
        }

        public void ReportOrder(DateTime timeStart, DateTime timeEnd)
        {
        }

        public void FilterOrder(OrderFilterValues filterValues)
        {
        }
    }
}
