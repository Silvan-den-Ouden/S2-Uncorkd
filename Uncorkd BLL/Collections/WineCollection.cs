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
        private readonly WineDAL _wineDAL = new WineDAL();

        public List<WineModel> GetWines()
        {
            List<WineModel> wineModels = new List<WineModel>();

            foreach(WineDTO wineDTO in _wineDAL.GetWineDTOs())
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

        public WineModel GetWineWithID(int id)
        {
            WineDTO wineDTO = _wineDAL.GetWineWithID(id);

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
    }
}
