using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SpinelTest.DTOs;
using SpinelTest.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace SpinelTest.Services
{
    public interface ICategoryService
    {
        Task<CategoryDto> GetById(int id);
        Task<List<CategoryDto>> GetAll();
        Task<bool> AddUpdate(int? id, CategoryDto student);
        Task Delete(int id);
        Task<bool> CheckIfCodeExist(string code, int? id);
    }
    public class CategoryService : ICategoryService
    {
        private readonly DBContext _dBContext;
        private readonly IMapper _mapper;
        public CategoryService(DBContext dbContex, IMapper mapper)
        {
            _dBContext = dbContex;
            _mapper = mapper;
        }
        public async Task<List<CategoryDto>> GetAll()
        {
            var query = _dBContext.Category
                 .Where(i => i.IsDeleted == false);
            var categories = _mapper.ProjectTo<CategoryDto>(query).ToList();
            return categories;
        }

        public async Task<CategoryDto> GetById(int id)
        {
            var query = _dBContext.Category
                .Where(s => s.Id == id && s.IsDeleted == false);
            var category = _mapper.ProjectTo<CategoryDto>(query).FirstOrDefault();
            return category;
        }

        public async Task<bool> AddUpdate(int? id, CategoryDto category)
        {
            var newCategory = _mapper.Map<Category>(category);
            try
            {
                if (id == null)
                {
                    newCategory.IsDeleted = false;
                    await _dBContext.Category.AddAsync(newCategory);
                }
                else
                {
                    var existingCategory = await _dBContext.Category.Where(s => s.Id == id).FirstOrDefaultAsync();
                    existingCategory.Title = newCategory.Title;
                    existingCategory.Lookups = newCategory.Lookups;
                    existingCategory.Code = newCategory.Code;
                    existingCategory.IsDeleted = newCategory.IsDeleted ?? false;
                }
                _dBContext.SaveChanges();
            }
            catch
            {
                return false;
            }

            return true;
        }

        public async Task<bool> CheckIfCodeExist(string code, int? id)
        {
            var isExisting = await _dBContext.Category.Where(c => c.Code == code && (id != null ? c.Id != id : true) && c.IsDeleted == false).FirstOrDefaultAsync();
            if (isExisting == null) { return false; }
            return true;
        }

        public async Task Delete(int id)
        {
            var category = await _dBContext.Category.Where(d => d.Id == id).FirstOrDefaultAsync();
            category.IsDeleted = true;
            _dBContext.SaveChanges();
        }
    }
}
