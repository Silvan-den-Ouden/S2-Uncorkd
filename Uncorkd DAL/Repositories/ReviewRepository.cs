using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using Uncorkd_DAL.DALs;
using Uncorkd_DTO.DTOs;

namespace Uncorkd_DAL.Repositories
{
    public class ReviewRepository
    {
        public ReviewDTO CreateDTO(MySqlDataReader reader)
        {
            ReviewDTO reviewDTO = new ReviewDTO()
            {
                Id = reader.GetInt32("id"),
                User_Id = reader.GetInt32("user_id"),
                Wine_Id = reader.GetInt32("wine_id"),
                Rating = reader.GetInt32("rating"),
                Comment = reader.GetString("comment"),
                Image_url = reader.GetString("image_url"),
                DateTime = reader.GetDateTime("datetime"),
            };

            return reviewDTO;
        }

        public void Create(int user_id, int wine_id, int rating, string[] tasteTags, string comment)
        {
            using (MySqlConnection con = Connector.MakeConnection())
            {
                con.Open();

                MySqlCommand insertReviewCmd = new MySqlCommand("INSERT INTO `review` (user_id, wine_id, rating, comment) VALUES (@userId, @wineId, @rating, @comment);", con);
                insertReviewCmd.Parameters.AddWithValue("@userId", user_id);
                insertReviewCmd.Parameters.AddWithValue("@wineId", wine_id);
                insertReviewCmd.Parameters.AddWithValue("@rating", rating);
                insertReviewCmd.Parameters.AddWithValue("@comment", comment);
                insertReviewCmd.ExecuteNonQuery();

                long reviewId = insertReviewCmd.LastInsertedId;

                if (tasteTags != null && tasteTags.Length > 0)
                {
                    foreach (string tastetagId in tasteTags)
                    {
                        MySqlCommand insertTastetagCmd = new MySqlCommand("INSERT INTO `review_to_tastetag` (review_id, tastetag_id) VALUES (@reviewId, @tastetagId);", con);
                        insertTastetagCmd.Parameters.AddWithValue("@reviewId", reviewId);
                        insertTastetagCmd.Parameters.AddWithValue("@tastetagId", tastetagId);
                        insertTastetagCmd.ExecuteNonQuery();
                    }
                }
            }
        }


    }
}
