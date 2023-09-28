using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uncorkd_DAL.DALs;
using Uncorkd_BLL.Models;
using Uncorkd_DTO.DTOs;
using static System.Net.WebRequestMethods;

namespace Uncorkd_BLL.Collections
{
    public class WineCollection
    {
        private readonly WineRepository _wineDAL = new WineRepository();

        public List<WineModel> GetAll()
        {
            List<WineModel> wineModels = TransformDTOs(_wineDAL.GetAll());
            return wineModels;
        }

        public WineModel GetWithID(int id)
        {
            List<WineDTO> wineDTOs = new List<WineDTO>() { _wineDAL.GetWithID(id) };
            List<WineModel> wineModels = TransformDTOs(wineDTOs);

            WineModel wineModel = wineModels[0];
            
            return wineModel;
        }

        public List<WineModel> GetPopular()
        {
            List<WineModel> wineModels = TransformDTOs(_wineDAL.GetPopular());
            
            return wineModels;
        }

        public List<WineModel> GetRandom()
        {
            List<WineModel> wineModels = TransformDTOs (_wineDAL.GetRandom());

            return wineModels;
        }
        
        public List<WineModel> TransformDTOs(List<WineDTO> wineDTOs)
        {
            List<WineModel> wineModels = new List<WineModel>();
            string defaultWine = "https://i.ibb.co/KXygvP6/Default-Wine-512.png";

            foreach (WineDTO wineDTO in wineDTOs)
            {
                if (wineDTO.Image_URL == "")
                {
                    wineDTO.Image_URL = defaultWine;
                }

                WineModel wineModel = new WineModel()
                {
                    Id = wineDTO.Id,
                    Name = wineDTO.Name,
                    Description = wineDTO.Description,
                    Image_URL = wineDTO.Image_URL,
                    Check_ins = wineDTO.Check_ins,
                    Winery_id = wineDTO.Winery_id,
                };
                wineModels.Add(wineModel);
            }
            return wineModels;
        }
    }
}
