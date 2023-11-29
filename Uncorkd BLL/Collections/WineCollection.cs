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
        private readonly WineryCollection _wineryCollection = new WineryCollection();
        private readonly TasteTagCollection _tasteTagCollection = new TasteTagCollection();

        private readonly IWinery _wineryInterface;
        private readonly ITasteTag _tasteTagInterface;

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
                    Winery = _wineryCollection.GetWithID(wineDTO.Winery_id, _wineryInterface),
                    Stars = GetStars(wineDTO.Stars),
                    TasteTags = _tasteTagCollection.GetWithWineID(wineDTO.Id, _tasteTagInterface),
                };
                wineModels.Add(wineModel);
            }
            return wineModels;
        }

        public string GetStars(double stars)
        {
            if (stars > 0)
            {
                return stars.ToString("F");
            }

            return "???";
        }
            
        public List<WineModel> GetAll(IWine wineRepository)
        {
            List<WineModel> wineModels = TransformDTOs(wineRepository.GetAll());
            return wineModels;
        }

        public WineModel GetWithID(int id, IWine wineRepository)
        {
            List<WineDTO> wineDTOs = new List<WineDTO>() { wineRepository.GetWithID(id) };
            List<WineModel> wineModels = TransformDTOs(wineDTOs);

            WineModel wineModel = wineModels[0];
            
            return wineModel;
        }

        public List<WineModel> GetBest(IWine wineRepository)
        {
            List<WineModel> wineModels = TransformDTOs(wineRepository.GetBest());

            return wineModels;
        }

        public List<WineModel> GetPopular(IWine wineRepository)
        {
            List<WineModel> wineModels = TransformDTOs(wineRepository.GetPopular());
            
            return wineModels;
        }

        public List<WineModel> GetRandom(IWine wineRepository)
        {
            List<WineModel> wineModels = TransformDTOs (wineRepository.GetRandom());

            return wineModels;
        }

        public void Create(int wineryId, string name, string description, string tasteTags, string image_url, IWine wineRepository)
        {
            string[] tasteTagsArray = tasteTags.Split(',');
            if (tasteTagsArray[0] == "0")
            {
                tasteTagsArray = Array.Empty<string>();
            }
            if(image_url == "" || image_url is null)
            {
                image_url = "https://i.ibb.co/KXygvP6/Default-Wine-512.png";
            }

            wineRepository.Create(wineryId, name, description, tasteTagsArray, image_url);
        }

        public void Update(int wineId, string name, string description, string tasteTags, string image_url, IWine wineRepository)
        {
            string[] tasteTagsArray = tasteTags.Split(',');
            if (tasteTagsArray[0] == "0")
            {
                tasteTagsArray = Array.Empty<string>();
            }
            if (image_url == "" || image_url is null)
            {
                image_url = "https://i.ibb.co/KXygvP6/Default-Wine-512.png";
            }

            wineRepository.Update(wineId, name, description, tasteTagsArray, image_url);
        }
    }
}
