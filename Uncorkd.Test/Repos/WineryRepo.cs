using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uncorkd_BLL.Interfaces;
using Uncorkd_DTO.DTOs;

namespace Uncorkd_Test.Repos
{
    public class WineryRepo : IWinery
    {
        public List<WineryDTO> GetAll()
        {
            List<WineryDTO> wineryDTOs = new();

            for(int i = 0; i < 10; i++)
            {
                wineryDTOs.Add(new WineryDTO()
                {
                    Id = i,
                });
            }

            return wineryDTOs;
        }
        public WineryDTO GetWithID(int ID)
        {
            WineryDTO wineryDTO = new()
            {
                Id = ID,
            };

            return wineryDTO;
        }
    }
}
