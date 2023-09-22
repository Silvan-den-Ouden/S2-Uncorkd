using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uncorkd_DAL.DALs;
using Uncorkd_BLL.Models;
using Uncorkd_DTO.DTOs;
using System.Runtime.Remoting.Messaging;

namespace Uncorkd_BLL.Collections
{
    public class TasteTagCollection
    {
        private readonly TasteTagDAL _tasteTagDAL = new TasteTagDAL();

        public List<TasteTagModel> GetTagFromWineID(int wineID)
        {
            List<TasteTagModel> tasteTagModels = new List<TasteTagModel>();

            foreach(TasteTagDTO tasteTagDTO in _tasteTagDAL.GetTagDTOFromWineID(wineID))
            {
                TasteTagModel tasteTagModel = new TasteTagModel()
                {
                    Id = tasteTagDTO.Id,
                    TagName = tasteTagDTO.TagName,
                };
                tasteTagModels.Add(tasteTagModel);
            }

            return tasteTagModels;
        }

    }
}
