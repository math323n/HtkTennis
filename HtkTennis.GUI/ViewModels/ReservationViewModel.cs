using HtkTennis.DataAccess.Base;
using HtkTennis.DataAccess.Factory;
using HtkTennis.DataAccess.Repositories;
using HtkTennis.Entities;
using HtkTennis.Utilities;

using HtkTennisGui.ViewModels.Base;

using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace HtkTennis.GUI.ViewModels
{
    public class ReservationViewModel: ViewModelBase<Reservation>
    {
        #region Methods
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
        }
        #endregion
    }
}