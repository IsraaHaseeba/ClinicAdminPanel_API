using AutoMapper;
using SpinelTest.Models;

namespace SpinelTest.DTOs
{
    public class LookupDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? CategoryId { get; set; }
        public string? CategoryName { get; set; }
    }
    public class LookupListItemDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? CategoryName { get; set; }
    }
}
