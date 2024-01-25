using AutoMapper;
using SpinelTest.Models;

namespace SpinelTest.DTOs
{
    public class PatientDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateOnly BirthDate { get; set; }
        public string IdentityNumber { get; set; }
        public string? Address { get; set; }
    }
}
