﻿using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using MySql.Data.MySqlClient;
using Uncorkd_BLL.Interfaces;
using Uncorkd_DTO.DTOs;

namespace Uncorkd_DAL.Repositories
{
    public class WineRepository : IWine
    {
        private WineDTO CreateDTO(MySqlDataReader reader)
        {
            WineDTO wineDTO = new WineDTO()
            {
                Id = reader.GetInt32("id"),
                Name = reader.GetString("name"),
                Description = reader.GetString("description"),
                Image_URL = reader.GetString("image_url"),
                Check_ins = GetCheckIns(reader.GetInt32("id")),
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

        private int GetCheckIns(int ID)
        {
            int? check_ins = null;

            using (MySqlConnection con = Connector.MakeConnection())
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT COUNT(review.id) AS `check_ins` FROM wine LEFT JOIN review ON wine.id = review.wine_id WHERE wine.id = @ID", con);
                cmd.Parameters.AddWithValue("@ID", ID);
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    if (!reader.IsDBNull(reader.GetOrdinal("check_ins")))
                    {
                        check_ins = reader.GetInt32("check_ins");
                    }
                }
            }

            return check_ins ?? -1;
        }

        public List<WineDTO> GetAll() {
            List<WineDTO> wineDTOs = new List<WineDTO>();

            using (MySqlConnection con = Connector.MakeConnection())
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT wine.*, COUNT(review.id) AS `check_ins` FROM wine LEFT JOIN review ON wine.id = review.wine_id WHERE wine.id <> 99 GROUP BY wine.id;", con);
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
                MySqlCommand cmd = new MySqlCommand("SELECT wine.*, COUNT(review.id) AS `check_ins` FROM wine LEFT JOIN review ON wine.id = review.wine_id WHERE wine.`id` = @ID GROUP BY wine.id", con);
                cmd.Parameters.AddWithValue("@ID", ID);
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    wineDTO = CreateDTO(reader);
                }
            }

            return wineDTO;
        }

        public List<WineDTO> GetBest()
        {
            List<WineDTO> wineDTOs = new List<WineDTO>();

            using (MySqlConnection con = Connector.MakeConnection())
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT `wine`.*, AVG(`rating`/4) AS `stars` FROM `wine` LEFT JOIN `review` ON `wine`.id = `review`.wine_id GROUP BY `wine`.id ORDER BY `stars` DESC LIMIT 5;", con);
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    WineDTO wineDTO = CreateDTO(reader);
                    wineDTOs.Add(wineDTO);
                }
            }
            return wineDTOs;
        }

        public List<WineDTO> GetPopular()
        {
            List<WineDTO> wineDTOs = new List<WineDTO>();

            using (MySqlConnection con = Connector.MakeConnection())
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT `wine`.*, COUNT(`review`.id) AS `check_ins` FROM `wine` LEFT JOIN `review` ON `wine`.id = `review`.wine_id GROUP BY `wine`.id ORDER BY `check_ins` DESC LIMIT 5", con);
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
                MySqlCommand cmd = new MySqlCommand("SELECT wine.*, COUNT(review.id) AS `check_ins` FROM wine LEFT JOIN review ON wine.id = review.wine_id WHERE wine.id <> 99 GROUP BY wine.id ORDER BY RAND() LIMIT 5;", con);
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    WineDTO wineDTO = CreateDTO(reader);
                    wineDTOs.Add(wineDTO);
                }
            }
            return wineDTOs;
        }

        public WineDTO Create(WineDTO wineDTO)
        {
            using (MySqlConnection con = Connector.MakeConnection())
            {
                con.Open();

                MySqlCommand createWineCmd = new MySqlCommand("INSERT INTO `wine` (name, description, winery_id, image_url) VALUES (@name, @description, @wineryId, @image_url);", con);
                createWineCmd.Parameters.AddWithValue("@name", wineDTO.Name);
                createWineCmd.Parameters.AddWithValue("@description", wineDTO.Description);
                createWineCmd.Parameters.AddWithValue("@wineryId", wineDTO.Winery_id);
                createWineCmd.Parameters.AddWithValue("@image_url", wineDTO.Image_URL);
                createWineCmd.ExecuteNonQuery();

                long wineId = createWineCmd.LastInsertedId;

                if (wineDTO.TasteTags != null && wineDTO.TasteTags.Count > 0)
                {
                    foreach (TasteTagDTO tastetag in wineDTO.TasteTags)
                    {
                        MySqlCommand insertTastetagCmd = new MySqlCommand("INSERT INTO `wine_to_tastetag` (wine_id, tag_id) VALUES (@wineId, @tastetagId);", con);
                        insertTastetagCmd.Parameters.AddWithValue("@wineId", wineId);
                        insertTastetagCmd.Parameters.AddWithValue("@tastetagId", tastetag.Id);
                        insertTastetagCmd.ExecuteNonQuery();
                    }
                }
            }

            return wineDTO;
        }

        public WineDTO Update(WineDTO wineDTO)
        {
            using (MySqlConnection con = Connector.MakeConnection())
            {
                con.Open();

                MySqlCommand updateWineCmd = new MySqlCommand("UPDATE `wine` SET name = @name, description = @description, image_url = @image_url WHERE id = @ID;", con);
                updateWineCmd.Parameters.AddWithValue("@name", wineDTO.Name);
                updateWineCmd.Parameters.AddWithValue("@description", wineDTO.Description);
                updateWineCmd.Parameters.AddWithValue("@image_url", wineDTO.Image_URL);
                updateWineCmd.Parameters.AddWithValue("@ID", wineDTO.Id);
                updateWineCmd.ExecuteNonQuery();

                MySqlCommand deleteTasteTagsCmd = new MySqlCommand("DELETE FROM `wine_to_tastetag` WHERE wine_id = @wineId;", con);
                deleteTasteTagsCmd.Parameters.AddWithValue("@wineId", wineDTO.Id);
                deleteTasteTagsCmd.ExecuteNonQuery();

                if (wineDTO.TasteTags != null && wineDTO.TasteTags.Count > 0)
                {
                    foreach (TasteTagDTO tastetag in wineDTO.TasteTags)
                    {
                        MySqlCommand insertTastetagCmd = new MySqlCommand("INSERT INTO `wine_to_tastetag` (wine_id, tag_id) VALUES (@wineId, @tastetagId);", con);
                        insertTastetagCmd.Parameters.AddWithValue("@wineId", wineDTO.Id);
                        insertTastetagCmd.Parameters.AddWithValue("@tastetagId", tastetag.Id);
                        insertTastetagCmd.ExecuteNonQuery();
                    }
                }
            }

            return wineDTO;
        }

    }
}
