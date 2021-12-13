using Business.Entities;
using Business.Interfaces;
using Business.Services;
using Xunit;

namespace Supermarket_Pricing.Test
{
    public class CartTest
    {
        [Fact]
        public void GetBaseTotalWithOneProductTest()
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

            Cart cart = new Cart() { 
                Orders = new[] { order }
            };    
            //Act
            decimal price = cart.GetTotal();

            //Assert
            Assert.Equal(2, price);
        }

        [Fact]
        public void GetBaseTotalWithMultipleProductTest()
        {
            //Arrange
            IBasePriceCalculator calculator = new BasePriceCalculator();
            Product product1 = new Product
            {
                Id = 1,
                Name = "Can of soup",
                QuantityInStock = 1,
                UnitPrice = 1
            };
            Product product2 = new Product
            {
                Id = 2,
                Name = "Bottle of milk",
                QuantityInStock = 2,
                UnitPrice = 2
            };
            Order order1 = new Order(calculator)
            {
                Id = 1,
                Product = product1,
                Quantity = 2
            };

            Order order2 = new Order(calculator)
            {
                Id = 2,
                Product = product2,
                Quantity = 3
            };

            Cart cart = new Cart()
            {
                Orders = new[] { order1, order2 }
            };
            //Act
            decimal price = cart.GetTotal();

            //Assert
            Assert.Equal(8, price);
        }

        [Fact]
        public void GetThreeForTwoTotalWithOneProductWithDiscountTest()
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
                Quantity = 3
            };

            Cart cart = new Cart()
            {
                Orders = new[] { order }
            };
            //Act
            decimal price = cart.GetTotal();

            //Assert
            Assert.Equal(2, price);
        }

        [Fact]
        public void GetThreeForTwoTotalWithMultipleProductsWithDiscountTest()
        {
            //Arrange
            IBasePriceCalculator calculator = new ThreeForTwoCalculator();
            Product product1 = new Product
            {
                Id = 1,
                Name = "Can of soup",
                QuantityInStock = 1,
                UnitPrice = 1
            };
            Product product2 = new Product
            {
                Id = 2,
                Name = "Bottle of milk",
                QuantityInStock = 2,
                UnitPrice = 2
            };
            Order order1 = new Order(calculator)
            {
                Id = 1,
                Product = product1,
                Quantity = 2
            };

            Order order2 = new Order(calculator)
            {
                Id = 2,
                Product = product2,
                Quantity = 3
            };

            Cart cart = new Cart()
            {
                Orders = new[] { order1, order2 }
            };
            //Act
            decimal price = cart.GetTotal();

            //Assert
            Assert.Equal(6, price);
        }

        [Fact]
        public void GetThreeForTwoTotalWithOneProductWithoutDiscountTest()
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

            Cart cart = new Cart()
            {
                Orders = new[] { order }
            };
            //Act
            decimal price = cart.GetTotal();

            //Assert
            Assert.Equal(2, price);
        }

        [Fact]
        public void GetThreeForTwoTotalWithMultipleProductsWithoutDiscountTest()
        {
            //Arrange
            IBasePriceCalculator calculator = new ThreeForTwoCalculator();
            Product product1 = new Product
            {
                Id = 1,
                Name = "Can of soup",
                QuantityInStock = 1,
                UnitPrice = 1
            };
            Product product2 = new Product
            {
                Id = 2,
                Name = "Bottle of milk",
                QuantityInStock = 2,
                UnitPrice = 2
            };
            Order order1 = new Order(calculator)
            {
                Id = 1,
                Product = product1,
                Quantity = 2
            };

            Order order2 = new Order(calculator)
            {
                Id = 2,
                Product = product2,
                Quantity = 1
            };

            Cart cart = new Cart()
            {
                Orders = new[] { order1, order2 }
            };
            //Act
            decimal price = cart.GetTotal();

            //Assert
            Assert.Equal(4, price);
        }

        [Fact]
        public void GetMixedStrategyPriceWithDiscountTest()
        {
            //Arrange
            IBasePriceCalculator baseCalculator = new BasePriceCalculator();
            IBasePriceCalculator threeForTwoCalculator = new ThreeForTwoCalculator();
            Product product1 = new Product
            {
                Id = 1,
                Name = "Can of soup",
                QuantityInStock = 1,
                UnitPrice = 1
            };
            Product product2 = new Product
            {
                Id = 2,
                Name = "Bottle of milk",
                QuantityInStock = 2,
                UnitPrice = 2
            };
            Order order1 = new Order(baseCalculator)
            {
                Id = 1,
                Product = product1,
                Quantity = 2
            };

            Order order2 = new Order(threeForTwoCalculator)
            {
                Id = 2,
                Product = product2,
                Quantity = 7
            };

            Cart cart = new Cart()
            {
                Orders = new[] { order1, order2 }
            };
            //Act
            decimal price = cart.GetTotal();

            //Assert
            Assert.Equal(12, price);
        }

        [Fact]
        public void GetMixedStrategyPriceWithoutDiscountTest()
        {
            //Arrange
            IBasePriceCalculator baseCalculator = new BasePriceCalculator();
            IBasePriceCalculator threeForTwoCalculator = new ThreeForTwoCalculator();
            Product product1 = new Product
            {
                Id = 1,
                Name = "Can of soup",
                QuantityInStock = 1,
                UnitPrice = 1
            };
            Product product2 = new Product
            {
                Id = 2,
                Name = "Bottle of milk",
                QuantityInStock = 2,
                UnitPrice = 2
            };
            Order order1 = new Order(baseCalculator)
            {
                Id = 1,
                Product = product1,
                Quantity = 2
            };

            Order order2 = new Order(threeForTwoCalculator)
            {
                Id = 2,
                Product = product2,
                Quantity = 1
            };

            Cart cart = new Cart()
            {
                Orders = new[] { order1, order2 }
            };
            //Act
            decimal price = cart.GetTotal();

            //Assert
            Assert.Equal(4, price);
        }

        [Fact]
        public void GetMixedStrategyPriceWithDiscountsTest()
        {
            //Arrange
            IBasePriceCalculator baseCalculator = new BasePriceCalculator();
            IBasePriceCalculator threeForTwoCalculator = new ThreeForTwoCalculator();
            IBasePriceCalculator quantityBaseDiscountCalculator = new QuantityBaseDiscountCalculator();
            Product product1 = new Product
            {
                Id = 1,
                Name = "Can of soup",
                QuantityInStock = 1,
                UnitPrice = 1
            };
            Product product2 = new Product
            {
                Id = 2,
                Name = "Bottle of milk",
                QuantityInStock = 2,
                UnitPrice = 2
            };
            Product product3 = new Product
            {
                Id = 3,
                Name = "Bottle of juice",
                QuantityInStock = 15,
                UnitPrice = 3
            };
            Order order1 = new Order(baseCalculator)
            {
                Id = 1,
                Product = product1,
                Quantity = 2
            };

            Order order2 = new Order(threeForTwoCalculator)
            {
                Id = 2,
                Product = product2,
                Quantity = 7
            };

            Order order3 = new Order(quantityBaseDiscountCalculator)
            {
                Id = 3,
                Product = product3,
                Quantity = 13
            };

            Cart cart = new Cart()
            {
                Orders = new[] { order1, order2, order3 }
            };
            //Act
            decimal price = cart.GetTotal();

            //Assert
            Assert.Equal(43.2M, price);
        }

    }
}
