using Uncorkd_BLL.Collections;

namespace Uncorkd_Test.Tests
{
    [TestClass]
    public class ReviewTests
    {
        private readonly ReviewCollection _reviewCollection = new();
        private readonly int test_user_id = 99;
        private readonly int test_wine_id = 99;


        [TestMethod]
        public void UC01HappyFlow()
        {
            // Arrange
            double test = 3.75;
            int stars = 15;
            string tasteTags = "1, 2, 3, 4, 5";
            string comment = "this wine tastes like a test";

            // Act
            bool result = _reviewCollection.Create(2, 1, 5, "1, 2", "test");

            // Assert
            Assert.IsTrue(result);
        }
    }
}