using Microsoft.AspNetCore.Mvc;
using SpinelTest.DTOs;
using SpinelTest.Services;

namespace SpinelTest.Controllers
{
    [ApiController]
    [Route("/Visit")]
    public class VisitController : ControllerBase
    {
        private readonly IVisitService _visitService;
        public VisitController(IVisitService visitService)
        {
            _visitService = visitService;
        }

        [HttpGet("GetById/{id}")]
        public async Task<ActionResult<VisitDto>> GetById(int id)
        {
            var visit = await _visitService.GetById(id);
            if (visit == null) { return NotFound(); }
            return Ok(visit);
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<List<VisitListItemDto>>> GetAll()
        {
            var visits = await _visitService.GetAll();
            if (visits == null) { return NotFound(); }
            return Ok(visits);
        }

        [HttpPost("AddUpdate/{id?}")]
        public async Task<ActionResult<bool>> AddUpdate(int? id, VisitDto visit)
        {
            var isAdded = await _visitService.AddUpdate(id, visit);
            return Ok(isAdded);
        }

        [HttpDelete("Delete/{id}")]
        public async Task Delete(int id)
        {
            await _visitService.Delete(id);
        }
    }
}
