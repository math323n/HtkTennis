using HtkTennis.Entities;
using HtkTennisGui.ViewModels.Base;
using System.Collections.ObjectModel;

namespace HtkTennis.GUI.ViewModels
{

    public class MemberViewModel: ViewModelBase
    {
        #region Fields
        protected ObservableCollection<Member> members;
        protected Member selectedMember;
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor for MemberViewModel
        /// </summary>
        public MemberViewModel()
        {
            Members = new ObservableCollection<Member>();
        }
        #endregion

        #region Properties
        public virtual ObservableCollection<Member> Members
        {
            get
            {
                return members;
            }
            set
            {
                SetProperty(ref members, value);
            }
        }

        public virtual Member SelectedMember
        {
            get
            {
                return selectedMember;
            }
            set
            {
                SetProperty(ref selectedMember, value);
            }
        }
        #endregion
    }
}