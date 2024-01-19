using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uncorkd_BLL.Collections;
using Uncorkd_BLL.Models;
using Uncorkd_Test.Repos;

namespace Uncorkd_Test.Tests
{
    [TestClass]
    public class WineTests
    {
        private readonly static WineRepo _wineRepository = new();
        private readonly static WineryRepo _wineryRepository = new();
        private readonly static TasteTagRepo _tasteTagRepository = new();

        private readonly static TasteTagCollection _tasteTagCollection = new(_tasteTagRepository);
        private readonly static WineryCollection _wineryCollection = new(_wineryRepository);
        private readonly static WineCollection _wineCollection = new(_wineryCollection, _tasteTagCollection, _wineRepository);

        private readonly int test_wine_id = 99;
        private readonly int test_winery_id = 99;

        [TestMethod]
        public void UserAddsWineWithAllInfo_EverythingGoesCorrectlyAndWeAreAllHappy()
        {
            // Arrange
            WineryModel wineryModel = new()
            {
                Id = test_winery_id,
            };

            List<TasteTagModel> tasteTags = new();

            for (int i = 1; i <= 5; i++)
            {
                TasteTagModel tasteTagModel = new()
                {
                    Id = i,
                    TagName = "TestTag" + i,
                };

                tasteTags.Add(tasteTagModel);
            }

            WineModel wineModel = new()
            {
                Id = test_wine_id,
                Name = "testWine",
                Description = "this is the desciption of the test wine",
                Image_URL = "https://imageurl.com/",
                Winery = wineryModel,
                TasteTags = tasteTags,
            };

            // Act
            WineModel result = _wineCollection.Create(wineModel);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(wineModel.Id, result.Id);
            Assert.AreEqual(wineModel.Name, result.Name);
            Assert.AreEqual(wineModel.Description, result.Description);
            Assert.AreEqual(wineModel.Image_URL, result.Image_URL);
            Assert.AreEqual(wineModel.Winery.Id, result.Winery.Id);
            Assert.AreEqual(wineModel.TasteTags.Count, result.TasteTags.Count);
        }

        [TestMethod]
        public void UserAddsWineWithoutImageUrl_ReturnsDefaultImageUrl()
        {
            // Arrange
            WineryModel wineryModel = new()
            {
                Id = test_winery_id,
            };

            List<TasteTagModel> tasteTags = new();

            for (int i = 1; i <= 5; i++)
            {
                TasteTagModel tasteTagModel = new()
                {
                    Id = i,
                    TagName = "TestTag" + i,
                };

                tasteTags.Add(tasteTagModel);
            }

            WineModel wineModel = new()
            {
                Id = test_wine_id,
                Name = "testWine",
                Description = "this is the desciption of the test wine",
                Winery = wineryModel,
                TasteTags = tasteTags,
            };

            // Act
            WineModel result = _wineCollection.Create(wineModel);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("https://i.ibb.co/KXygvP6/Default-Wine-512.png", result.Image_URL);
        }

        [TestMethod]
        public void UserAddsWineWithoutChosingTasteTags_NoDataSavedAboutTasteTags()
        {
            // Arrange
            WineryModel wineryModel = new()
            {
                Id = test_winery_id,
            };

            List<TasteTagModel> tasteTags = new();

            WineModel wineModel = new()
            {
                Id = test_wine_id,
                Name = "testWine",
                Description = "this is the desciption of the test wine",
                Image_URL = "https://imageurl.com/",
                Winery = wineryModel,
                TasteTags = tasteTags,
            };

            // Act
            WineModel result = _wineCollection.Create(wineModel);

            // Assert
            Assert.AreEqual(result.TasteTags.Count, wineModel.TasteTags.Count);
            Assert.AreEqual(0, wineModel.TasteTags.Count);
        }

        
    }
}
