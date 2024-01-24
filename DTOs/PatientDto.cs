using AutoMapper;
using SpinelTest.Models;

namespace SpinelTest.DTOs
{
    [AutoMap(typeof(Patient))]
    public class PatientDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateOnly BirthDate { get; set; }
        public string IdentityNumber { get; set; }
        public string? Address { get; set; }
        public List<VisitDto>? Visits { get; set; }
        public bool? IsDeleted { get; set; }
    }
}
