using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uncorkd_DAL.Repositories;
using Uncorkd_BLL.Models;
using Uncorkd_DTO.DTOs;

namespace Uncorkd_BLL.Collections
{
    public class WineCollection
    {
        private readonly WineRepository _wineRepository;

        public WineCollection() {
            _wineRepository = new WineRepository();
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
                    Stars = GetStars(wineDTO.Stars)
                };
                wineModels.Add(wineModel);
            }
            return wineModels;
        }

        public string GetStars(double stars)
        {
            if (stars > 0)
            {
                return (Math.Round(stars * 4) / 4).ToString("F");
            }

            return "???";
        }
            
        public List<WineModel> GetAll()
        {
            List<WineModel> wineModels = TransformDTOs(_wineRepository.GetAll());
            return wineModels;
        }

        public WineModel GetWithID(int id)
        {
            List<WineDTO> wineDTOs = new List<WineDTO>() { _wineRepository.GetWithID(id) };
            List<WineModel> wineModels = TransformDTOs(wineDTOs);

            WineModel wineModel = wineModels[0];
            
            return wineModel;
        }

        public List<WineModel> GetPopular()
        {
            List<WineModel> wineModels = TransformDTOs(_wineRepository.GetPopular());
            
            return wineModels;
        }

        public List<WineModel> GetRandom()
        {
            List<WineModel> wineModels = TransformDTOs (_wineRepository.GetRandom());

            return wineModels;
        }
    }
}
