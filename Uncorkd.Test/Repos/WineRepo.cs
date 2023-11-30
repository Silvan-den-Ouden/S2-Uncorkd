using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uncorkd_BLL.Interfaces;
using Uncorkd_DTO.DTOs;

namespace Uncorkd_Test.Repos
{
    public class WineRepo : IWine
    {
        public List<WineDTO> GetAll()
        {
            List<WineDTO> wineDTOs = new();

            for(int i = 0; i < 10; i++)
            {
                wineDTOs.Add(new WineDTO()
                {
                    Id = i,
                });
            }

            return wineDTOs;
        }

        public WineDTO GetWithID(int ID)
        {
            WineDTO wineDTO = new WineDTO()
            {
                Id = ID,
            };

            return wineDTO;
        }

        public List<WineDTO> GetBest()
        {
            List<WineDTO> wineDTOs = new();

            for (int i = 0; i < 5; i++)
            {
                wineDTOs.Add(new WineDTO()
                {
                    Id = i,
                });
            }

            return wineDTOs;
        }

        public List<WineDTO> GetPopular()
        {
            List<WineDTO> wineDTOs = new();

            for (int i = 0; i < 5; i++)
            {
                wineDTOs.Add(new WineDTO()
                {
                    Id = i,
                });
            }

            return wineDTOs;
        }

        public List<WineDTO> GetRandom()
        {
            List<WineDTO> wineDTOs = new();

            for (int i = 0; i < 5; i++)
            {
                wineDTOs.Add(new WineDTO()
                {
                    Id = i,
                });
            }

            return wineDTOs;
        }

        public void Create(int wineryId, string name, string description, string[] tasteTags, string image_url)
        {

        }

        public void Update(int wineId, string name, string description, string[] tasteTags, string image_url)
        {

        }
    }
}
