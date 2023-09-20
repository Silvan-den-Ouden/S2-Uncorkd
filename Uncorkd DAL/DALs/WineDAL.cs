using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using Uncorkd_DTO;

namespace Uncorkd_DAL
{
    public class WineDAL
    {
        public List<WineDTO> GetWineDTOs() {
            List<WineDTO> wineDTOs = new List<WineDTO>();

            using (MySqlConnection con = Connetor.MakeConnection())
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

    }
}
