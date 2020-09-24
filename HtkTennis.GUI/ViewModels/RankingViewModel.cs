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
    /// <summary>
    /// ViewModel for Ranking View
    /// </summary>
    public class RankingViewModel: ViewModelBase<Ranking>
    {
        #region Methods
        /// <summary>
        /// Override of <see cref="LoadAllAsync"/> to use <see cref="RankingRepository"/> instead for including navigation properties
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
            Items.ReplaceWith(rankings);
        }
        #endregion
    }
}