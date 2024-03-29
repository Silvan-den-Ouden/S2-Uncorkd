﻿using System;
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
        ReviewDTO Create(ReviewDTO reviewDTO);
        ReviewDTO Update(ReviewDTO reviewDTO);
        void Delete(int reviewId);
    }
}
