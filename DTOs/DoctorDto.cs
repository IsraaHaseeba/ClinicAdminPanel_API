using AutoMapper;
using SpinelTest.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace SpinelTest.DTOs
{
    public class DoctorDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? SpecificationId { get; set; }
        public string? SpecificationName {  get; set; }
        public int? LocationId { get; set; }
        public string? LocationName { get; set; }
        public DateTime? FromWorkingHour { get; set; }
        public DateTime? ToWorkingHour { get; set; }
    }

    public class DoctorListItemDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? SpecificationName { get; set; }
        public string? LocationName { get; set; }
        public DateTime? FromWorkingHour { get; set; }
        public DateTime? ToWorkingHour { get; set; }
    }
}
