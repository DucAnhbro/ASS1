
namespace Data_Layers.Repository
{
    public interface IOrderRepository : IDisposable
    {
        IEnumerable<OrderDAO> GetOrders();
        OrderDAO GetOrderByID(int orderId);
        void InsertOrder(OrderDAO order);
        void DeleteOrder(int orderID);
        void UpdateOrder(OrderDAO order);
        void Save();
    }
}
