using HtkTennis.DataAccess.Base;
using HtkTennis.DataAccess.Factory;
using HtkTennis.Entities;
using HtkTennis.GUI.ViewModels.Commands;
using HtkTennis.Utilities;

using HtkTennisGui.ViewModels.Base;

using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Data;

namespace HtkTennis.GUI.ViewModels
{
    public class CourtViewModel: ViewModelBase<Court>
    {
        #region Fields
        protected string courtName;
        protected RelayCommand<object> addCommand;
        protected RelayCommand<object> editCommand;
        protected RelayCommand<object> saveCommand;
        protected RelayCommand<object> deleteCommand;
        #endregion

        #region Constructor
        public CourtViewModel()
        {
            // Initialize relay commands
            AddCommand = new RelayCommand<object>(Add, CanAdd);
            EditCommand = new RelayCommand<object>(Edit, CanEdit);
            SaveCommand = new RelayCommand<object>(Save, CanSave);
            DeleteCommand = new RelayCommand<object>(Delete, CanDelete);
        }
        #endregion

        #region Properties

        #region Information Items
        /// <summary>
        /// Court name TextBox in the view
        /// </summary>
        public virtual string CourtName
        {
            get { return courtName; }
            set
            {
                SetProperty(ref courtName, value);
            }
        }
        #endregion

        #region Commands
        /// <summary>
        /// Command for adding Courts
        /// </summary>
        public virtual RelayCommand<object> AddCommand
        {
            get
            {
                return addCommand;
            }
            set
            {
                SetProperty(ref addCommand, value);
            }
        }

        /// <summary>
        /// Command for editing Courts
        /// </summary>
        public virtual RelayCommand<object> EditCommand
        {
            get
            {
                return editCommand;
            }
            set
            {
                SetProperty(ref editCommand, value);
            }
        }

        /// <summary>
        /// Command for saving Courts
        /// </summary>
        public virtual RelayCommand<object> SaveCommand
        {
            get
            {
                return saveCommand;
            }
            set
            {
                SetProperty(ref saveCommand, value);
            }
        }

        /// <summary>
        /// Command for deleting Courts
        /// </summary>
        public virtual RelayCommand<object> DeleteCommand
        {
            get
            {
                return deleteCommand;
            }
            set
            {
                SetProperty(ref deleteCommand, value);
            }
        }
        #endregion

        #endregion

        #region Methods

        #region Add
        /// <summary>
        /// Validates if the delete button can be pressed
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        protected virtual bool CanAdd(object parameter)
        {
            // Return true
            return true;
        }

        /// <summary>
        /// Eventhandler for when the delete button is pressed in the view
        /// </summary>
        /// <param name="parameter"></param>
        protected virtual void Add(object parameter)
        {
            // Remove selected item
            SelectedItem = new Court();

            // Set textbox values
            CourtName = SelectedItem.CourtName;

        }
        #endregion

        #region Edit
        /// <summary>
        /// Validates if the delete button can be pressed
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        protected virtual bool CanEdit(object parameter)
        {
            // Null and type check
            if(parameter is Court court && court.PkCourtId >= 1 && CourtName == null)
            {
                return true;
            }

            // Return false if the conditions where not met
            return false;
        }

        /// <summary>
        /// Eventhandler for when the delete button is pressed in the view
        /// </summary>
        /// <param name="parameter"></param>
        protected virtual void Edit(object parameter)
        {
            if(parameter is Court court)
            {
                CourtName = court.CourtName;
            }
        }
        #endregion

        #region Save
        protected virtual bool CanSave(object parameter)
        {
            // Null and type check
            if(parameter is Court && CourtName != null)
            {
                return true;
            }

            // Return false if the conditions where not met
            return false;
        }

        protected virtual async void Save(object parameter)
        {
            // Create factory, and get the instance
            RepositoryFactory<RepositoryBase<Court>, Court> repositoryFactory = RepositoryFactory<RepositoryBase<Court>, Court>.GetInstance();
            // Create repository with the factory
            RepositoryBase<Court> itemRepository = repositoryFactory.Create();

            if(parameter is Court court)
            {
                // Null check, and id check
                if(court.PkCourtId >= 1)
                {
                    // Assign values
                    SelectedItem.CourtName = CourtName;

                    // Save changes made
                    await itemRepository.UpdateAsync();
                }
                else
                {
                    Court newCourt = new Court()
                    {
                        CourtName = CourtName,
                    };

                    await itemRepository.AddAsync(newCourt);

                    // Add court to items
                    Items.Add(newCourt);
                }

                // Reset values in the view
                CourtName = null;

                // Get the listview of the items
                ICollectionView view = CollectionViewSource.GetDefaultView(Items);
                // Refresh listview
                view.Refresh();
            }
        }
        #endregion

        #region Delete
        /// <summary>
        /// Validates if the delete button can be pressed
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        protected virtual bool CanDelete(object parameter)
        {
            // Null and type check
            if(parameter is Court court && court.PkCourtId >= 1 && CourtName != null)
            {
                return true;
            }

            // Return false if the conditions where not met
            return false;
        }

        /// <summary>
        /// Eventhandler for when the delete button is pressed in the view
        /// </summary>
        /// <param name="parameter"></param>
        protected virtual async void Delete(object parameter)
        {
            // Create factory, and get the instance
            RepositoryFactory<RepositoryBase<Court>, Court> repositoryFactory = RepositoryFactory<RepositoryBase<Court>, Court>.GetInstance();
            // Create repository with the factory
            RepositoryBase<Court> itemRepository = repositoryFactory.Create();
            // Save changes made
            await itemRepository.DeleteAsync(SelectedItem);

            // Remove SelectedItem from the items collection
            Items.Remove(SelectedItem);

            // Reset values in the view
            CourtName = null;

            // Get the listview of the items
            ICollectionView view = CollectionViewSource.GetDefaultView(Items);
            // Refresh listview
            view.Refresh();
        }
        #endregion

        #endregion
    }
}