using Business.Entities;
using Business.Interfaces;
using Business.Services;
using Xunit;

namespace Supermarket_Pricing.Test
{
    public class OrderTest
    {
        [Fact]
        public void GetBasePriceTest()
        {
            //Arrange
            IBasePriceCalculator calculator = new BasePriceCalculator();
            Product product = new Product
            {
                Id = 1,
                Name = "Can of soup",
                QuantityInStock = 1,
                UnitPrice = 1
            };
            Order order = new Order(calculator)
            {
                Id = 1,
                Product = product,
                Quantity = 2
            };

            //Act
            decimal price = order.GetPrice();

            //Assert
            Assert.Equal(2, price);
        }

        [Fact]
        public void GetThreeForTwoPriceWithDiscountTest()
        {
            //Arrange
            IBasePriceCalculator calculator = new ThreeForTwoCalculator();
            Product product = new Product
            {
                Id = 1,
                Name = "Can of soup",
                QuantityInStock = 1,
                UnitPrice = 1
            };
            Order order = new Order(calculator)
            {
                Id = 1,
                Product = product,
                Quantity = 5
            };

            //Act
            decimal price = order.GetPrice();

            //Assert
            Assert.Equal(4, price);
        }

        [Fact]
        public void GetThreeForTwoPriceWithoutDiscountTest()
        {
            //Arrange
            IBasePriceCalculator calculator = new ThreeForTwoCalculator();
            Product product = new Product
            {
                Id = 1,
                Name = "Can of soup",
                QuantityInStock = 1,
                UnitPrice = 1
            };
            Order order = new Order(calculator)
            {
                Id = 1,
                Product = product,
                Quantity = 2
            };

            //Act
            decimal price = order.GetPrice();

            //Assert
            Assert.Equal(2, price);
        }
    }
}
