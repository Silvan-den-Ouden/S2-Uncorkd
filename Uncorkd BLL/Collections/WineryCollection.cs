using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uncorkd_BLL.Interfaces;
using Uncorkd_BLL.Models;
using Uncorkd_DTO.DTOs;

namespace Uncorkd_BLL.Collections
{
    public class WineryCollection
    {   
        private List<WineryModel> TransformDTOs(List<WineryDTO> wineryDTOs)
        {
            List<WineryModel> wineryModels = new List<WineryModel>();

            foreach (WineryDTO wineryDTO in wineryDTOs)
            {
                WineryModel wineryModel = new WineryModel()
                {
                    Id = wineryDTO.Id,
                    Name = wineryDTO.Name,
                    Description = wineryDTO.Description,
                    Image_URL = wineryDTO.Image_URL,
                };
                wineryModels.Add(wineryModel);
            }
            return wineryModels;
        }

        public List<WineryModel> GetAll(IWinery wineryRepository)
        {
            List<WineryModel> wineryModels = TransformDTOs(wineryRepository.GetAll());

            return wineryModels;
        }

        public WineryModel GetWithID(int id, IWinery wineryRepository) {
            List<WineryDTO> wineryDTOs = new List<WineryDTO>() { wineryRepository.GetWithID(id) };
            List<WineryModel> wineryModels = TransformDTOs(wineryDTOs);

            WineryModel wineryModel = wineryModels[0];

            return wineryModel;
        }
    }
}
