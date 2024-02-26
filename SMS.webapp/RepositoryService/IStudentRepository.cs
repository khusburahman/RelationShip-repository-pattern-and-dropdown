using Microsoft.AspNetCore.Mvc.Rendering;
using SMS.webapp.Models;
using SMS.webapp.Services;
using SMS.webapp.ViewModel;

namespace SMS.webapp.RepositoryService
{
    public interface IStudentRepository:IRepositoryService<Student,StudentVm>
    {
        IEnumerable<SelectListItem> DropDown();
    }
}
