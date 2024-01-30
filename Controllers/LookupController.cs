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

        [HttpGet("GetById/{id}")]
        public async Task<ActionResult<LookupDto>> GetById(int id)
        {
            var lookup = await _lookupService.GetById(id);
            if (lookup == null) { return NotFound(); }
            return Ok(lookup);
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<List<LookupListItemDto>>> GetAll()
        {
            var lookups = await _lookupService.GetAll();
            if (lookups == null) { return NotFound(); }
            return Ok(lookups);
        }

        [HttpGet("GetLookupsByCategory/{code}")]
        public async Task<ActionResult<List<LookupListItemDto>>> GetLookupsByCategory(string code)
        {
            var lookups = await _lookupService.GetLookupsByCategory(code);
            return lookups;
        }

        [HttpPost("AddUpdate/{id?}")]
        public async Task<ActionResult<bool>> AddUpdate(int? id, LookupDto lookup)
        {
            var isAdded = await _lookupService.AddUpdate(id, lookup);
            return Ok(isAdded);
        }

        [HttpDelete("Delete/{id}")]
        public async Task Delete(int id)
        {
            await _lookupService.Delete(id);
        }
    }
}