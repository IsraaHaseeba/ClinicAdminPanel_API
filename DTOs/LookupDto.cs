using AutoMapper;
using SpinelTest.Models;

namespace SpinelTest.DTOs
{
    [AutoMap(typeof(Lookup))]
    public class LookupDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? CategoryId { get; set; }
        public Category? Category { get; set; }
        public bool? IsDeleted { get; set; }
    }
}
