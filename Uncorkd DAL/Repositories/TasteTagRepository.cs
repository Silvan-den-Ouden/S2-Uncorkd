﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using Uncorkd_BLL.Interfaces;
using Uncorkd_DTO.DTOs;

namespace Uncorkd_DAL.Repositories
{
    public class TasteTagRepository : ITasteTag
    {
        private TasteTagDTO CreateDTO(MySqlDataReader reader)
        {
            TasteTagDTO TasteTagDTO = new TasteTagDTO()
            {
                Id = reader.GetInt32("id"),
                TagName = reader.GetString("tag_name"),
            };

            return TasteTagDTO;
        }

        public List<TasteTagDTO> GetAll() {
            List<TasteTagDTO> tasteTagDTOs = new List<TasteTagDTO>();

            using (MySqlConnection con = Connector.MakeConnection())
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM `tastetag`", con);
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    TasteTagDTO tasteTagDTO = CreateDTO(reader);
                    tasteTagDTOs.Add(tasteTagDTO);
                }
            }
            return tasteTagDTOs;
        }

        public TasteTagDTO GetWithId(int id)
        {
            TasteTagDTO tasteTagDTO = new TasteTagDTO();

            using (MySqlConnection con = Connector.MakeConnection())
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM `tastetag` WHERE `id` = @ID", con);
                cmd.Parameters.AddWithValue("@ID", id);
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    tasteTagDTO = CreateDTO(reader);
                }
            }
            return tasteTagDTO;
        }

        public List<TasteTagDTO> GetFromWineID(int wineID)
        {
            List<TasteTagDTO> tasteTagDTOs = new List<TasteTagDTO>();

            using (MySqlConnection con = Connector.MakeConnection())
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT tastetag.id, tastetag.tag_name\r\nFROM `tastetag`\r\nJOIN `wine_to_tastetag` wtt ON tastetag.id = wtt.tag_id\r\nJOIN `wine` ON wtt.wine_id = wine.id\r\nWHERE wine.id = @wineID;", con);
                cmd.Parameters.AddWithValue("@wineID", wineID);
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    TasteTagDTO tasteTagDTO = CreateDTO(reader);
                    tasteTagDTOs.Add(tasteTagDTO);
                }
            }
            return tasteTagDTOs;
        }

        public List<TasteTagDTO> GetFromReviewID(int reviewID)
        {
            List<TasteTagDTO> tasteTagDTOs = new List<TasteTagDTO>();

            using (MySqlConnection con = Connector.MakeConnection())
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT tastetag.id, tastetag.tag_name\r\nFROM `tastetag`\r\nJOIN `review_to_tastetag` rtt ON tastetag.id = rtt.tag_id\r\nJOIN `review` ON rtt.review_id = review.id\r\nWHERE review.id = @reviewID;", con);
                cmd.Parameters.AddWithValue("@reviewID", reviewID);
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    TasteTagDTO tasteTagDTO = CreateDTO(reader);
                    tasteTagDTOs.Add(tasteTagDTO);
                }
            }
            return tasteTagDTOs;
        }

    }
}
