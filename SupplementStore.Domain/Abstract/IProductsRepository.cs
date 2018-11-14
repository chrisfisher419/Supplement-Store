using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SupplementStore.Domain.Entities;
using System.Collections.Generic;


namespace SupplementStore.Domain.Abstract
{
   public interface IProductRepository
    {
        IEnumerable<Product> Products { get; }
        void SaveProduct(Product product);
        Product DeleteProduct(int productID);
    }
}
