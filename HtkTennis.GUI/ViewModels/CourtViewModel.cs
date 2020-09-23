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
        protected ObservableCollection<Member> courts;
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
        public virtual ObservableCollection<Member> Members
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

        public virtual Court SelectedMember
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
