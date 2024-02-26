using AutoMapper;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SMS.webapp.DatabaseContext;
using SMS.webapp.Models;
using SMS.webapp.Services;
using SMS.webapp.ViewModel;

namespace SMS.webapp.RepositoryService;

public class StudentRepository : RepositoryService<Student, StudentVm>, IStudentRepository
{
    public StudentRepository(IMapper mapper,ApplicationDbContext dbContext):base(mapper,dbContext)
    {
        
    }
    
    public IEnumerable<SelectListItem> DropDown()
    {
        return DbSet.Select(x => new SelectListItem { Text = x.Name, Value = x.Id.ToString() });
    }
}

