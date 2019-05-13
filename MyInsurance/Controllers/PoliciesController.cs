using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using MyInsurance.DLA;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyInsurance.Models;
using System.Linq;
using System;

namespace MyInsurance.Controllers
{
    [Route("api/policy")]
    [ApiController]
    public class PolicyController : ControllerBase
    {
        private readonly EnsuranceContext _context;

        public PolicyController(EnsuranceContext context)
        {
            _context = context;
        }

        // GET api/policy
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Policy>>> Get()
        {
            return await _context.Policies
                .Include(p => p.RiskType)
                .Include(p => p.PolicyCoverage)
                    .ThenInclude(c => c.Coverage)
                .ToListAsync();
        }

        // GET api/policy/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Policy>> Get(int id)
        {
            var policy = await _context.Policies
                .Include(p => p.RiskType)
                .Include(p => p.PolicyCoverage)
                    .ThenInclude(pcoverave => pcoverave.Coverage)
                .Where(p => p.ID == id).FirstAsync();
            if (policy == null)
            {
                return NotFound();
            }
            return policy;

        }

        // POST api/policy
        [HttpPost]
        public async Task<ActionResult<Policy>> Post(PolicyRequest request)
        {
            Policy policy = Policy.GetPolicyFromRequest(request);
            if (policy != null && Policy.ValidPolicy(policy))
            {
                _context.Policies.Add(policy);
                await _context.SaveChangesAsync();
                return CreatedAtAction(nameof(Get), new { id = policy.ID }, policy);
            }
            return BadRequest();
        }

        // PUT api/policy/5
        [HttpPut("{id}")]
        public async Task<ActionResult<Policy>> Put(int id, PolicyRequest request)
        {
            if (id != request.ID)
            {
                return BadRequest();
            }
            Policy policy = Policy.GetPolicyFromRequest(request);
            if (policy != null && Policy.ValidPolicy(policy))
            {
                _context.Entry(policy).State = EntityState.Modified;
            }
            await _context.SaveChangesAsync();
            return NoContent();
        }

        // DELETE api/policy/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var policy = await _context.Policies.FindAsync(id);
            if (policy == null)
            {
                return NotFound();
            }
            _context.Remove(policy);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
