using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uncorkd_BLL.Interfaces;
using Uncorkd_BLL.Models;
using Uncorkd_DTO.DTOs;

namespace Uncorkd_BLL.Collections
{
    public class ReviewCollection
    {
        public WineCollection _wineCollection = new WineCollection();
        public TasteTagCollection _tasteTagCollection = new TasteTagCollection();

       private List<ReviewModel> TransformDTOs(List<ReviewDTO> reviewDTOs, IWine wineRepository, IWinery wineryRepository, ITasteTag tasteTagRepository)
        {
            List<ReviewModel> reviewModels = new List<ReviewModel>();

            foreach (ReviewDTO reviewDTO in reviewDTOs)
            {
                ReviewModel reviewModel = new ReviewModel()
                {
                    Id = reviewDTO.Id,
                    User_id = reviewDTO.User_id,
                    Wine = _wineCollection.GetWithID(reviewDTO.Wine_id, wineRepository, wineryRepository, tasteTagRepository),
                    Stars = (double)reviewDTO.Rating / 4,
                    Comment = reviewDTO.Comment,
                    Image_URL = reviewDTO.Image_URL,
                    Review_Date = reviewDTO.Review_Date,
                    TasteTags = _tasteTagCollection.GetWithReviewID(reviewDTO.Id, tasteTagRepository),
                };
                reviewModels.Add(reviewModel);
            }

            return reviewModels;
        }

        public ReviewModel GetWithID(int id, IReview reviewRepository, IWine wineRepository, IWinery wineryRepository, ITasteTag tasteTagRepository)
        {
            List<ReviewDTO> reviewDTOs = new List<ReviewDTO>() { reviewRepository.GetWithID(id) };
            List<ReviewModel> reviewModels = TransformDTOs(reviewDTOs, wineRepository, wineryRepository, tasteTagRepository);

            ReviewModel reviewModel = reviewModels[0];

            return reviewModel;
        }

        public List<ReviewModel> GetWithUserID(int user_id, int page_number, IReview reviewRepository, IWine wineRepository, IWinery wineryRepository, ITasteTag tasteTagRepository)
        {
            int offset = page_number * 4 - 4;
            List<ReviewModel> reviewModels = TransformDTOs(reviewRepository.GetWithUserID(user_id, offset), wineRepository, wineryRepository, tasteTagRepository);

            return reviewModels;
        }

        public void Create(int user_id, int wine_id, int rating, string tasteTags, string comment, IReview reviewRepository)
        {
            string[] tasteTagsArray = tasteTags.Split(',');
            if (tasteTagsArray[0] == "0")
            {
                tasteTagsArray = Array.Empty<string>();
            }
            if (comment == "")
            {
                comment = "no comment";
            }

            reviewRepository.Create(user_id, wine_id, rating, tasteTagsArray, comment); ;
        }

        public void Update(int user_id, int review_id, int rating, string tasteTags, string comment, IReview reviewRepository)
        {
            string[] tasteTagsArray = tasteTags.Split(',');
            if (tasteTagsArray[0] == "0")
            {
                tasteTagsArray = Array.Empty<string>();
            }

            reviewRepository.Update(user_id, review_id, rating, tasteTagsArray, comment);
        }

        public void Delete(int reviewId, IReview reviewRepository)
        {
            reviewRepository.Delete(reviewId);
        }

    }
}
