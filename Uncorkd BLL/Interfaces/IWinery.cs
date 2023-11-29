using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uncorkd_DTO.DTOs;

namespace Uncorkd_BLL.Interfaces
{
    public interface IWinery
    {
        List<WineryDTO> GetAll();
        WineryDTO GetWithID(int ID);
    }
}
