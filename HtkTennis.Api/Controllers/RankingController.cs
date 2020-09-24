using HtkTennis.DataAccess;
using HtkTennis.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HtkTennis.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class RankingController
    {
        [HttpGet("all")]
        public async Task<IEnumerable<Ranking>> GetAllAsync()
        {
            return await new RankingRepository().GetAllAsync();
        }
    }
}