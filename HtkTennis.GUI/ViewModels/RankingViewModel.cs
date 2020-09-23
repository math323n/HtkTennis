using HtkTennis.Entities;
using HtkTennisGui.ViewModels.Base;
using System.Collections.ObjectModel;

namespace HtkTennis.GUI.ViewModels
{
    public class RankingViewModel: ViewModelBase
    {
        protected ObservableCollection<Ranking> rankings;
        protected Ranking selectedRanking;

        public RankingViewModel()
        {
            Rankings = new ObservableCollection<Ranking>();
        }

        public virtual ObservableCollection<Ranking> Rankings
        {
            get
            {
                return rankings;
            }
            set
            {
                SetProperty(ref rankings, value);
            }
        }

        public virtual Ranking SelectedRanking
        {
            get
            {
                return selectedRanking;
            }
            set
            {
                SetProperty(ref selectedRanking, value);
            }
        }
    }
}