using DAL.EF;
using DAL.EF.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    public class OrderRepo
    {
        PMSContext db;
        public OrderRepo(PMSContext db)
        {
            this.db = db;
        }

        public bool Create(Order order)
        {
            db.Orders.Add(order);
            return db.SaveChanges() > 0;
        }

        public List<Order> Get()
        {
            return db.Orders.ToList();
        }

        public Order Get(int id)
        {
            return db.Orders.Find(id);
        }
        public bool update(Order order)
        {
            var ex = Get(order.Id);
            db.Entry(ex).CurrentValues.SetValues(order);
            return db.SaveChanges() > 0;

        }
        public bool delete(int id)
        {
            var ex = Get(id);
            db.Orders.Remove(ex);
            return db.SaveChanges() > 0;
        }



        public int GetOrdersCount(DateTime start, DateTime end)
        {
            return db.Orders.Count(o => o.Status == "Completed"    &&   o.OrderDate >= start     && o.OrderDate <= end);
        }
        

        public decimal GetTotalSales(DateTime start, DateTime end)
        {
            return db.Orders
                     .Where(o => o.OrderDate >= start && o.OrderDate <= end)
                     .Sum(o => o.TotalPrice);
        }

        public Order GetOrderWithDetails(int orderId)
        {
            return db.Orders
                     .Include(o => o.User)
                     .Include(o => o.Book)
                     .FirstOrDefault(o => o.Id == orderId);
        }






    }
}
