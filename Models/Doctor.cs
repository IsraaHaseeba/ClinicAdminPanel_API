using AutoMapper;
using SpinelTest.DTOs;
using System.ComponentModel.DataAnnotations.Schema;

namespace SpinelTest.Models
{
    [AutoMap(typeof(DoctorDto))]
    public class Doctor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? SpecificationId { get; set; }
        [ForeignKey(nameof(SpecificationId))]
        public Lookup? Specification { get; set; }
        public int? LocationId { get; set; }
        [ForeignKey(nameof(LocationId))]
        public Lookup? Location { get; set; }
        public DateTime? FromWorkingHour { get; set; }
        public DateTime? ToWorkingHour { get; set; }
        public ICollection<Visit>? Visits { get; set; }
        public bool? IsDeleted { get; set; }
    }
}
