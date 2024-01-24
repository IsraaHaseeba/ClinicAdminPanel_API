using AutoMapper;
using SpinelTest.Models;

namespace SpinelTest.DTOs
{
    [AutoMap(typeof(Category))]
    public class CategoryDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public List<LookupDto>? Lookups { get; set; }
        public string Code { get; set; }
        public bool? IsDeleted { get; set; }
    }
}
