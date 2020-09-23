using HtkTennis.Entities;
using HtkTennisGui.ViewModels.Base;
using System.Collections.ObjectModel;

namespace HtkTennis.GUI.ViewModels
{
    public class ReservationViewModel: ViewModelBase
    {
        protected ObservableCollection<Reservation> reservations;
        protected Reservation selectedReservation;

        public ReservationViewModel()
        {
            Reservations = new ObservableCollection<Reservation>();
        }

        public virtual ObservableCollection<Reservation> Reservations
        {
            get
            {
                return reservations;
            }
            set
            {
                SetProperty(ref reservations, value);
            }
        }

        public virtual Reservation SelectedReservation
        {
            get
            {
                return selectedReservation;
            }
            set
            {
                SetProperty(ref selectedReservation, value);
            }
        }
    }
}