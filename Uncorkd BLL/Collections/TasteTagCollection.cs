using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uncorkd_DAL.Repositories;
using Uncorkd_BLL.Models;
using Uncorkd_DTO.DTOs;

namespace Uncorkd_BLL.Collections
{
    public class TasteTagCollection
    {
        private readonly TasteTagRepository _tasteTagRepository;
        private readonly WineCollection _wineCollection;

        public TasteTagCollection()
        {
            _tasteTagRepository = new TasteTagRepository();
            _wineCollection = new WineCollection();
        }

        public List<TasteTagModel> TransformDTOs(List<TasteTagDTO> tasteTagDTOs)
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

        public List<TasteTagModel> GetFromWineID(int wineID)
        {
            List<TasteTagModel> tasteTagModels = TransformDTOs(_tasteTagRepository.GetFromWineID(wineID));

            return tasteTagModels;
        }

        public List<List<TasteTagModel>> GetPopularWinesTags()
        {
            List<List<TasteTagModel>> tasteTagModels = new List<List<TasteTagModel>>();

            foreach(var Wine in _wineCollection.GetPopular()) {
                List<TasteTagModel> tasteTagM = GetFromWineID(Wine.Id);
                tasteTagModels.Add(tasteTagM);
            }

            return tasteTagModels;
        }

        public List<List<TasteTagModel>> GetRandomWinesTags()
        {
            List<List<TasteTagModel>> tasteTagModels = new List<List<TasteTagModel>>();

            foreach (var Wine in _wineCollection.GetRandom())
            {
                List<TasteTagModel> tasteTagM = GetFromWineID(Wine.Id);
                tasteTagModels.Add(tasteTagM);
            }

            return tasteTagModels;
        }
    }
}
