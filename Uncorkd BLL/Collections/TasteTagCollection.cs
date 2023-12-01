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
        private readonly ITasteTag _tasteTagRepository;

        public TasteTagCollection(ITasteTag tasteTagRepository)
        {
            _tasteTagRepository = tasteTagRepository;
        }

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

        public List<TasteTagModel> GetAll()
        {
            List<TasteTagModel> tasteTagModels = TransformDTOs(_tasteTagRepository.GetAll());

            return tasteTagModels;
        }

        public TasteTagModel GetWithId(int id)
        {
            List<TasteTagDTO> tastetagDTOs = new List<TasteTagDTO>() { _tasteTagRepository.GetWithId(id) };
            List<TasteTagModel> tasteTagModels = TransformDTOs(tastetagDTOs);

            TasteTagModel tasteTagModel = tasteTagModels[0];

            return tasteTagModel;
        }

        public List<TasteTagModel> GetWithWineID(int wineID)
        {
            List<TasteTagModel> tasteTagModels = TransformDTOs(_tasteTagRepository.GetFromWineID(wineID));

            return tasteTagModels;
        }

        public List<TasteTagModel> GetWithReviewID(int reviewID)
        {
            List<TasteTagModel> tasteTagModels = TransformDTOs(_tasteTagRepository.GetFromReviewID(reviewID));

            return tasteTagModels;
        }
    }
}
