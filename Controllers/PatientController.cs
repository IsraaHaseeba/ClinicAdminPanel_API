using Microsoft.AspNetCore.Mvc;
using SpinelTest.DTOs;
using SpinelTest.Services;

namespace SpinelTest.Controllers
{
    [ApiController]
    [Route("/Patient")]
    public class PatientController : ControllerBase
    {
        private readonly IPatientService _patientService;
        public PatientController(IPatientService patientService)
        {
            _patientService = patientService;
        }

        [HttpGet("GetById")]
        public async Task<ActionResult<PatientDto>> GetById(int id)
        {
            var patient = await _patientService.GetById(id);
            if (patient == null) { return NotFound(); }
            return Ok(patient);
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<List<PatientDto>>> GetAll()
        {
            var patients = await _patientService.GetAll();
            if (patients == null) { return NotFound(); }
            return Ok(patients);
        }

        [HttpPost("AddUpdate")]
        public async Task<ActionResult<bool>> AddUpdate(int? id, PatientDto patient)
        {
            var isAdded = await _patientService.AddUpdate(id, patient);
            return Ok(isAdded);
        }

        [HttpDelete("Delete")]
        public async Task<ActionResult<bool>> Delete(int id)
        {
            var isDeleted = await _patientService.Delete(id);
            return Ok(isDeleted);
        }
    }
}

