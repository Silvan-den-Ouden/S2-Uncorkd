using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uncorkd_BLL.Models;
using Uncorkd_DAL.DALs;
using Uncorkd_DTO.DTOs;

namespace Uncorkd_BLL.Collections
{
    public class WineryCollection
    {
        private readonly WineryDAL _wineryDAL = new WineryDAL();

        public List<WineryModel> GetWineries()
        {
            List<WineryModel> wineryModels = new List<WineryModel>();

            foreach (WineryDTO wineryDTO in _wineryDAL.GetWineryDTOs())
            {
                WineryModel wineryModel = new WineryModel()
                {
                    Id = wineryDTO.Id,
                    Name = wineryDTO.Name,
                    Description = wineryDTO.Description,
                };
                wineryModels.Add(wineryModel);
            }
            return wineryModels;
        }

        public WineryModel GetWineryWithID(int ID) { 
            WineryDTO wineryDTO = _wineryDAL.GetWineryDTOWithID(ID);

            WineryModel wineryModel = new WineryModel()
            {
                Id = wineryDTO.Id,
                Name = wineryDTO.Name,
                Description = wineryDTO.Description,
            };

            return wineryModel;
        }
    }
}
