using HtkTennis.DataAccess.Base;
using HtkTennis.DataAccess.Factory;
using HtkTennis.Entities;
using HtkTennis.GUI.ViewModels.Commands;
using HtkTennis.Utilities;

using HtkTennisGui.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Data;

namespace HtkTennis.GUI.ViewModels
{
    /// <summary>
    /// ViewModel for Member View
    /// </summary>
    public class MemberViewModel: ViewModelBase<Member>
    {
        #region Fields
        protected string firstName;
        protected string lastName;
        protected string address;
        protected string email;
        protected string phone;
        protected DateTime birthdate;
        protected RelayCommand<object> addCommand;
        protected RelayCommand<object> editCommand;
        protected RelayCommand<object> saveCommand;
        protected RelayCommand<object> deleteCommand;
        private bool currentlyAdding = false;

        #endregion

        #region Constructor
        public MemberViewModel()
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
        /// Firsname TextBox in the view
        /// </summary>
        public virtual string FirstName
        {
            get { return firstName; }
            set
            {
                SetProperty(ref firstName, value);
            }
        }

        /// <summary>
        /// Lastname TextBox in the view
        /// </summary>
        public virtual string LastName
        {
            get { return lastName; }
            set
            {
                SetProperty(ref lastName, value);
            }
        }

        /// <summary>
        /// Address TextBox in the view
        /// </summary>
        public virtual string Address
        {
            get { return address; }
            set
            {
                SetProperty(ref address, value);
            }
        }

        /// <summary>
        /// Email TextBox in the view
        /// </summary>
        public virtual string Email
        {
            get { return email; }
            set
            {
                SetProperty(ref email, value);
            }
        }

        /// <summary>
        /// Phone TextBox in the view
        /// </summary>
        public virtual string Phone
        {
            get { return phone; }
            set
            {
                SetProperty(ref phone, value);
            }
        }

        /// <summary>
        /// Birthdate DatePicker in the view
        /// </summary>
        public virtual DateTime Birthdate
        {
            get { return birthdate; }
            set
            {
                SetProperty(ref birthdate, value);
            }
        }
        #endregion

        #region Commands
        /// <summary>
        /// Command for adding Members
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
        /// Command for editing Members
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
        /// Command for saving Members
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
        /// Command for deleting Members
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
            if(!currentlyAdding)
            {
                // Remove selected item
                SelectedItem = new Member() { Birthdate = DateTime.Now };

                // Set textbox values
                FirstName = SelectedItem.FirstName;
                LastName = SelectedItem.LastName;
                Address = SelectedItem.Address;
                Email = SelectedItem.Email;
                Phone = SelectedItem.Phone;
                Birthdate = SelectedItem.Birthdate;
                currentlyAdding = true;
            }
            else
            {
                SelectedItem = null;
                FirstName = null;
                LastName = null;
                Address = null;
                Email = null;
                Phone = null;
                currentlyAdding = false;
            }
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
            if(parameter is Member member && member.PkMemberId >= 1 && FirstName == null)
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
            if(parameter is Member member)
            {

                FirstName = member.FirstName;
                LastName = member.LastName;
                Address = member.Address;
                Email = member.Email;
                Phone = member.Phone;
                Birthdate = member.Birthdate;
            }
        }
        #endregion

        #region Save
        protected virtual bool CanSave(object parameter)
        {
            // Null and type check
            if(parameter is Member && FirstName != null)
            {
                return true;
            }

            // Return false if the conditions where not met
            return false;
        }

        protected virtual async void Save(object parameter)
        {
            // Create factory, and get the instance
            RepositoryFactory<RepositoryBase<Member>, Member> repositoryFactory = RepositoryFactory<RepositoryBase<Member>, Member>.GetInstance();
            // Create repository with the factory
            RepositoryBase<Member> itemRepository = repositoryFactory.Create();

            if(parameter is Member member)
            {
                // Null check, and id check
                if(member.PkMemberId >= 1)
                {
                    // Assign values
                    SelectedItem.FirstName = FirstName;
                    SelectedItem.LastName = LastName;
                    SelectedItem.Address = Address;
                    SelectedItem.Email = Email;
                    SelectedItem.Phone = Phone;
                    SelectedItem.Birthdate = Birthdate;

                    // Save changes made
                    await itemRepository.UpdateAsync();
                }
                else
                {
                    Member newMember = new Member()
                    {
                        FirstName = FirstName,
                        LastName = LastName,
                        Address = Address,
                        Email = Email,
                        Phone = Phone,
                        Birthdate = Birthdate,
                    };

                    await itemRepository.AddAsync(newMember);

                    // Add member to items
                    Items.Add(newMember);
                }


                // Reset values in the viewa
                FirstName = null;
                LastName = null;
                Address = null;
                Email = null;
                Phone = null;
                Birthdate = DateTime.Now;

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
            if(parameter is Member member && member.PkMemberId >= 1 && FirstName != null)
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
            RepositoryFactory<RepositoryBase<Member>, Member> repositoryFactory = RepositoryFactory<RepositoryBase<Member>, Member>.GetInstance();
            // Create repository with the factory
            RepositoryBase<Member> itemRepository = repositoryFactory.Create();
            // Save changes made
            await itemRepository.DeleteAsync(SelectedItem);

            // Remove SelectedItem from the items collection
            Items.Remove(SelectedItem);

            // Reset values in the view
            FirstName = null;
            LastName = null;
            Address = null;
            Email = null;
            Phone = null;
            Birthdate = DateTime.Now;

            // Get the listview of the items
            ICollectionView view = CollectionViewSource.GetDefaultView(Items);
            // Refresh listview
            view.Refresh();
        }
        #endregion

        #endregion
    }
}