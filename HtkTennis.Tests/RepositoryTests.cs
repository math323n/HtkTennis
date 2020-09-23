using HtkTennis.DataAccess.Base;
using HtkTennis.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HtkTennis.Tests
{
    [TestClass]
    public class RepositoryTests
    {
        /// <summary>
        /// Tests if a member returned by id is not null
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task GetMemberById()
        {
            RepositoryBase<Member> repository;
            Member member;

            repository = new RepositoryBase<Member>();
            member = await repository.GetByIdAsync(1);

            Assert.IsNotNull(member);
        }

        /// <summary>
        /// Tests if all members are returned
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task GetAllMembers()
        {
            RepositoryBase<Member> repository;
            IEnumerable<Member> members;

            repository = new RepositoryBase<Member>();
            members = await repository.GetAllAsync();

            Assert.IsTrue(members.Count() > 0);
        }
    }
}
