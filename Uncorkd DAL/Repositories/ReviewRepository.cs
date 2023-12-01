using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using Uncorkd_DTO.DTOs;
using Uncorkd_BLL.Interfaces;

namespace Uncorkd_DAL.Repositories
{
    public class ReviewRepository : IReview
    {
        private ReviewDTO CreateDTO(MySqlDataReader reader)
        {
            ReviewDTO reviewDTO = new ReviewDTO()
            {
                Id = reader.GetInt32("id"),
                User_id = reader.GetInt32("user_id"),
                Wine_id = reader.GetInt32("wine_id"),
                Rating = reader.GetInt32("rating"),
                Comment = reader.GetString("comment"),
                Image_URL = reader.GetString("image_url"),
                Review_Date = reader.GetDateTime("review_date"),
            };

            return reviewDTO;
        }

        public ReviewDTO GetWithID(int id)
        {
            ReviewDTO reviewDTO = new ReviewDTO();

            using(MySqlConnection con = Connector.MakeConnection())
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM `review` WHERE id = @ID", con);
                cmd.Parameters.AddWithValue("@ID", id);

                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    reviewDTO = CreateDTO(reader);
                }
            }
            return reviewDTO;
        }
        
        public List<ReviewDTO> GetWithUserID(int user_id, int offset)
        {
            List<ReviewDTO> reviewDTOs = new List<ReviewDTO>();

            using(MySqlConnection con = Connector.MakeConnection())
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM `review` WHERE user_id = @user_id ORDER BY `review_date` DESC LIMIT @offset, 4", con);
                cmd.Parameters.AddWithValue("@user_id", user_id);
                cmd.Parameters.AddWithValue("@offset", offset);
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    ReviewDTO reviewDTO = CreateDTO(reader);
                    reviewDTOs.Add(reviewDTO);
                }
            }
            return reviewDTOs;
        }

        public ReviewDTO Create(ReviewDTO reviewDTO)
        {
            using (MySqlConnection con = Connector.MakeConnection())
            {
                con.Open();

                MySqlCommand insertReviewCmd = new MySqlCommand("INSERT INTO `review` (user_id, wine_id, rating, comment) VALUES (@userId, @wineId, @rating, @comment);", con);
                insertReviewCmd.Parameters.AddWithValue("@userId", reviewDTO.User_id);
                insertReviewCmd.Parameters.AddWithValue("@wineId", reviewDTO.Wine_id);
                insertReviewCmd.Parameters.AddWithValue("@rating", reviewDTO.Rating);
                insertReviewCmd.Parameters.AddWithValue("@comment", reviewDTO.Comment);
                insertReviewCmd.ExecuteNonQuery();

                long reviewId = insertReviewCmd.LastInsertedId;

                if (reviewDTO.TasteTags != null && reviewDTO.TasteTags.Count > 0)
                {
                    foreach (TasteTagDTO tasteTag in reviewDTO.TasteTags)
                    {
                        MySqlCommand insertTastetagCmd = new MySqlCommand("INSERT INTO `review_to_tastetag` (review_id, tag_id) VALUES (@reviewId, @tastetagId);", con);
                        insertTastetagCmd.Parameters.AddWithValue("@reviewId", reviewId);
                        insertTastetagCmd.Parameters.AddWithValue("@tastetagId", tasteTag.Id);
                        insertTastetagCmd.ExecuteNonQuery();
                    }
                }
            }

            return reviewDTO;
        }

        public void Update(int user_id, int review_id, int rating, string[] tasteTags, string comment)
        {
            using (MySqlConnection con = Connector.MakeConnection())
            {
                con.Open();

                MySqlCommand updateReviewCmd = new MySqlCommand("UPDATE `review` SET user_id = @userId, rating = @rating, comment = @comment WHERE id = @reviewId;", con);
                updateReviewCmd.Parameters.AddWithValue("@userId", user_id);
                updateReviewCmd.Parameters.AddWithValue("@rating", rating);
                updateReviewCmd.Parameters.AddWithValue("@comment", comment);
                updateReviewCmd.Parameters.AddWithValue("@reviewId", review_id);
                updateReviewCmd.ExecuteNonQuery();

                MySqlCommand deleteTagsCmd = new MySqlCommand("DELETE FROM `review_to_tastetag` WHERE review_id = @reviewId;", con);
                deleteTagsCmd.Parameters.AddWithValue("@reviewId", review_id);
                deleteTagsCmd.ExecuteNonQuery();

                if (tasteTags != null && tasteTags.Length > 0)
                {
                    foreach (string tastetagId in tasteTags)
                    {
                        MySqlCommand insertTastetagCmd = new MySqlCommand("INSERT INTO `review_to_tastetag` (review_id, tag_id) VALUES (@reviewId, @tastetagId);", con);
                        insertTastetagCmd.Parameters.AddWithValue("@reviewId", review_id);
                        insertTastetagCmd.Parameters.AddWithValue("@tastetagId", tastetagId);
                        insertTastetagCmd.ExecuteNonQuery();
                    }
                }
            }
        }


        public void Delete(int reviewId)
        {
            using (MySqlConnection con = Connector.MakeConnection())
            {
                con.Open();

                using (MySqlTransaction transaction = con.BeginTransaction())
                {
                    try
                    {
                        // Delete taste tags associated with the review
                        MySqlCommand deleteTastetagsCmd = new MySqlCommand("DELETE FROM `review_to_tastetag` WHERE review_id = @reviewId;", con, transaction);
                        deleteTastetagsCmd.Parameters.AddWithValue("@reviewId", reviewId);
                        deleteTastetagsCmd.ExecuteNonQuery();

                        // Delete the review
                        MySqlCommand deleteReviewCmd = new MySqlCommand("DELETE FROM `review` WHERE id = @reviewId;", con, transaction);
                        deleteReviewCmd.Parameters.AddWithValue("@reviewId", reviewId);
                        deleteReviewCmd.ExecuteNonQuery();

                        transaction.Commit(); 
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        Console.WriteLine("Error deleting review: " + ex.Message);
                    }
                }
            }
        }

    }
}
