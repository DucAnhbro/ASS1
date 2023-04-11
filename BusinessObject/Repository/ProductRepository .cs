using BusinessObject.Entity;
using Data_Layers;
using Data_Layers.Repository;
using Microsoft.EntityFrameworkCore;


namespace DataAccess.Repository
{
    public class ProductRepository : IProductRepository, IDisposable
    {
        private DatabaseContext _context;

        public ProductRepository(DatabaseContext context)
        {
            this._context = context;
        }
        public void DeleteProduct(int productID)
        {
            ProductDAO product = _context.Products.Find(productID);
            _context.Products.Remove(product);
        }

        public ProductDAO GetProductByID(int productId)
        {
            return _context.Products.Find(productId);
        }

        public IEnumerable<ProductDAO> GetProducts()
        {
            return _context.Products.ToList();
        }

        public void InsertProduct(ProductDAO product)
        {
            _context.Products.Add(product);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void UpdateProduct(ProductDAO product)
        {
            _context.Entry(product).State = EntityState.Modified;
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
    }
}
