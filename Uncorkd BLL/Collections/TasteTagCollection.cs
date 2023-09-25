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
        private readonly TasteTagRepository _tasteTagDAL;

        public TasteTagCollection()
        {
            _tasteTagDAL = new TasteTagRepository();
        }

        public List<TasteTagModel> GetFromWineID(int wineID)
        {
            List<TasteTagModel> tasteTagModels = new List<TasteTagModel>();

            foreach(TasteTagDTO tasteTagDTO in _tasteTagDAL.GetFromWineID(wineID))
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
