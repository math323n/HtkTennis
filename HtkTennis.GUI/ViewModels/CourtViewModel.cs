using HtkTennis.DataAccess.Base;
using HtkTennis.DataAccess.Factory;
using HtkTennis.Entities;
using HtkTennis.Utilities;

using HtkTennisGui.ViewModels.Base;

using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace HtkTennis.GUI.ViewModels
{
    public class CourtViewModel: ViewModelBase
    {
        #region Fields
        protected ObservableCollection<Court> courts;
        protected Court selectedCourt;
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor for MemberViewModel
        /// </summary>
        public CourtViewModel()
        {
            // Initialize collection to prevent error with the ReplaceWith extention method
            courts = new ObservableCollection<Court>();
        }
        #endregion

        #region Properties
        /// <summary>
        /// The displayed courts in the view
        /// </summary>
        public virtual ObservableCollection<Court> Courts
        {
            get
            {
                return courts;
            }
            set
            {
                SetProperty(ref courts, value);
            }
        }

        /// <summary>
        /// The selected court in the view
        /// </summary>
        public virtual Court SelectedCourt
        {
            get
            {
                return selectedCourt;
            }
            set
            {
                SetProperty(ref selectedCourt, value);
            }
        }
        #endregion

        /// <summary>
        /// Loads all members in from the database
        /// </summary>
        /// <returns></returns>
        protected override async Task LoadAllAsync()
        {
            // Create factory, and get the instance
            RepositoryFactory<RepositoryBase<Court>, Court> courtFactory = RepositoryFactory<RepositoryBase<Court>, Court>.GetInstance();
            // Create repository with the factory
            RepositoryBase<Court> courtRepository = courtFactory.Create();
            // Get all reservations
            IEnumerable<Court> courts = await courtRepository.GetAllAsync();
            // Replace collection
            Courts.ReplaceWith(courts);
        }
    }
}