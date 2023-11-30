using Uncorkd_BLL.Collections;
using Uncorkd_Test.Repos;

namespace Uncorkd_Test.Tests
{
    [TestClass]
    public class ReviewTests
    {
        private readonly ReviewRepo _reviewRepo = new();

        private readonly int test_user_id = 99;
        private readonly int test_wine_id = 99;


        [TestMethod]
        public void UC01HappyFlow()
        {
            // Arrange
            int rating = 15;
            string[] tasteTags = { "1", "2", "3", "4", "5" };
            string comment = "this wine tastes like a test";

            // Act
            bool result = _reviewRepo.Create(test_user_id, test_wine_id, rating, tasteTags, comment);

            // Assert
            Assert.IsTrue(result);
        }
    }
}