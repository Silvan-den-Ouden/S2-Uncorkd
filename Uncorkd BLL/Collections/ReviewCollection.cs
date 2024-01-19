using System;
using System.Collections.Generic;
using System.Globalization;
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

        public ReviewCollection(WineCollection wineCollection, TasteTagCollection tasteTagCollection, IReview reviewRepository/*, IWine wineRepository, IWinery wineryRepository, ITasteTag tasteTagRepository*/) {
            _wineCollection = wineCollection;
            _tasteTagCollection = tasteTagCollection;

            _reviewRepository = reviewRepository;
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
                    Stars = reviewDTO.Rating,
                    Comment = reviewDTO.Comment,
                    Image_URL = reviewDTO.Image_URL,
                    Review_Date = reviewDTO.Review_Date,
                    TasteTags = _tasteTagCollection.TransformDTOs(reviewDTO.TasteTags),
                };
                reviewModels.Add(reviewModel);
            }

            return reviewModels;
        }

        private ReviewDTO TransformModel(ReviewModel reviewModel)
        {
            List<TasteTagDTO> tasteTagDTOs = new List<TasteTagDTO>();

            foreach (TasteTagModel tasteTagModel in reviewModel.TasteTags)
            {
                TasteTagDTO tasteTagDTO = new TasteTagDTO()
                {
                    Id = tasteTagModel.Id,
                    TagName = tasteTagModel.TagName,
                };
                tasteTagDTOs.Add(tasteTagDTO);
            }

            ReviewDTO reviewDTO = new ReviewDTO()
            {
                Id = reviewModel.Id,
                User_id = reviewModel.User_id,
                Wine_id =reviewModel.Wine.Id,
                Rating = (int)reviewModel.Stars,
                Comment = reviewModel.Comment,
                Image_URL = reviewModel.Image_URL,
                Review_Date = reviewModel.Review_Date,
                TasteTags = tasteTagDTOs,
            };

            return reviewDTO;
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

        public ReviewModel Create(ReviewModel reviewModel)
        {
            foreach (TasteTagModel tasteTag in reviewModel.TasteTags)
            {
                if (tasteTag.Id == 0)
                {
                    reviewModel.TasteTags = new List<TasteTagModel>();
                }
            }
            
            if (reviewModel.Comment == "")
            {
                reviewModel.Comment = "no comment";
            }

            ReviewDTO reviewDTO = TransformModel(reviewModel);
            List<ReviewDTO> returnedDTOs = new List<ReviewDTO>() { _reviewRepository.Create(reviewDTO) };

            ReviewModel returnModel = TransformDTOs(returnedDTOs)[0];

            return returnModel;
        }

        public void Update(ReviewModel reviewModel)
        {
            if (reviewModel.TasteTags[0].Id == 0)
            {
                reviewModel.TasteTags = new List<TasteTagModel>();
            }
            if (reviewModel.Comment == "")
            {
                reviewModel.Comment = "no comment";
            }

            ReviewDTO reviewDTO = TransformModel(reviewModel);

            _reviewRepository.Update(reviewDTO);
        }

        public void Delete(int reviewId)
        {
            _reviewRepository.Delete(reviewId);
        }

    }
}
