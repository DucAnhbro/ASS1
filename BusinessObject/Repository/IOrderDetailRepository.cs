
using DataAccess;

namespace Data_Layers.Repository
{
    public interface IOrderDetailRepository : IDisposable
    {
        IEnumerable<OrderDetailDAO> GetOrderDetails();
        OrderDetailDAO GetOrderDetailByID(int orderId, int productId);
        void InsertOrderDetail(OrderDetailDAO orderDetail);
        void DeleteOrderDetail(int orderID, int productID);
        void UpdateOrderDetail(OrderDetailDAO OrderDetail);
        void Save();
    }
}
