using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using Uncorkd_DTO.DTOs;

namespace Uncorkd_DAL.DALs
{
    public class WineDAL
    {
        public List<WineDTO> GetWineDTOs() {
            List<WineDTO> wineDTOs = new List<WineDTO>();

            using (MySqlConnection con = Connector.MakeConnection())
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM `wine`", con);
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    WineDTO wineDTO = new WineDTO()
                    {
                        Id = reader.GetInt32("id"),
                        Name = reader.GetString("name"),
                        Description = reader.GetString("description"),
                        Check_ins = reader.GetInt32("check_ins"),
                        Winery_id = reader.GetInt32("winery_id"),
                    };
                    wineDTOs.Add(wineDTO);
                }
                con.Close();
            }

            return wineDTOs;
        }

        public WineDTO GetWineWithID(int ID)
        {
            WineDTO wineDTO = new WineDTO();

            using (MySqlConnection con = Connector.MakeConnection())
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM `wine` WHERE `id` = @ID", con);
                cmd.Parameters.AddWithValue("@ID", ID);
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    wineDTO.Id = reader.GetInt32("id");
                    wineDTO.Name = reader.GetString("name");
                    wineDTO.Description = reader.GetString("description");
                    wineDTO.Check_ins = reader.GetInt32("check_ins");
                    wineDTO.Winery_id = reader.GetInt32("winery_id");
                }
                con.Close();
            }

            return wineDTO;
        }
    }
}
