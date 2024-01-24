using AutoMapper;
using SpinelTest.DTOs;
using System.ComponentModel.DataAnnotations.Schema;

namespace SpinelTest.Models
{

    [AutoMap(typeof(LookupDto))]
    public class Lookup
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? CategoryId { get; set; }
        [ForeignKey(nameof(CategoryId))]
        public Category? Category { get; set; }
        public bool? IsDeleted { get; set; }
    }
}
