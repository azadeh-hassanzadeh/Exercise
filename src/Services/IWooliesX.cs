using System.Collections.Generic;
using System.Threading.Tasks;
using Exercise.Models;

namespace Exercise.Services
{
    public interface IWooliesX
    {
        Task<IList<Product>> GetSortedProducts(SortOption sortOption);
        Task<IList<Product>> GetProducts();
    }
}