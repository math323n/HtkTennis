using HtkTennis.DataAccess.Base;
using HtkTennis.DataAccess.Factory;
using HtkTennis.DataAccess.Repositories;
using HtkTennis.Entities;
using HtkTennis.Utilities;
using HtkTennisGui.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace HtkTennis.GUI.ViewModels
{
    public class ReservationViewModel: ViewModelBase<Reservation>
    {
        #region Fields
        protected ObservableCollection<Court> courts;
        protected Court selectedCourt;
        protected ObservableCollection<Member> members;
        protected Member selectedMember;
        #endregion

        #region Constructor
        public ReservationViewModel()
        {
            // Initialize collections
            courts = new ObservableCollection<Court>();
            members = new ObservableCollection<Member>();
        }
        #endregion

        #region Properties

        #region Courts
        /// <summary>
        /// The courts in the Courts ComboBox in the view
        /// </summary>
        public ObservableCollection<Court> Courts
        {
            get { return courts; }
            set
            {
                SetProperty(ref courts, value);
            }
        }

        /// <summary>
        /// The selected Court of the Courts ComboBox in the view
        /// </summary>
        public virtual Court SelectedCourt
        {
            get { return selectedCourt; }
            set
            {
                SetProperty(ref selectedCourt, value);
            }
        }
        #endregion

        #region Members
        /// <summary>
        /// The members in the view available for selection when making a reservation
        /// </summary>
        public ObservableCollection<Member> Members
        {
            get { return members; }
            set
            {
                SetProperty(ref members, value);
            }
        }

        /// <summary>
        /// The selected Member in the view
        /// </summary>
        public virtual Member SelectedMember
        {
            get { return selectedMember; }
            set
            {
                SetProperty(ref selectedMember, value);
            }
        }
        #endregion

        #endregion

        #region Methods
        /// <summary>
        /// Override of <see cref="LoadAllAsync"/> to use <see cref="ReservationRepository"/> instead for including navigation properties
        /// </summary>
        /// <returns></returns>
        protected override async Task LoadAllAsync()
        {
            // Create factory, and get the instance
            RepositoryFactory<ReservationRepository, Reservation> reservationFactory = RepositoryFactory<ReservationRepository, Reservation>.GetInstance();
            // Create repository with the factory
            ReservationRepository reservationRepository = reservationFactory.Create();
            // Get all reservations
            IEnumerable<Reservation> reservations = await reservationRepository.GetAllAsync();
            // Replace collection
            Items.ReplaceWith(reservations);


            // Create factory, and get the instance
            RepositoryFactory<RepositoryBase<Court>, Court> courtFactory = RepositoryFactory<RepositoryBase<Court>, Court>.GetInstance();
            // Create repository with the factory
            RepositoryBase<Court> courtRepository = courtFactory.Create();
            // Get all reservations
            IEnumerable<Court> courts = await courtRepository.GetAllAsync();
            // Replace collection
            Courts.ReplaceWith(courts);


            // Create factory, and get the instance
            RepositoryFactory<RepositoryBase<Member>, Member> memberFactory = RepositoryFactory<RepositoryBase<Member>, Member>.GetInstance();
            // Create repository with the factory
            RepositoryBase<Member> memberRepository = memberFactory.Create();
            // Get all reservations
            IEnumerable<Member> members = await memberRepository.GetAllAsync();
            // Replace collection
            Members.ReplaceWith(members);
        }
        #endregion
    }
}