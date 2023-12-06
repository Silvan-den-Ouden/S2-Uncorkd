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
    public class WineCollection
    {
        private readonly WineryCollection _wineryCollection;
        private readonly TasteTagCollection _tasteTagCollection;

        private readonly IWine _wineRepository;
        //private readonly IWinery _wineryRepository;
        //private readonly ITasteTag _tasteTagRepository;

        public WineCollection(WineryCollection wineryCollection, TasteTagCollection tasteTagCollection, IWine wineRepository/*, IWinery wineryRepository, ITasteTag tasteTagRepository*/)
        {
            _wineryCollection = wineryCollection;
            _tasteTagCollection = tasteTagCollection;

            _wineRepository = wineRepository;
            //_wineryRepository = wineryRepository;
            //_tasteTagRepository = tasteTagRepository;
        }


        private List<WineModel> TransformDTOs(List<WineDTO> wineDTOs)
        {
            List<WineModel> wineModels = new List<WineModel>();
            string defaultWineImg = "https://i.ibb.co/KXygvP6/Default-Wine-512.png";

            foreach (WineDTO wineDTO in wineDTOs)
            {
                if (wineDTO.Image_URL == "")
                {
                    wineDTO.Image_URL = defaultWineImg;
                }

                WineModel wineModel = new WineModel()
                {
                    Id = wineDTO.Id,
                    Name = wineDTO.Name,
                    Description = wineDTO.Description,
                    Image_URL = wineDTO.Image_URL,
                    Check_ins = wineDTO.Check_ins,
                    Winery = _wineryCollection.GetWithID(wineDTO.Winery_id),
                    Stars = GetStars(wineDTO.Stars),
                    TasteTags = _tasteTagCollection.GetWithWineID(wineDTO.Id),
                };
                wineModels.Add(wineModel);
            }
            return wineModels;
        }

        public WineDTO TransformModel(WineModel wineModel)
        {
            List<TasteTagDTO> tasteTagDTOs = new List<TasteTagDTO>();

            foreach (TasteTagModel tasteTagModel in wineModel.TasteTags)
            {
                TasteTagDTO tasteTagDTO = new TasteTagDTO()
                {
                    Id = tasteTagModel.Id,
                    TagName = tasteTagModel.TagName,
                };
                tasteTagDTOs.Add(tasteTagDTO);
            }

            if (wineModel.Stars == "???" || wineModel.Stars is null)
            {
                wineModel.Stars = "0";
            }

            WineDTO wineDTO = new WineDTO()
            {
                Id = wineModel.Id,
                Name = wineModel.Name,
                Description = wineModel.Description,
                Image_URL = wineModel.Image_URL,
                Check_ins = wineModel.Check_ins,
                Winery_id = wineModel.Winery.Id,
                Stars = double.Parse(wineModel.Stars),
                TasteTags = tasteTagDTOs,
            };

            return wineDTO;
        }

        public string GetStars(double stars)
        {
            if (stars > 0)
            {
                return stars.ToString("F");
            }

            return "???";
        }
            
        public List<WineModel> GetAll()
        {
            List<WineModel> wineModels = TransformDTOs(_wineRepository.GetAll());
            return wineModels;
        }

        public WineModel GetWithID(int id)
        {
            List<WineDTO> wineDTOs = new List<WineDTO>() { _wineRepository.GetWithID(id) };
            List<WineModel> wineModels = TransformDTOs(wineDTOs);

            WineModel wineModel = wineModels[0];
            
            return wineModel;
        }

        public List<WineModel> GetBest()
        {
            List<WineModel> wineModels = TransformDTOs(_wineRepository.GetBest());

            return wineModels;
        }

        public List<WineModel> GetPopular()
        {
            List<WineModel> wineModels = TransformDTOs(_wineRepository.GetPopular());
            
            return wineModels;
        }

        public List<WineModel> GetRandom()
        {
            List<WineModel> wineModels = TransformDTOs (_wineRepository.GetRandom());

            return wineModels;
        }

        public WineModel Create(WineModel wineModel)
        {
            if (wineModel.TasteTags[0].Id == 0)
            {
                wineModel.TasteTags = new List<TasteTagModel>();
            }
            if (wineModel.Image_URL == "" || wineModel.Image_URL is null)
            {
                wineModel.Image_URL = "https://i.ibb.co/KXygvP6/Default-Wine-512.png";
            }

            WineDTO wineDTO = TransformModel(wineModel);
            List<WineDTO> returnedDTOs = new List<WineDTO>() { _wineRepository.Create(wineDTO) };

            WineModel returnModel = TransformDTOs(returnedDTOs)[0];

            return returnModel;
        }

        public WineModel Update(WineModel wineModel)
        {
            if (wineModel.TasteTags[0].Id == 0)
            {
                wineModel.TasteTags = new List<TasteTagModel>();
            }
            if (wineModel.Image_URL == "" || wineModel.Image_URL is null)
            {
                wineModel.Image_URL = "https://i.ibb.co/KXygvP6/Default-Wine-512.png";
            }

            WineDTO wineDTO = TransformModel(wineModel);
            List<WineDTO> returnedDTOs = new List<WineDTO>() { _wineRepository.Update(wineDTO) };

            WineModel returnModel = TransformDTOs(returnedDTOs)[0];

            return returnModel;
        }
    }
}
