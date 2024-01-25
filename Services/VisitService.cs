using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SpinelTest.DTOs;
using SpinelTest.Models;

namespace SpinelTest.Services
{
    public interface IVisitService
    {
        Task<VisitDto> GetById(int id);
        Task<List<VisitDto>> GetAll();
        Task<bool> AddUpdate(int? id, VisitDto student);
        Task Delete(int id);
    }
    public class VisitService : IVisitService
    {
        private readonly DBContext _dBContext;
        private readonly IMapper _mapper;
        public VisitService(DBContext dbContex, IMapper mapper)
        {
            _dBContext = dbContex;
            _mapper = mapper;
        }
        public async Task<List<VisitDto>> GetAll()
        {
            var visits = await _dBContext.Visit
                .Where(i => i.IsDeleted == false)
                .Include(v => v.Doctor)
                .Include(v => v.Patient)
                .ToListAsync();
            return _mapper.Map<List<VisitDto>>(visits);
        }

        public async Task<VisitDto> GetById(int id)
        {
            var visit = await _dBContext.Visit
                .Where(s => s.Id == id && s.IsDeleted == false)
                .FirstOrDefaultAsync();
            if (visit == null) { return null; }
            return _mapper.Map<VisitDto>(visit);
        }

        public async Task<bool> AddUpdate(int? id, VisitDto visit)
        {
            var newVisit = _mapper.Map<Visit>(visit);
            try
            {
                if (id == null)
                {
                    newVisit.IsDeleted = false;
                    await _dBContext.Visit.AddAsync(newVisit);
                }
                else
                {
                    var existingVisit = await _dBContext.Visit.Where(s => s.Id == id).FirstOrDefaultAsync();
                    existingVisit.PatientId = newVisit.PatientId;
                    existingVisit.DoctorId = newVisit.DoctorId;
                    existingVisit.VisitTime = newVisit.VisitTime;
                    existingVisit.IsDeleted = newVisit.IsDeleted ?? false;
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
            var visit = await _dBContext.Visit.Where(d => d.Id == id).FirstOrDefaultAsync();
            visit.IsDeleted = true;
            _dBContext.SaveChanges();
        }
    }
}

