﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using Uncorkd_DTO.DTOs;

namespace Uncorkd_DAL.DALs
{
    public class WineryDAL
    {
        public List<WineryDTO> GetWineryDTOs()
        {
            List<WineryDTO> wineryDTOs = new List<WineryDTO>();

            using(MySqlConnection con = Connector.MakeConnection())
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM `winery`", con);
                MySqlDataReader reader = cmd.ExecuteReader();

                while(reader.Read()) {
                    WineryDTO wineryDTO = new WineryDTO()
                    {
                        Id = reader.GetInt32("id"),
                        Name = reader.GetString("name"),
                        Description = reader.GetString("description"),
                    };
                    wineryDTOs.Add(wineryDTO);
                }

                return wineryDTOs;
            }

        }


        public WineryDTO GetWineryDTOWithID(int ID)
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
                    wineryDTO.Id = reader.GetInt32("id");
                    wineryDTO.Name = reader.GetString("name");
                    wineryDTO.Description = reader.GetString("description");
                }

                con.Close();
            }

            return wineryDTO;
        }
    }
}