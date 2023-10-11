﻿using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using Uncorkd_DTO.DTOs;

namespace Uncorkd_DAL.DALs
{
    public class WineRepository
    {
        public WineDTO CreateDTO(MySqlDataReader reader)
        {
            WineDTO wineDTO = new WineDTO()
            {
                Id = reader.GetInt32("id"),
                Name = reader.GetString("name"),
                Description = reader.GetString("description"),
                Image_URL = reader.GetString("image_url"),
                Check_ins = reader.GetInt32("check_ins"),
                Winery_id = reader.GetInt32("winery_id"),
                Stars = GetStars(reader.GetInt32("id")),
            };

            return wineDTO;
        }

        private double GetStars(int ID)
        {
            double? stars = null;

            using (MySqlConnection con = Connector.MakeConnection())
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT AVG(`rating`/4) AS `stars` FROM `review` WHERE `wine_id` = @ID", con);
                cmd.Parameters.AddWithValue("@ID", ID);
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    if (!reader.IsDBNull(reader.GetOrdinal("stars")))
                    {
                        stars = reader.GetDouble("stars");
                    }
                }
            }

            return stars ?? -1;
        }

        public List<WineDTO> GetAll() {
            List<WineDTO> wineDTOs = new List<WineDTO>();

            using (MySqlConnection con = Connector.MakeConnection())
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT wine.*, COUNT(review.id) AS `check_ins` FROM wine JOIN review ON wine.id = review.wine_id GROUP BY wine.id;", con);
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    WineDTO wineDTO = CreateDTO(reader);
                    wineDTOs.Add(wineDTO);
                }
            }

            return wineDTOs;
        }

        public WineDTO GetWithID(int ID)
        {
            WineDTO wineDTO = new WineDTO();

            using (MySqlConnection con = Connector.MakeConnection())
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT wine.*, COUNT(review.id) AS `check_ins` FROM wine JOIN review ON wine.id = review.wine_id WHERE wine.`id` = @ID GROUP BY wine.id", con);
                cmd.Parameters.AddWithValue("@ID", ID);
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    wineDTO = CreateDTO(reader);
                }
            }

            return wineDTO;
        }

        public List<WineDTO> GetPopular()
        {
            List<WineDTO> wineDTOs = new List<WineDTO>();

            using (MySqlConnection con = Connector.MakeConnection())
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT `wine`.*, COUNT(`review`.id) AS `check_ins` FROM `wine` JOIN `review` ON `wine`.id = `review`.wine_id GROUP BY `wine`.id ORDER BY `check_ins` DESC LIMIT 5", con);
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    WineDTO wineDTO = CreateDTO(reader);
                    wineDTOs.Add(wineDTO);
                }
            }
            return wineDTOs;
        }

        public List<WineDTO> GetRandom()
        {
            List<WineDTO> wineDTOs = new List<WineDTO>();

            using (MySqlConnection con = Connector.MakeConnection())
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT wine.*, COUNT(review.id) AS `check_ins` FROM wine JOIN review ON wine.id = review.wine_id GROUP BY wine.id ORDER BY RAND() LIMIT 5;", con);
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    WineDTO wineDTO = CreateDTO(reader);
                    wineDTOs.Add(wineDTO);
                }
            }
            return wineDTOs;
        }
    }
}
