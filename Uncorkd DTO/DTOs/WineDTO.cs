using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uncorkd_DTO.DTOs
{
    public class WineDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image_URL { get; set; }
        public int Winery_id { get; set;}
        public double Stars { get; set; }


        public WineDTO() { }
    }
}
