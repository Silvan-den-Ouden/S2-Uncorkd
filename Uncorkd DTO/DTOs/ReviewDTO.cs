using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uncorkd_DTO.DTOs
{
    public class ReviewDTO
    {
        public int Id { get; set; }
        public int User_id { get; set; }
        public int Wine_id { get; set; }
        public int Rating { get; set; }
        public string Comment { get; set; }
        public string Image_URL { get; set; }
        public DateTime Review_Date { get; set; }

        public ReviewDTO() { }
    }
}
