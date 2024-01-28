using AutoMapper;
using SpinelTest.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace SpinelTest.DTOs
{
    public class VisitDto
    {
        public int Id { get; set; }
        public int? PatientId { get; set; }
        public string? PatientName { get; set; }
        public int? DoctorId { get; set; }
        public string? DoctorName { get; set; }
        public DateTime? VisitTime { get; set; }
    }

    public class VisitListItemDto
    {
        public int Id { get; set; }
        public string? PatientName { get; set; }
        public string? DoctorName { get; set; }
        public DateTime? VisitTime { get; set; }
    }
}
