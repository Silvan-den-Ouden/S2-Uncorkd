using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Uncorkd_BLL.Interfaces;
using Uncorkd_DTO.DTOs;

namespace Uncorkd_Test.Repos
{
    public class ReviewRepo : IReview
    {
        public ReviewDTO GetWithID(int id)
        {
            ReviewDTO reviewDTO = new()
            {
                Id = id,
                User_id = 1,
                Rating = 1,
                Comment = "comment",
                Image_URL = "image_url",
                Review_Date = DateTime.Now,
            };

            return reviewDTO;
        }

        public List<ReviewDTO> GetWithUserID(int user_id, int offset)
        {
            List<ReviewDTO> reviewDTOs = new();

            ReviewDTO reviewDTO = GetWithID(1);

            reviewDTOs.Add(reviewDTO);

            return reviewDTOs;
        }

        public ReviewDTO Create(ReviewDTO reviewDTO)
            {
            return reviewDTO;
        }

        public ReviewDTO Update(ReviewDTO reviewDTO)
        {
            return reviewDTO;
        }
        public void Delete(int reviewId)
        {

        }
    }
}
