﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uncorkd_BLL.Models
{
    public class WineModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Check_ins { get; set; }
        public int Winery_id { get; set;}

        public WineModel()
        {

        }
    }
}