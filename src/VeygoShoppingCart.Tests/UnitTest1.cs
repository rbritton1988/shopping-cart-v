using NUnit.Framework;
using VeygoShoppingCart.Domain.Repository;

namespace VeygoShoppingCart.Tests
{
    public class Tests
    {
        private IVeygoShoppingCartRepo _repo;
        
        [SetUp]
        public void Setup()
        {
            _repo = new MockVeygoShoppingCartRepo();
        }

        [Test]
        public void TestAddingItemToCart()
        {
            Assert.Pass();
        }

        [Test]
        public void TestRemovingItemFromCart()
        {
            Assert.Pass();
        }

        [Test]
        public void TestClearingItemsFromCart()
        {
            Assert.Pass();
        }

        [Test]
        public void TestCalculatingCartItemTotals()
        {
            Assert.Pass();
        }

        [Test]
        public void TestApplyingUniqueDiscountCodesToCart()
        {
            Assert.Pass();
        }

    }
}