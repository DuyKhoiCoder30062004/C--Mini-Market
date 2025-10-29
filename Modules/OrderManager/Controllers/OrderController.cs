namespace MiniStore.Modules.OrderManager.Controllers
{
    using MiniStore.Modules.OrderManager.Dtos;
    using MiniStore.Modules.OrderManager.Services;
    using System;
    using System.Collections.Generic;

        internal class OrderController
    {
                private readonly OrderService orderService;

                public OrderController()
        {
            orderService = new OrderService();
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
