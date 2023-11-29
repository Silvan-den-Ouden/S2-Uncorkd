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

        private List<WineModel> TransformDTOs(List<WineDTO> wineDTOs, IWinery wineryRepository, ITasteTag tasteTagRepository)
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
                    Winery = _wineryCollection.GetWithID(wineDTO.Winery_id, wineryRepository),
                    Stars = GetStars(wineDTO.Stars),
                    TasteTags = _tasteTagCollection.GetWithWineID(wineDTO.Id, tasteTagRepository),
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
            
        public List<WineModel> GetAll(IWine wineRepository, IWinery wineryRepository, ITasteTag tasteTagRepository)
        {
            List<WineModel> wineModels = TransformDTOs(wineRepository.GetAll(), wineryRepository, tasteTagRepository);
            return wineModels;
        }

        public WineModel GetWithID(int id, IWine wineRepository, IWinery wineryRepository, ITasteTag tasteTagRepository)
        {
            List<WineDTO> wineDTOs = new List<WineDTO>() { wineRepository.GetWithID(id) };
            List<WineModel> wineModels = TransformDTOs(wineDTOs, wineryRepository, tasteTagRepository);

            WineModel wineModel = wineModels[0];
            
            return wineModel;
        }

        public List<WineModel> GetBest(IWine wineRepository, IWinery wineryRepository, ITasteTag tasteTagRepository)
        {
            List<WineModel> wineModels = TransformDTOs(wineRepository.GetBest(), wineryRepository, tasteTagRepository);

            return wineModels;
        }

        public List<WineModel> GetPopular(IWine wineRepository, IWinery wineryRepository, ITasteTag tasteTagRepository)
        {
            List<WineModel> wineModels = TransformDTOs(wineRepository.GetPopular(), wineryRepository, tasteTagRepository);
            
            return wineModels;
        }

        public List<WineModel> GetRandom(IWine wineRepository, IWinery wineryRepository, ITasteTag tasteTagRepository)
        {
            List<WineModel> wineModels = TransformDTOs (wineRepository.GetRandom(), wineryRepository, tasteTagRepository);

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
