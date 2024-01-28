using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SpinelTest.DTOs;
using SpinelTest.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace SpinelTest.Services
{
    public interface IPatientService
    {
        Task<PatientDto> GetById(int id);
        Task<List<PatientDto>> GetAll();
        Task<bool> AddUpdate(int? id, PatientDto student);
        Task Delete(int id);
    }
    public class PatientService : IPatientService
    {
        private readonly DBContext _dBContext;
        private readonly IMapper _mapper;
        public PatientService(DBContext dbContex, IMapper mapper)
        {
            _dBContext = dbContex;
            _mapper = mapper;
        }
        public async Task<List<PatientDto>> GetAll()
        {
            var query = _dBContext.Patient
                .Where(i => i.IsDeleted == false);
            var patients = _mapper.ProjectTo<PatientDto>(query).ToList();
            return patients;
        }

        public async Task<PatientDto> GetById(int id)
        {
            var query = _dBContext.Patient
                .Where(s => s.Id == id && s.IsDeleted == false);
            var patients = _mapper.ProjectTo<PatientDto>(query).FirstOrDefault();
            return patients;
        }

        public async Task<bool> AddUpdate(int? id, PatientDto patient)
        {
            var newPatient = _mapper.Map<Patient>(patient);
            try
            {
                if (id == null)
                {
                    newPatient.IsDeleted = false;
                    await _dBContext.Patient.AddAsync(newPatient);
                }
                else
                {
                    var existingPatient = await _dBContext.Patient.Where(s => s.Id == id).FirstOrDefaultAsync();
                    existingPatient.Name = newPatient.Name;
                    existingPatient.Address = newPatient.Address;
                    existingPatient.IdentityNumber = newPatient.IdentityNumber;
                    existingPatient.BirthDate = newPatient.BirthDate;
                    existingPatient.IsDeleted = newPatient.IsDeleted ?? false;
                }
                _dBContext.SaveChanges();
            }
            catch
            {
                return false;
            }

            return true;
        }

        public async Task Delete(int id)
        {
            var patient = await _dBContext.Patient.Where(d => d.Id == id).FirstOrDefaultAsync();
            patient.IsDeleted = true;
            _dBContext.SaveChanges();
        }
    }
}


