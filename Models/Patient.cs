using AutoMapper;
using SpinelTest.DTOs;

namespace SpinelTest.Models
{
    public class Patient
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateOnly BirthDate { get; set; }
        public string IdentityNumber { get; set; }
        public string? Address { get; set; }
        public ICollection<Visit>? Visits { get; set; }
        public bool? IsDeleted { get; set; }
    }
}
