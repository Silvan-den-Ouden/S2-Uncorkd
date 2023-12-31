﻿using Uncorkd_BLL.Models;

namespace S2_Uncorkd.ViewModels
{
    public class ExplorerViewModel
    {
        public List<WineModel> Wines { get; set; }
        public List<WineryModel> Wineries { get; set; }
        public List<WineModel> BestWines { get; set; }
        public List<WineModel> PopularWines { get; set; }
        public List<WineModel> RandomWines { get; set; }

        public ExplorerViewModel(List<WineModel> _wines, List<WineryModel> _wineries, List<WineModel> _bestWines, List<WineModel> _popularWines, List<WineModel> _randomWines)
        {
            Wines = _wines;
            Wineries = _wineries;
            BestWines = _bestWines;
            PopularWines = _popularWines;
            RandomWines = _randomWines;
        }
    }
}
