using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uncorkd_DAL.DALs;
using Uncorkd_BLL.Models;
using Uncorkd_DTO.DTOs;

namespace Uncorkd_BLL.Collections
{
    public class WineCollection
    {
        private readonly WineRepository _wineDAL = new WineRepository();

        public List<WineModel> GetAll()
        {
            List<WineModel> wineModels = new List<WineModel>();

            foreach(WineDTO wineDTO in _wineDAL.GetAll())
            {
                WineModel wineModel = new WineModel()
                {
                    Id = wineDTO.Id,
                    Name = wineDTO.Name,
                    Description = wineDTO.Description,
                    Check_ins = wineDTO.Check_ins,
                    Winery_id = wineDTO.Winery_id,
                };
                wineModels.Add(wineModel);
            }
            return wineModels;
        }

        public WineModel GetWithID(int id)
        {
            WineDTO wineDTO = _wineDAL.GetWithID(id);

            WineModel wineModel = new WineModel()
            {
                Id = wineDTO.Id,
                Name = wineDTO.Name,
                Description = wineDTO.Description,
                Check_ins = wineDTO.Check_ins,
                Winery_id = wineDTO.Winery_id,
            };

            return wineModel;
        }

        public List<WineModel> GetBest()
        {
            List<WineModel> wineModels = new List<WineModel>();

            foreach (WineDTO wineDTO in _wineDAL.GetBest())
            {
                WineModel wineModel = new WineModel()
                {
                    Id = wineDTO.Id,
                    Name = wineDTO.Name,
                    Description = wineDTO.Description,
                    Check_ins = wineDTO.Check_ins,
                    Winery_id = wineDTO.Winery_id,
                };
                wineModels.Add(wineModel);
            }
            return wineModels;
        }
    }
}
