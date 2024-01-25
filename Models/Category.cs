using AutoMapper;
using SpinelTest.DTOs;
using System.ComponentModel.DataAnnotations;

namespace SpinelTest.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public ICollection<Lookup>? Lookups { get; set; }
        public string Code { get; set; }
        public bool? IsDeleted { get; set; }
    }
}
