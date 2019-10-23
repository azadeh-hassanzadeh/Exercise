using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Exercise.Models;
using Exercise.Services;
using Xunit;

namespace Exercise.UnitTests
{
    public class WooliesxTests
    {
        
        [Fact]
        public async Task Should_ReturnLowToHighPrice_When_SortOptionIsLow()
        {
            //Arrange
            var products = new List<Product>
            {
                new Product() {Name = "A", Price = (decimal) 5.0, Quantity = (decimal) 1.0},
                new Product() {Name = "C", Price = (decimal) 10.0, Quantity = (decimal) 1.0},
                new Product() {Name = "B", Price = (decimal) 2.0, Quantity = (decimal) 1.0}
            };
            var wooliesxMock = new Mock<IWooliesX>();
            wooliesxMock.Setup(m => m.GetProducts()).ReturnsAsync(products);
            
            //Act
            var wooliesx = new WooliesX();
            var actual = await wooliesx.GetSortedProducts(SortOption.Low);
            
            var expected = new List<Product>
            {
                new Product() {Name = "B", Price = (decimal) 2.0, Quantity = (decimal) 1.0},
                new Product() {Name = "A", Price = (decimal) 5.0, Quantity = (decimal) 1.0},
                new Product() {Name = "C", Price = (decimal) 10.0, Quantity = (decimal) 1.0}
            };
            
            // Assert
            Assert.Equal(expected, actual);
        }
        
        
        [Fact]
        public async Task Should_ReturnLowToHighPrice_When_SortOptionIsHigh()
        {
            //Arrange
            var products = new List<Product>
            {
                new Product() {Name = "A", Price = (decimal) 5.0, Quantity = (decimal) 1.0},
                new Product() {Name = "C", Price = (decimal) 10.0, Quantity = (decimal) 1.0},
                new Product() {Name = "B", Price = (decimal) 2.0, Quantity = (decimal) 1.0}
            };
            var wooliesxMock = new Mock<IWooliesX>();
            wooliesxMock.Setup(m => m.GetProducts()).ReturnsAsync(products);
            
            //Act
            var wooliesx = new WooliesX();
            var actual = await wooliesx.GetSortedProducts(SortOption.Low);
            
            var expected = new List<Product>
            {
                new Product() {Name = "C", Price = (decimal) 2.0, Quantity = (decimal) 1.0},
                new Product() {Name = "A", Price = (decimal) 5.0, Quantity = (decimal) 1.0},
                new Product() {Name = "B", Price = (decimal) 10.0, Quantity = (decimal) 1.0}
            };
            
            // Assert
            Assert.Equal(expected, actual);
        }
    }
}