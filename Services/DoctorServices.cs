using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SpinelTest.DTOs;
using SpinelTest.Models;

namespace SpinelTest.Services
{
    public interface IDoctorServices
    {
        Task<DoctorDto> GetById(int id);
        Task<List<DoctorDto>> GetAll();
        Task<bool> AddUpdate(int? id, DoctorDto student);
        Task Delete(int id);
    }
    public class DoctorServices : IDoctorServices
    {
        private readonly DBContext _dBContext;
        private readonly IMapper _mapper;

        public DoctorServices(DBContext dbContex, IMapper mapper)
        {
            _dBContext = dbContex;
            _mapper = mapper;
        }

        public async Task<List<DoctorDto>> GetAll()
        {
            var doctors = await _dBContext.Doctor
                .Where(i => i.IsDeleted == false)
                .Include(d => d.Specification)
                .Include(d => d.Location)
                .ToListAsync();
            return _mapper.Map<List<DoctorDto>>(doctors);
        }

        public async Task<DoctorDto> GetById(int id)
        {
            var doctor = await _dBContext.Doctor
                .Where(s => s.Id == id && s.IsDeleted == false)
                .Include(d => d.Specification)
                .Include(d => d.Location)
                .FirstOrDefaultAsync();
            if (doctor == null) { return null; }
            return _mapper.Map<DoctorDto>(doctor);
        }

        public async Task Delete(int id)
        {
            var doctor = await _dBContext.Doctor.Where(d => d.Id == id).FirstOrDefaultAsync();
            doctor.IsDeleted = true;
            _dBContext.SaveChanges();
        }

        public async Task<bool> AddUpdate(int? id, DoctorDto doctor)
        {
            var newDoctor = _mapper.Map<Doctor>(doctor);
            try
            {
                if (id == null)
                {
                    newDoctor.IsDeleted = false;
                    await _dBContext.Doctor.AddAsync(newDoctor);
                }
                else
                {
                    var existingDoctor = await _dBContext.Doctor.Where(s => s.Id == id).FirstOrDefaultAsync();
                    existingDoctor.Name = newDoctor.Name;
                    existingDoctor.SpecificationId = newDoctor.SpecificationId;
                    existingDoctor.LocationId = newDoctor.LocationId;
                    existingDoctor.FromWorkingHour = newDoctor.FromWorkingHour?.ToLocalTime();
                    existingDoctor.ToWorkingHour = newDoctor.ToWorkingHour?.ToLocalTime();
                    existingDoctor.IsDeleted = newDoctor.IsDeleted ?? false;
                }
                _dBContext.SaveChanges();
            }
            catch
            {
                return false;
            }
            return true;
        }
    }
}
