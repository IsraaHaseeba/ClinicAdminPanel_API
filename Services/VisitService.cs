using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SpinelTest.DTOs;
using SpinelTest.Models;

namespace SpinelTest.Services
{
    public interface IVisitService
    {
        Task<VisitDto> GetById(int id);
        Task<List<VisitListItemDto>> GetAll();
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
        public async Task<List<VisitListItemDto>> GetAll()
        {
            var query = _dBContext.Visit
                .Where(i => i.IsDeleted == false);
            var visits = _mapper.ProjectTo<VisitListItemDto>(query).ToList();
            return visits;
        }

        public async Task<VisitDto> GetById(int id)
        {
            var query = _dBContext.Visit
                .Where(s => s.Id == id && s.IsDeleted == false);
            var visit = _mapper.ProjectTo<VisitDto>(query).FirstOrDefault();
            return visit;
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

