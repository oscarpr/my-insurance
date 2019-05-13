using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyInsurance.Models;
using MyInsurance.DLA;
using Microsoft.EntityFrameworkCore;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyInsurance.Controllers
{
    [Route("api/coverage-types")]
    public class CoverageTypesController : Controller
    {
        private readonly EnsuranceContext _context;
        public CoverageTypesController(EnsuranceContext context)
        {
            _context = context;
        }

        // GET: api/coverage-types
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CoverageType>>> Get()
        {
            return await _context.CoverageType.ToListAsync();
        }

    }
}
