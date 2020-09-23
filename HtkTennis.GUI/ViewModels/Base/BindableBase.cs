using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace HtkTennis.ViewModels.Base
{
    /// <summary>
    /// Implementation of <see cref="INotifyPropertyChanged" /> to simplify models
    /// </summary>
    public abstract class BindableBase: INotifyPropertyChanged
    {
        /// <summary>
        /// Event for property change notifications.
        /// </summary>
        public virtual event PropertyChangedEventHandler PropertyChanged = delegate { };

        /// <summary>
        /// Checks if a property already matches a desired value. 
        /// Sets the property and notifies listeners only when necessary.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="member"></param>
        /// <param name="val"></param>
        /// <param name="propertyName"></param>
        protected virtual void SetProperty<T>(ref T member, T val,
           [CallerMemberName] string propertyName = null)
        {
            // Check if values match
            if(Equals(member, val))
            {
                // Return if values match
                return;
            }
            // Change reference value
            member = val;
            // Raise property changed
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        /// Notifies listeners that a property value has changed.
        /// </summary>
        /// <param name="propertyName"></param>
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            // Raise PropertyChanged event
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}