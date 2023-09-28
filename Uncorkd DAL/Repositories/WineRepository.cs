using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using Uncorkd_DTO.DTOs;

namespace Uncorkd_DAL.DALs
{
    public class WineRepository
    {
        public List<WineDTO> GetAll() {
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
                        Image_URL = reader.GetString("image_url"),
                        Check_ins = reader.GetInt32("check_ins"),
                        Winery_id = reader.GetInt32("winery_id"),
                    };
                    wineDTOs.Add(wineDTO);
                }
                con.Close();
            }

            return wineDTOs;
        }

        public WineDTO GetWithID(int ID)
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
                    wineDTO.Image_URL = reader.GetString("image_url");
                    wineDTO.Check_ins = reader.GetInt32("check_ins");
                    wineDTO.Winery_id = reader.GetInt32("winery_id");
                }
                con.Close();
            }

            return wineDTO;
        }

        public List<WineDTO> GetPopular()
        {
            List<WineDTO> wineDTOs = new List<WineDTO>();

            using (MySqlConnection con = Connector.MakeConnection())
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM `wine` ORDER BY `check_ins` DESC LIMIT 5", con);
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    WineDTO wineDTO = new WineDTO()
                    {
                        Id = reader.GetInt32("id"),
                        Name = reader.GetString("name"),
                        Description = reader.GetString("description"),
                        Image_URL = reader.GetString("image_url"),
                        Check_ins = reader.GetInt32("check_ins"),
                        Winery_id = reader.GetInt32("winery_id"),
                    };
                    wineDTOs.Add(wineDTO);
                }
                con.Close();
            }
            return wineDTOs;
        }

        public List<WineDTO> GetRandom()
        {
            List<WineDTO> wineDTOs = new List<WineDTO>();

            using (MySqlConnection con = Connector.MakeConnection())
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM `wine` ORDER BY RAND() LIMIT 5", con);
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    WineDTO wineDTO = new WineDTO()
                    {
                        Id = reader.GetInt32("id"),
                        Name = reader.GetString("name"),
                        Description = reader.GetString("description"),
                        Image_URL = reader.GetString("image_url"),
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
