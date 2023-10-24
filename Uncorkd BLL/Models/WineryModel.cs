using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uncorkd_BLL.Models
{
    public class WineryModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image_URL { get; set; }

        public WineryModel() { }
    }
}
