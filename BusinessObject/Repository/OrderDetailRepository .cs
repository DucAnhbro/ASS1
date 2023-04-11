using BusinessObject.Entity;
using Data_Layers;
using Data_Layers.Repository;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repository
{
    public class OrderDetailRepository : IOrderDetailRepository, IDisposable
    {
        private DatabaseContext _context;

        public OrderDetailRepository(DatabaseContext context)
        {
            this._context = context;
        }


        public void Save()
        {
            _context.SaveChanges();
        }

        public void UpdateOrderDetail(OrderDetailDAO orderDatail)
        {
            _context.Entry(orderDatail).State = EntityState.Modified;
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

        public IEnumerable<OrderDetailDAO> GetOrderDetails()
        {
            return this._context.OrderDetails.ToList();
        }

        public OrderDetailDAO GetOrderDetailByID(int orderId, int productId)
        {
            return this._context.OrderDetails.First(x => x.OrderId == orderId && x.ProductId == productId);
        }

        public void InsertOrderDetail(OrderDetailDAO orderDeatil)
        {
            _context.OrderDetails.Add(orderDeatil);
        }

        public void DeleteOrderDetail (int orderID, int productID)
        {
            OrderDetailDAO order = _context.OrderDetails.FirstOrDefault(x => x.OrderId == orderID && x.ProductId == productID);
            _context.OrderDetails.Remove(order);
        }

    }
}
