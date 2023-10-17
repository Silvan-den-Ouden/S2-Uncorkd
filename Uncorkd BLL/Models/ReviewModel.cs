using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace Uncorkd_BLL.Models
{
    public class ReviewModel
    {
        public int Id { get; set; }
        public int User_id { get; set; }
        public int Wine_id { get; set; }
        public double Stars { get; set; }
        public string Comment { get; set; }
        public string Image_URL { get; set; }
        public DateTime Review_Date { get; set; }

        public ReviewModel() { }
    }
}
