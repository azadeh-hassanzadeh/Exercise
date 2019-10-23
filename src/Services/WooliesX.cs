using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Exercise.Extensions;
using Exercise.Models;
using Flurl;
using Flurl.Http;
using Newtonsoft.Json.Linq;

namespace Exercise.Services
{
    public class WooliesX : IWooliesX
    {
        private readonly IConfigDetails _configDetails;

        public WooliesX()
        {
        }

        public WooliesX(IConfigDetails configDetails)
        {
            _configDetails = configDetails;
        }

        public async Task<IList<Product>> GetSortedProducts(SortOption sortOption)
        {
            if (sortOption == SortOption.Recommended) return await GetShopperHistory();

            var products = await GetProducts();
            switch (sortOption)
            {
                case SortOption.Low:
                    return products.OrderBy(x => x.Price).ToList();
                case SortOption.High:
                    return products.OrderByDescending(x => x.Price).ToList();
                case SortOption.Ascending:
                    return products.OrderBy(x => x.Name).ToList();
                case SortOption.Descending:
                    return products.OrderByDescending(x => x.Name).ToList();
                default:
                    return products.OrderBy(x => x.Price).ToList();
            }
        }

        public async Task<IList<Product>> GetProducts()
        {
            var products = await $"{_configDetails.GetResourceBaseUrl()}".AppendPathSegment("products")
                .SetQueryParam("token", _configDetails.GetUserDetails().Token)
                .AllowAnyHttpStatus().GetAsync().DeserializeObject<IList<Product>>();

            return products;
        }

        public async Task<IList<Product>> GetShopperHistory()
        {
            var history = await $"{_configDetails.GetResourceBaseUrl()}".AppendPathSegment("shopperHistory")
                .SetQueryParam("token", _configDetails.GetUserDetails().Token)
                .AllowAnyHttpStatus().GetAsync().DeserializeObject<IList<ShopperHistory>>();

            var maxOccurenceCustomerId = history.GroupBy(x => x.CustomerId)
                .OrderByDescending(x => x.Count())
                .First().Key;
            var products = new List<Product>();
            var customerProducts = history.Where(x => x.CustomerId == maxOccurenceCustomerId);
            foreach (var customerProduct in customerProducts) products.AddRange(customerProduct.Products);
            return products;
        }


        public async Task<decimal> GetTrolleyTotal(JObject trolley)
        {
            var trolleyTotal = await $"{_configDetails.GetResourceBaseUrl()}".AppendPathSegment("trolleyCalculator")
                .SetQueryParam("token", _configDetails.GetUserDetails().Token)
                .AllowAnyHttpStatus().PostJsonAsync(trolley)
                .DeserializeObject<decimal>();

            return trolleyTotal;
        }
    }
}