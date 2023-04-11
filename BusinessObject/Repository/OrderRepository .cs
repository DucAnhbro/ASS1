using BusinessObject.Entity;
using Data_Layers;
using Data_Layers.Repository;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repository
{
    public class OrderRepository : IOrderRepository, IDisposable
    {
        private DatabaseContext _context;

        public OrderRepository(DatabaseContext context)
        {
            this._context = context;
        }


        public void Save()
        {
            _context.SaveChanges();
        }

        public void UpdateOrder(OrderDAO order)
        {
            _context.Entry(order).State = EntityState.Modified;
        }

        private bool disposed = false;

        protected virtual void Disposed(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Disposed(true);
            GC.SuppressFinalize(this);
        }

        public IEnumerable<OrderDAO> GetOrders()
        {
            return this._context.Orders.ToList();
        }

        public OrderDAO GetOrderByID(int orderId)
        {
            return this._context.Orders.Find(orderId);
        }

        public void InsertOrder(OrderDAO order)
        {
            _context.Orders.Add(order);
        }

        public void DeleteOrder(int orderID)
        {
            OrderDAO order = _context.Orders.Find(orderID);
            _context.Orders.Remove(order);
        }
    }
}
