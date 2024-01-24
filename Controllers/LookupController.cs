using Microsoft.AspNetCore.Mvc;
using SpinelTest.DTOs;
using SpinelTest.Services;

namespace SpinelTest.Controllers
{
    [ApiController]
    [Route("/Lookup")]
    public class LookupController : ControllerBase
    {
        private readonly ILookupService _lookupService;
        public LookupController(ILookupService lookupService)
        {
            _lookupService = lookupService;
        }

        [HttpGet("GetById")]
        public async Task<ActionResult<LookupDto>> GetById(int id)
        {
            var lookup = await _lookupService.GetById(id);
            if (lookup == null) { return NotFound(); }
            return Ok(lookup);
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<List<LookupDto>>> GetAll()
        {
            var lookups = await _lookupService.GetAll();
            if (lookups == null) { return NotFound(); }
            return Ok(lookups);
        }

        [HttpPost("AddUpdate")]
        public async Task<ActionResult<bool>> AddUpdate(int? id, LookupDto lookup)
        {
            var isAdded = await _lookupService.AddUpdate(id, lookup);
            return Ok(isAdded);
        }

        [HttpDelete("Delete")]
        public async Task<ActionResult<bool>> Delete(int id)
        {
            var isDeleted = await _lookupService.Delete(id);
            return Ok(isDeleted);
        }
    }
}