using AutoMapper;
using SpinelTest.DTOs;
using System.ComponentModel.DataAnnotations.Schema;

namespace SpinelTest.Models
{
    [AutoMap(typeof(VisitDto))]
    public class Visit
    {
        public int Id { get; set; }
        public int? PatientId { get; set; }
        [ForeignKey(nameof(PatientId))]
        public Patient? Patient { get; set; }

        public int? DoctorId { get; set; }
        [ForeignKey(nameof(DoctorId))]
        public Doctor? Doctor { get; set; }
        public DateTime? VisitTime { get; set; }
        public bool? IsDeleted { get; set; }
    }
}
