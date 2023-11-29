using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uncorkd_BLL.Models;
using Uncorkd_DTO.DTOs;
using Uncorkd_BLL.Interfaces;

namespace Uncorkd_BLL.Collections
{
    public class TasteTagCollection
    {
        private List<TasteTagModel> TransformDTOs(List<TasteTagDTO> tasteTagDTOs)
        {
            List<TasteTagModel> tasteTagModels = new List<TasteTagModel>();

            foreach (TasteTagDTO tasteTagDTO in tasteTagDTOs)
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

        public List<TasteTagModel> GetAll(ITasteTag tasteTagRepository)
        {
            List<TasteTagModel> tasteTagModels = TransformDTOs(tasteTagRepository.GetAll());

            return tasteTagModels;
        }

        public List<TasteTagModel> GetWithWineID(int wineID, ITasteTag tasteTagRepository)
        {
            List<TasteTagModel> tasteTagModels = TransformDTOs(tasteTagRepository.GetFromWineID(wineID));

            return tasteTagModels;
        }

        public List<TasteTagModel> GetWithReviewID(int reviewID, ITasteTag tasteTagRepository)
        {
            List<TasteTagModel> tasteTagModels = TransformDTOs(tasteTagRepository.GetFromReviewID(reviewID));

            return tasteTagModels;
        }
    }
}
