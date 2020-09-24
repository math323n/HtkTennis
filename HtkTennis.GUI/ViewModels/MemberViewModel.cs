using HtkTennis.DataAccess.Base;
using HtkTennis.DataAccess.Factory;
using HtkTennis.Entities;
using HtkTennis.Utilities;

using HtkTennisGui.ViewModels.Base;

using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace HtkTennis.GUI.ViewModels
{

    public class MemberViewModel: ViewModelBase
    {
        #region Fields
        protected ObservableCollection<Member> members;
        protected Member selectedMember;
        #endregion

        #region Constructor
        public MemberViewModel()
        {
            // Initialize collection to prevent error with the ReplaceWith extention method
            members = new ObservableCollection<Member>();
        }
        #endregion

        #region Properties
        /// <summary>
        /// The displayed members in the view
        /// </summary>
        public ObservableCollection<Member> Members
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

        /// <summary>
        /// The selected member in the view
        /// </summary>
        public Member SelectedMember
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

        #region Methods
        /// <summary>
        /// Loads all members in from the database
        /// </summary>
        /// <returns></returns>
        protected override async Task LoadAllAsync()
        {
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