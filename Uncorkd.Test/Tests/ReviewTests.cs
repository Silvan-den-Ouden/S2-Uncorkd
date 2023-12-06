using Uncorkd_BLL.Collections;
using Uncorkd_BLL.Models;
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
            WineModel wineModel = new()
            {
                Id = test_wine_id,
            };

            List<TasteTagModel> tasteTags = new();

            for (int i = 1; i <= 10; i++)
            {
                TasteTagModel tasteTagModel = new()
                {
                    Id = i,
                    TagName = "TestTag" + i,
                };

                tasteTags.Add(tasteTagModel);
            }

            ReviewModel reviewModel = new()
            {
                User_id = test_user_id,
                Wine = wineModel,
                Stars = 4,
                Comment = "fake comment",
                Image_URL = "https://imageurl.com/",
                Review_Date = DateTime.Now,
                TasteTags = tasteTags,
            };

            // Act
            ReviewModel result = _reviewCollection.Create(reviewModel);

            // Assert
            Assert.IsNotNull(result); 
            Assert.AreEqual(test_user_id, result.User_id); 
            Assert.AreEqual(test_wine_id, result.Wine.Id); 
            Assert.AreEqual(4, result.Stars); 
            Assert.AreEqual("fake comment", result.Comment); 
            Assert.AreEqual("https://imageurl.com/", result.Image_URL); 
            Assert.IsNotNull(result.Review_Date); 
            Assert.AreEqual(tasteTags.Count, result.TasteTags.Count); 
        }

        //[TestMethod]
        //public void UC01EX2()
        //{
        //    // Arrange
        //    int rating = 15;
        //    string tasteTags = "1, 2, 3, 4, 5";
        //    string comment = "";

        //    // Act
        //    _reviewCollection.Create(test_user_id, test_wine_id, rating, tasteTags, comment);

        //    // Assert
            
        //}
    }
}