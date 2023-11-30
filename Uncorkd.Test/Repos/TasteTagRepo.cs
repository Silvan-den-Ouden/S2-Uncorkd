using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uncorkd_BLL.Interfaces;
using Uncorkd_DTO.DTOs;

namespace Uncorkd_Test.Repos
{
    public class TasteTagRepo : ITasteTag
    {
        public List<TasteTagDTO> GetAll()
        {
            List<TasteTagDTO> tasteTagDTOs = new();

            for(int i = 0; i < 5;  i++)
            {
                tasteTagDTOs.Add(new TasteTagDTO()
                {
                    Id = i,
                    TagName = "testTag" + i.ToString(),
                });
            }

            return tasteTagDTOs;
        }

        public List<TasteTagDTO> GetFromWineID(int wineID)
        {
            List<TasteTagDTO> tasteTagDTOs = new();

            for (int i = 0; i < 5; i++)
            {
                tasteTagDTOs.Add(new TasteTagDTO()
                {
                    Id = i,
                    TagName = "testTag" + i.ToString(),
                });
            }

            return tasteTagDTOs;
        }

        public List<TasteTagDTO> GetFromReviewID(int reviewID)
        {
            List<TasteTagDTO> tasteTagDTOs = new();

            for (int i = 0; i < 5; i++)
            {
                tasteTagDTOs.Add(new TasteTagDTO()
                {
                    Id = i,
                    TagName = "testTag" + i.ToString(),
                });
            }

            return tasteTagDTOs;
        }
    }
}
