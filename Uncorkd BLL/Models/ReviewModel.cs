using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uncorkd_BLL.Models
{
    public class ReviewModel
    {
        public int Id { get; set; }
        public int User_Id { get; set; }
        public int Wine_Id { get; set; }
        public int Rating { get; set; }

        public ReviewModel() { }
    }
}
