using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyInsurance.DLA;
using MyInsurance.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyInsurance.Controllers
{
    [Route("api/risk-types")]
    public class RiskTypesController : Controller
    {
        private readonly EnsuranceContext _context;

        public RiskTypesController(EnsuranceContext context)
        {
            _context = context;
        }


        // GET: api/values
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RiskType>>> Get()
        {
            return await _context.RiskType.ToListAsync();
        }
    }
}
