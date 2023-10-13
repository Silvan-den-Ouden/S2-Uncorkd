using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uncorkd_BLL.Models;
using Uncorkd_DAL.Repositories;
using Uncorkd_DTO.DTOs;

namespace Uncorkd_BLL.Collections
{
    public class WineryCollection
    {
        private readonly WineryRepository _wineryRepository;

        public WineryCollection() {
            _wineryRepository = new WineryRepository();
        }

        public List<WineryModel> TransformDTOs(List<WineryDTO> wineryDTOs)
        {
            List<WineryModel> wineryModels = new List<WineryModel>();

            foreach (WineryDTO wineryDTO in wineryDTOs)
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

        public List<WineryModel> GetAll()
        {
            List<WineryModel> wineryModels = TransformDTOs(_wineryRepository.GetAll());

            return wineryModels;
        }

        public WineryModel GetWithID(int id) {
            List<WineryDTO> wineryDTOs = new List<WineryDTO>() { _wineryRepository.GetWithID(id) };
            List<WineryModel> wineryModels = TransformDTOs(wineryDTOs);

            WineryModel wineryModel = wineryModels[0];

            return wineryModel;
        }
    }
}
