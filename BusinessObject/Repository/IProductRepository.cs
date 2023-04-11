
using DataAccess;

namespace Data_Layers.Repository
{
    public interface IProductRepository : IDisposable
    {
        IEnumerable<ProductDAO> GetProducts();
        ProductDAO GetProductByID(int productId);
        void InsertProduct(ProductDAO product);
        void DeleteProduct(int productID);
        void UpdateProduct(ProductDAO product);
        void Save();
    }
}
