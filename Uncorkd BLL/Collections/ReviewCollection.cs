using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uncorkd_BLL.Models;
using Uncorkd_DAL.Repositories;
using Uncorkd_DTO.DTOs;

namespace Uncorkd_BLL.Collections
{
    public class ReviewCollection
    {
        private readonly ReviewRepository _reviewRepository;

        public ReviewCollection()
        {
            _reviewRepository = new ReviewRepository();
        }

        public List<ReviewModel> TransformDTOs(List<ReviewDTO> reviewDTOs)
        {
            List<ReviewModel> reviewModels = new List<ReviewModel>();

            foreach (ReviewDTO reviewDTO in reviewDTOs)
            {
                ReviewModel reviewModel = new ReviewModel()
                {
                    Id = reviewDTO.Id,
                    User_id = reviewDTO.User_id,
                    Wine_id = reviewDTO.Wine_id,
                    Stars = (double)reviewDTO.Rating / 4,
                    Comment = reviewDTO.Comment,
                    Image_URL = reviewDTO.Image_URL,
                    DateTime = reviewDTO.DateTime,
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

        public List<ReviewModel> GetWithUserID(int user_id)
        {
            List<ReviewModel> reviewModels = TransformDTOs(_reviewRepository.GetWithUserID(user_id));

            return reviewModels;
        }

        public void Create(int user_id, int wine_id, int rating, string tasteTags, string comment)
        {
            string[] tasteTagsArray = tasteTags.Split(',');
            if (tasteTagsArray[0] == "0")
            {
                tasteTagsArray = Array.Empty<string>();
            }

            _reviewRepository.Create(user_id, wine_id, rating, tasteTagsArray, comment);
        }

    }
}
