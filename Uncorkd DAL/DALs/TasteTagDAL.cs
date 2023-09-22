﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using Uncorkd_DTO.DTOs;

namespace Uncorkd_DAL.DALs
{
    public class TasteTagDAL
    {
        public List<TasteTagDTO> GetTagDTOFromWineID(int wineID)
        {
            List<TasteTagDTO> tasteTagDTOs = new List<TasteTagDTO>();

            using (MySqlConnection con = Connetor.MakeConnection())
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT tastetag.id, tastetag.tag_name\r\nFROM `tastetag`\r\nJOIN `wine_to_tastetag` wtt ON tastetag.id = wtt.tag_id\r\nJOIN `wine` ON wtt.wine_id = wine.id\r\nWHERE wine.id = @wineID;", con);
                cmd.Parameters.AddWithValue("@wineID", wineID);
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    TasteTagDTO tasteTagDTO = new TasteTagDTO()
                    {
                        Id = reader.GetInt32("id"),
                        TagName = reader.GetString("tag_name"),
                    };
                    tasteTagDTOs.Add(tasteTagDTO);
                }
            }
            return tasteTagDTOs;
        }

    }
}
