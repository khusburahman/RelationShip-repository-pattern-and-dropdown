using AutoMapper;
using SMS.webapp.Models;

namespace SMS.webapp.ViewModel
{
    [AutoMap(typeof(Student),ReverseMap = true)]
    public class StudentVm
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
