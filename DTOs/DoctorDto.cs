using AutoMapper;
using SpinelTest.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace SpinelTest.DTOs
{
    [AutoMap(typeof(Doctor))]
    public class DoctorDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? SpecificationId { get; set; }
        public Lookup? Specification {  get; set; }
        public int? LocationId { get; set; }
        public Lookup? Location { get; set; }
        public DateTime? FromWorkingHour { get; set; }
        public DateTime? ToWorkingHour { get; set; }
        public List<VisitDto>? Visits { get; set; }
        public bool? IsDeleted { get; set; }
    }
}
