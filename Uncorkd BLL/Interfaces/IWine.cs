using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uncorkd_DTO.DTOs;

namespace Uncorkd_BLL.Interfaces
{
    public interface IWine
    {
        List<WineDTO> GetAll();
        WineDTO GetWithID(int ID); 
        List<WineDTO> GetBest();
        List<WineDTO> GetPopular();
        List<WineDTO> GetRandom();
        WineDTO Create(WineDTO wineDTO);
        WineDTO Update(WineDTO wineDTO);
    }
}
