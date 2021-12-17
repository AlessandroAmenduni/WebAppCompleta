using ITS.AmenduniA.SampleWebApp.Models;

namespace ITS.AmenduniA.SampleWebApp.Services
{
    public interface IProductsService
    {
        IEnumerable<Product> GetAll();
        Product? GetById(int id);
        void Insert(Product p);
        void Update(Product p);
        void Delete(Product p);
    }
}