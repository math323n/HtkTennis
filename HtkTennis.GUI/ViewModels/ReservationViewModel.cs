using HtkTennis.DataAccess.Base;
using HtkTennis.DataAccess.Factory;
using HtkTennis.DataAccess.Repositories;
using HtkTennis.Entities;
using HtkTennis.GUI.ViewModels.Commands;
using HtkTennis.Utilities;

using HtkTennisGui.ViewModels.Base;

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace HtkTennis.GUI.ViewModels
{
    public class ReservationViewModel: ViewModelBase<Member>
    {
        #region Fields
        protected Member fkFirstMember;
        protected Member fkSecondMember;
        protected DateTime startTime;
        protected DateTime endTime;

        protected RelayCommand<object> addCommand;
        protected RelayCommand<object> editCommand;
        protected RelayCommand<object> saveCommand;
        protected RelayCommand<object> deleteCommand;
        #endregion

        #region Constructor
        public ReservationViewModel()
        {
            // Initialize relay commands
            /*AddCommand = new RelayCommand<object>(Add, CanAdd);
            EditCommand = new RelayCommand<object>(Edit, CanEdit);
            SaveCommand = new RelayCommand<object>(Save, CanSave);
            DeleteCommand = new RelayCommand<object>(Delete, CanDelete);*/
        }
        #endregion

        #region Properties

        /// <summary>
        /// Firsname TextBox in the view
        /// </summary>
        public virtual Member FkFirstMember
        {
            get { return fkFirstMember; }
            set
            {
                SetProperty(ref fkFirstMember, value);
            }
        }

        /// <summary>
        /// First member TextBox in the view
        /// </summary>
        public virtual Member FkSecondMember
        {
            get { return fkSecondMember; }
            set
            {
                SetProperty(ref fkSecondMember, value);
            }
        }

        /// <summary>
        /// Birthdate DatePicker in the view
        /// </summary>
        public virtual DateTime StartTime
        {
            get { return startTime; }
            set
            {
                SetProperty(ref startTime, value);
            }
        }

        /// <summary>
        /// Birthdate DatePicker in the view
        /// </summary>
        public virtual DateTime EndTime
        {
            get { return endTime; }
            set
            {
                SetProperty(ref endTime, value);
            }
        }
        #endregion

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
            SelectedItem = new Member() { Birthdate = DateTime.Now };

            // Set textbox values
          FkFirstMember = (Member)SelectedItem.ReservationFkFirstMember;
            FkSecondMember = (Member)SelectedItem.ReservationFkSecondMember;


        }


  /*
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
        }*/
    }
}