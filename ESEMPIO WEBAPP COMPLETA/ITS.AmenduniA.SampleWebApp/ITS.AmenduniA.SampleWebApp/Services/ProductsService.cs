using ITS.AmenduniA.SampleWebApp.Models;

namespace ITS.AmenduniA.SampleWebApp.Services
{
    public class ProductsService : IProductsService
    {
        private readonly List<Product> _products;


        public ProductsService()
        {
            _products = new List<Product>();
            for (int i = 0; i < 10; i++)
            {
                _products.Add(new Product
                {
                    Name = $"Prodotto{i}",
                    Price = i,
                    Id = i
                });

            }
        }

        //IEnumerable => ritorno una lista di prodotti
        public IEnumerable<Product> GetAll()
        {
            return _products;
        }

        public Product? GetById(int id)
        {
            return _products.FirstOrDefault(x => x.Id == id);
        }

        public void Insert(Product p)
        {
            _products.Add(p);
        }

        public void Update(Product p)
        {
            var product = _products.FirstOrDefault(x => x.Id == p.Id);  //prende il prodotto ad un determinato id
            
            if(p != null)
            {
                product.Name = p.Name;
                product.Price = p.Price;
            }
        }

        public void Delete(Product p)
        {
            var product = _products.FirstOrDefault(x => x.Id == p.Id);

            if (product != null)
            {
                _products.Remove(product);
            }
        }
    }
}
