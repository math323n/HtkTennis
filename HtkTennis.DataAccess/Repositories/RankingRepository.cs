using HtkTennis.DataAccess.Base;
using HtkTennis.Entities;

using Microsoft.EntityFrameworkCore;

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HtkTennis.DataAccess
{
    public class RankingRepository: RepositoryBase<Ranking>
    {
        /// <summary>
        /// Gets all rankings async
        /// </summary>
        /// <returns></returns>
        public override async Task<IEnumerable<Ranking>> GetAllAsync()
        {
            return await context.Set<Ranking>().Include("FkMember").OrderByDescending(r => r.Points).ToListAsync();
        }
    }
}