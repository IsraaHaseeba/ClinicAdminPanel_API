using Microsoft.AspNetCore.Mvc;
using SpinelTest.DTOs;
using SpinelTest.Models;
using SpinelTest.Services;
using System.Numerics;

namespace SpinelTest.Controllers
{
    [ApiController]
    [Route("/Doctor")]
    public class DoctorController : ControllerBase
    {
        private readonly IDoctorServices _doctorServices;
        public DoctorController(IDoctorServices doctorServices) {
            _doctorServices = doctorServices;
        }

        [HttpGet("GetById/{id}")]
        public async Task<ActionResult<DoctorDto>> GetById(int id)
        {
            var doctor = await _doctorServices.GetById(id);
            if(doctor == null) { return NotFound(); }
            return Ok(doctor);
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<List<DoctorListItemDto>>> GetAll()
        {
            var doctors = await _doctorServices.GetAll();
            if (doctors == null) { return NotFound(); }
            return Ok(doctors);
        }

        [HttpPost("AddUpdate/{id?}")]
        public async Task<ActionResult<bool>> AddUpdate(int? id, DoctorDto doctor)
        {
            var isAdded = await _doctorServices.AddUpdate(id, doctor);
            return Ok(isAdded);
        }

        [HttpDelete("Delete/{id}")]  
        public async Task Delete(int id)
        {
            await _doctorServices.Delete(id);
        }
    }
}
