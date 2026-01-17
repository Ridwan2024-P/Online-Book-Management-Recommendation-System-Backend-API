using BLL.DTOs;
using DAL.EF.Models;
using DAL.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class OrderService
    {
        OrderRepo repo;
        public OrderService(OrderRepo repo)
        {
            this.repo = repo;

        }

        public List<OrderDTO> Get()
        {
            var data = repo.Get();
            var mapper = MapperConfig.GetMapper();
            var ret = mapper.Map<List<OrderDTO>>(data);
            return ret;


        }
        public OrderDTO Get(int id)
        {
            var data = repo.Get(id);
            var mapper = MapperConfig.GetMapper();
            var ret = mapper.Map<OrderDTO>(data);
            return ret;



        }

        public bool Create(OrderDTO order)
        {
            var mapper = MapperConfig.GetMapper();
            var data = mapper.Map<Order>(order);
            return repo.Create(data);
        }
        public bool Delete(int id)
        {
            repo.delete(id);
            return true;
        }
        public bool Update(OrderDTO order)
        {
            var mapper = MapperConfig.GetMapper();
            var data = mapper.Map<Order>(order);
            return repo.update(data);
        }




        public List<OrderDTO> GetOrdersCount()
        {
            var data = repo.Get();
            var ret = new List<OrderDTO>();

            foreach (var o in data)
            {
                ret.Add(new OrderDTO
                {
                    Id = o.Id,
                    UserId = o.UserId,
                    BookId = o.BookId,
                    Quantity = o.Quantity,
                    TotalPrice = o.TotalPrice,
                    Status = o.Status,
                    OrderDate = o.OrderDate
                });
            }

            return ret;
        }
        public SummaryDTO GetDailySales()
        {
            DateTime today = DateTime.Today;
            return GetSalesSummary(today, today.AddDays(1).AddTicks(-1));
        }
        private SummaryDTO GetSalesSummary(DateTime start, DateTime end)
        {
            return new SummaryDTO
            {
               
                TotalSales = repo.GetTotalSales(start, end)
            };
        }

        public BillDTO GenerateBill(int orderId)
        {
            Order order = repo.GetOrderWithDetails(orderId);

            if (order == null)
                return null;

            if (order.Quantity <= 0)
                throw new Exception("Invalid quantity. Quantity must be greater than zero.");

            return new BillDTO
            {
                OrderId = order.Id,
                CustomerName = order.User.Name,
                BookTitle = order.Book.Title,
                Quantity = order.Quantity,
                UnitPrice = order.TotalPrice / order.Quantity,
                TotalPrice = order.TotalPrice,
                OrderDate = order.OrderDate,
                PaymentStatus = order.Status
            };
        }


    }
}
