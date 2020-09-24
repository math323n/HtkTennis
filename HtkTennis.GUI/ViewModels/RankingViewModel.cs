using HtkTennis.DataAccess;
using HtkTennis.DataAccess.Factory;
using HtkTennis.Entities;
using HtkTennis.Utilities;

using HtkTennisGui.ViewModels.Base;

using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace HtkTennis.GUI.ViewModels
{
    public class RankingViewModel: ViewModelBase
    {
        #region Fields
        protected ObservableCollection<Ranking> rankings;
        protected Ranking selectedRanking;
        #endregion

        #region Constructor
        public RankingViewModel()
        {
            // Initialize collection to prevent error with the ReplaceWith extention method
            rankings = new ObservableCollection<Ranking>();
        }
        #endregion

        /// <summary>
        /// The displayed rankings in the view
        /// </summary>
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

        /// <summary>
        /// The selected ranking in the view
        /// </summary>
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

        #region Methods
        /// <summary>
        /// Loads all members in from the database
        /// </summary>
        /// <returns></returns>
        protected override async Task LoadAllAsync()
        {
            // Create factory, and get the instance
            RepositoryFactory<RankingRepository, Ranking> rankingFactory = RepositoryFactory<RankingRepository, Ranking>.GetInstance();
            // Create repository with the factory
            RankingRepository rankingRepository = rankingFactory.Create();
            // Get all reservations
            IEnumerable<Ranking> rankings = await rankingRepository.GetAllAsync();
            // Replace collection
            Rankings.ReplaceWith(rankings);
        }
        #endregion
    }
}