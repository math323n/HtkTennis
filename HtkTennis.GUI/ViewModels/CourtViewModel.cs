using HtkTennis.Entities;
using HtkTennisGui.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

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
            Courts = new ObservableCollection<Court>();
        }
        #endregion

        #region Properties
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
    }
}
