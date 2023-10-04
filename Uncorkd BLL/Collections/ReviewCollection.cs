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
                    User_Id = reviewDTO.User_Id,
                    Wine_Id = reviewDTO.Wine_Id,
                    Rating = reviewDTO.Rating,
                };
                reviewModels.Add(reviewModel);
            }

            return reviewModels;
        }

        public void Create(int user_id, int wine_id, int rating)
        {
            _reviewRepository.Create(user_id, wine_id, rating);
        }

    }
}
