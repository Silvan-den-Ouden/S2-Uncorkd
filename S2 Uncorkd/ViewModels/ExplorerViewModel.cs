﻿using Uncorkd_BLL.Models;

namespace S2_Uncorkd.ViewModels
{
    public class ExplorerViewModel
    {
        public List<WineModel> Wines { get; set; }
        public List<WineryModel> Wineries { get; set; }
        public List<WineModel> BestWines { get; set; }
        public List<WineModel> RandomWines { get; set; }
        public List<List<TasteTagModel>> BestTasteTags { get; set; }

        public ExplorerViewModel(List<WineModel> _wines, List<WineryModel> _wineries, List<WineModel> _bestWines,List<List<TasteTagModel>> _bestTasteTags, List<WineModel> _randomWines)
        {
            Wines = _wines;
            Wineries = _wineries;
            BestWines = _bestWines;
            BestTasteTags = _bestTasteTags;
            RandomWines = _randomWines;
        }
    }
}
