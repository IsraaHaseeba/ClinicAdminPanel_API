using AutoMapper;
using SpinelTest.DTOs;
using SpinelTest.Models;

namespace SpinelTest
{
    public class Mapper : Profile
    {
        public Mapper()
        {
            CreateMap<LookupDto, Lookup>();
            CreateMap<Lookup, LookupDto>()
                 .ForMember(dest =>
                    dest.CategoryName,
                    opt => opt.MapFrom(src => src.Category.Title));
            CreateMap<DoctorDto, Doctor>();
            CreateMap<Doctor, DoctorDto>()
                 .ForMember(dest =>
                    dest.SpecificationName,
                    opt => opt.MapFrom(src => src.Specification.Name))
                 .ForMember(dest =>
                    dest.LocationName,
                    opt => opt.MapFrom(src => src.Location.Name));
            CreateMap<PatientDto, Patient>();
            CreateMap<Patient, PatientDto>();
            CreateMap<CategoryDto, Category>();
            CreateMap<Category, CategoryDto>();
            CreateMap<Visit, VisitDto>()
                 .ForMember(dest =>
                    dest.DoctorName,
                    opt => opt.MapFrom(src => src.Doctor.Name))
                 .ForMember(dest =>
                    dest.PatientName,
                    opt => opt.MapFrom(src => src.Patient.Name));
            CreateMap<VisitDto, Visit>();
        }
    }
}
