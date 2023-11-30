using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uncorkd_BLL.Models;
using Uncorkd_DTO.DTOs;

namespace Uncorkd_BLL.Interfaces
{
    public interface IReview
    {
        ReviewDTO GetWithID(int id);
        List<ReviewDTO> GetWithUserID(int user_id, int offset);
        bool Create(int user_id, int wine_id, int rating, string[] tasteTags, string comment);
        void Update(int user_id, int review_id, int rating, string[] tasteTags, string comment);
        void Delete(int reviewId);
    }
}
