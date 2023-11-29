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
        private readonly WineCollection _wineCollection;
        private readonly TasteTagCollection _tasteTagCollection;

        private readonly IReview _reviewRepository;
        //private readonly IWine _wineRepository;
        //private readonly IWinery _wineryRepository;
        //private readonly ITasteTag _tasteTagRepository;

        public ReviewCollection(WineCollection wineCollection, TasteTagCollection tasteTagCollection, IReview reviewRepository/*, IWine wineRepository, IWinery wineryRepository, ITasteTag tasteTagRepository*/) {
            _wineCollection = wineCollection;
            _tasteTagCollection = tasteTagCollection;

            _reviewRepository = reviewRepository;
            //_wineRepository = wineRepository;
            //_wineryRepository = wineryRepository;
            //_tasteTagCollection = tasteTagCollection;
        }

        private List<ReviewModel> TransformDTOs(List<ReviewDTO> reviewDTOs)
        {
            List<ReviewModel> reviewModels = new List<ReviewModel>();

            foreach (ReviewDTO reviewDTO in reviewDTOs)
            {
                ReviewModel reviewModel = new ReviewModel()
                {
                    Id = reviewDTO.Id,
                    User_id = reviewDTO.User_id,
                    Wine = _wineCollection.GetWithID(reviewDTO.Wine_id),
                    Stars = (double)reviewDTO.Rating / 4,
                    Comment = reviewDTO.Comment,
                    Image_URL = reviewDTO.Image_URL,
                    Review_Date = reviewDTO.Review_Date,
                    TasteTags = _tasteTagCollection.GetWithReviewID(reviewDTO.Id),
                };
                reviewModels.Add(reviewModel);
            }

            return reviewModels;
        }

        public ReviewModel GetWithID(int id)
        {
            List<ReviewDTO> reviewDTOs = new List<ReviewDTO>() { _reviewRepository.GetWithID(id) };
            List<ReviewModel> reviewModels = TransformDTOs(reviewDTOs);

            ReviewModel reviewModel = reviewModels[0];

            return reviewModel;
        }

        public List<ReviewModel> GetWithUserID(int user_id, int page_number)
        {
            int offset = page_number * 4 - 4;
            List<ReviewModel> reviewModels = TransformDTOs(_reviewRepository.GetWithUserID(user_id, offset));

            return reviewModels;
        }

        public void Create(int user_id, int wine_id, int rating, string tasteTags, string comment)
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

            _reviewRepository.Create(user_id, wine_id, rating, tasteTagsArray, comment); ;
        }

        public void Update(int user_id, int review_id, int rating, string tasteTags, string comment)
        {
            string[] tasteTagsArray = tasteTags.Split(',');
            if (tasteTagsArray[0] == "0")
            {
                tasteTagsArray = Array.Empty<string>();
            }

            _reviewRepository.Update(user_id, review_id, rating, tasteTagsArray, comment);
        }

        public void Delete(int reviewId)
        {
            _reviewRepository.Delete(reviewId);
        }

    }
}
