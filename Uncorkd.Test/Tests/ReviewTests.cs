using Uncorkd_BLL.Collections;
using Uncorkd_Test.Repos;

namespace Uncorkd_Test.Tests
{
    [TestClass]
    public class ReviewTests
    {
        private readonly static ReviewRepo _reviewRepository = new();
        private readonly static WineRepo _wineRepository = new();
        private readonly static WineryRepo _wineryRepository = new();
        private readonly static TasteTagRepo _tasteTagRepository = new();

        private readonly static TasteTagCollection _tasteTagCollection = new(_tasteTagRepository);
        private readonly static WineryCollection _wineryCollection = new(_wineryRepository);
        private readonly static WineCollection _wineCollection = new(_wineryCollection, _tasteTagCollection, _wineRepository);
        private readonly ReviewCollection _reviewCollection = new(_wineCollection, _tasteTagCollection, _reviewRepository);


        private readonly int test_user_id = 99;
        private readonly int test_wine_id = 99;


        [TestMethod]
        public void UC01HappyFlow()
        {
            // Arrange
            int rating = 15;
            string tasteTags = "1, 2, 3, 4, 5";
            string comment = "this wine tastes like a test";

            // Act
            bool result = _reviewCollection.Create(test_user_id, test_wine_id, rating, tasteTags, comment);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void UC01EX2()
        {
            // Arrange
            int rating = 15;
            string tasteTags = "1, 2, 3, 4, 5";
            string comment = "";

            // Act
            _reviewCollection.Create(test_user_id, test_wine_id, rating, tasteTags, comment);

            // Assert
            
        }
    }
}