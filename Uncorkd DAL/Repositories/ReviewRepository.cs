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
            };

            return reviewDTO;
        }

        public void Create(int user_id, int wine_id, int rating)
        {
            using (MySqlConnection con = Connector.MakeConnection())
            {
                con.Open();

                MySqlCommand insertCmd = new MySqlCommand("INSERT INTO review (user_id, wine_id, rating) VALUES (@userId, @wineId, @rating);", con);
                insertCmd.Parameters.AddWithValue("@userId", user_id);
                insertCmd.Parameters.AddWithValue("@wineId", wine_id);
                insertCmd.Parameters.AddWithValue("@rating", rating);
                insertCmd.ExecuteNonQuery();
            }
        }

    }
}
