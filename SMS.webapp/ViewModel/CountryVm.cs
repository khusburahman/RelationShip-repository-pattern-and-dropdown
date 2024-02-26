using AutoMapper;
using SMS.webapp.Models;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SMS.webapp.ViewModel
{
    [AutoMap(typeof(Country),ReverseMap =true)]
    public class CountryVm
    {
        public int Id { get; set; }
        [Required]
        [DisplayName("Country Name")]
        public string Name { get; set; }
        [Required]
        [DisplayName("Student Name")]
        public int StudentId { get; set; }
        public Student student { get; set; }
    }
}
