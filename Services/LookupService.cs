using AutoMapper;
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
        Task<bool> Delete(int id);
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
            var lookups = await _dBContext.Lookup
                .Where(i => i.IsDeleted == false)
                .Include(s => s.Category)
                .ToListAsync();
            return _mapper.Map<List<LookupDto>>(lookups);
        }

        public async Task<LookupDto> GetById(int id)
        {
            var lookup = await _dBContext.Lookup
                .Where(s => s.Id == id && s.IsDeleted == false)
                .Include(s => s.Category)
                .FirstOrDefaultAsync();
            if (lookup == null) { return null; }
            return _mapper.Map<LookupDto>(lookup);
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

        public async Task<bool> Delete(int id)
        {
            var existingLookup = await _dBContext.Lookup
                            .Where(s => s.Id == id)
                            .FirstOrDefaultAsync();
            if (existingLookup == null) return false;
            var deletedLookup = _dBContext.Lookup.Remove(existingLookup);
            _dBContext.SaveChanges();
            if (deletedLookup == null) return false;
            return true;
        }
    }

}
