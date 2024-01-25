using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using SpinelTest.DTOs;
using SpinelTest.Models;

namespace SpinelTest.Services
{
    public interface ILookupService
    {
        Task<LookupDto> GetById(int id);
        Task<List<LookupDto>> GetAll();
        Task<bool> AddUpdate(int? id, LookupDto student);
        Task<List<LookupDto>> GetLookupsByCategory(int id);
        Task Delete(int id);
    }
    public class LookupService : ILookupService
    {

        private readonly DBContext _dBContext;
        private readonly IMapper _mapper;
        public LookupService(DBContext dbContex, IMapper mapper)
        {
            _dBContext = dbContex;
            _mapper = mapper;
        }
        public async Task<List<LookupDto>> GetAll()
        {
            var query = _dBContext.Lookup
                .Where(i => i.IsDeleted == false);
            var lookups = _mapper.ProjectTo<LookupDto>(query).ToList();
            return lookups;
        }

        public async Task<LookupDto> GetById(int id)
        {
            var lookup = await _dBContext.Lookup
                .Where(s => s.Id == id && s.IsDeleted == false)
                .FirstOrDefaultAsync();
            return _mapper.Map<LookupDto>(lookup);
        }

        public async Task<List<LookupDto>> GetLookupsByCategory(int id)
        {
            var lookups = await _dBContext.Lookup.Where(l => l.CategoryId == id && l.IsDeleted == false).Include(l => l.Category).ToListAsync();
            return _mapper.Map<List<LookupDto>>(lookups);
        }

        public async Task<bool> AddUpdate(int? id, LookupDto lookup)
        {
            var newLookup = _mapper.Map<Lookup>(lookup);
            try
            {
                if (id == null)
                {
                    newLookup.IsDeleted = false;
                    await _dBContext.Lookup.AddAsync(newLookup);
                }
                else
                {
                    var existingLookup = await _dBContext.Lookup.Where(s => s.Id == id).FirstOrDefaultAsync();
                    existingLookup.CategoryId = newLookup.CategoryId;
                    existingLookup.Name = newLookup.Name;
                    existingLookup.IsDeleted = newLookup.IsDeleted ?? false;
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
            var lookup = await _dBContext.Lookup.Where(d => d.Id == id).FirstOrDefaultAsync();
            lookup.IsDeleted = true;
            _dBContext.SaveChanges();
        }
    }

}
