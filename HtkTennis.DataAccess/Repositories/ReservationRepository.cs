using HtkTennis.DataAccess.Base;
using HtkTennis.Entities;

using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HtkTennis.DataAccess.Repositories
{

    public class ReservationRepository: RepositoryBase<Reservation>
    {
        /// <summary>
        /// Returns all reservations included with members and which court
        /// </summary>
        /// <returns></returns>
        public override async Task<IEnumerable<Reservation>> GetAllAsync()
        {
            return await context.Set<Reservation>()
                .Include("Members")
                .Include("Courts")
                .ToListAsync();
        }
    }
}