using AutoMapper;
using SpinelTest.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace SpinelTest.DTOs
{
    [AutoMap(typeof(Visit))]
    public class VisitDto
    {
        public int Id { get; set; }
        public int? PatientId { get; set; }
        public Patient? Patient { get; set; }
        public int? DoctorId { get; set; }
        public Doctor? Doctor { get; set; }
        public DateTime? VisitTime { get; set; }
        public bool? IsDeleted { get; set; }
    }
}
