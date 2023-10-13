using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using Uncorkd_DTO.DTOs;

namespace Uncorkd_DAL.Repositories
{
    public class WineryRepository
    {
        public WineryDTO CreateDTO(MySqlDataReader reader)
        {
            WineryDTO wineryDTO = new WineryDTO()
            {
                Id = reader.GetInt32("id"),
                Name = reader.GetString("name"),
                Description = reader.GetString("description"),
            };

            return wineryDTO;
        }

        public List<WineryDTO> GetAll()
        {
            List<WineryDTO> wineryDTOs = new List<WineryDTO>();

            using(MySqlConnection con = Connector.MakeConnection())
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM `winery`", con);
                MySqlDataReader reader = cmd.ExecuteReader();

                while(reader.Read()) {
                    WineryDTO wineryDTO = CreateDTO(reader);
                    wineryDTOs.Add(wineryDTO);
                }

                return wineryDTOs;
            }

        }

        public WineryDTO GetWithID(int ID)
        {
            WineryDTO wineryDTO = new WineryDTO();

            using(MySqlConnection con = Connector.MakeConnection())
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM `winery` WHERE `id` = @ID", con);
                cmd.Parameters.AddWithValue("@ID", ID);
                MySqlDataReader reader = cmd.ExecuteReader();

                while(reader.Read())
                {
                    wineryDTO = CreateDTO(reader);
                }
            }

            return wineryDTO;
        }
    }
}
