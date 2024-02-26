using Microsoft.AspNetCore.Mvc;
using SMS.webapp.RepositoryService;
using SMS.webapp.ViewModel;

namespace SMS.webapp.Controllers;

public class StudentController : Controller
{
    private readonly IStudentRepository studentRepository;
    public StudentController(IStudentRepository studentRepository)
    {
        this.studentRepository = studentRepository;
    }
    public async Task <ActionResult<StudentVm>>Index(CancellationToken cancellationToken) 
    {
        return View(await studentRepository.GetAllAsync(cancellationToken));
    }
    [HttpGet]
    public async Task<ActionResult<StudentVm>>CreateOrEdit(int Id,CancellationToken cancellationToken)
    {
        if (Id == 0)
        {
            return View(new StudentVm());
        }
        else
        {
            return View(await studentRepository.GetByIdAsync(Id,cancellationToken));
        }
    }
    [HttpPost]
    public async Task<ActionResult<StudentVm>>CreateOrEdit(int Id,StudentVm studentVm,CancellationToken cancellationToken)
    {
        if (Id == 0)
        {
            await studentRepository.InsertAsync(studentVm, cancellationToken);
            return RedirectToAction(nameof(Index));
        }
        else
        {
            await studentRepository.UpdateAsync(Id, studentVm, cancellationToken);
            return RedirectToAction(nameof(Index));
        }
    }
    public async Task<ActionResult<StudentVm>>Delete(int Id,CancellationToken cancellationToken)
    {
        if (Id != 0)
        {
            await studentRepository.DeleteAsync(Id, cancellationToken);
            return RedirectToAction(nameof(Index));
        }
        else
        {
            return RedirectToAction(nameof(Index));
        }
    }
   

    
    

}

