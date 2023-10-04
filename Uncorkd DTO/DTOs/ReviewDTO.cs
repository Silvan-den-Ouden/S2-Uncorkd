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
        public int User_Id { get; set; }
        public int Wine_Id { get; set; }
        public int Rating { get; set; }

        public ReviewDTO() { }
    }
}
