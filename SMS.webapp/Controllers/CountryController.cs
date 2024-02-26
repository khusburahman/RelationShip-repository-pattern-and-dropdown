using Microsoft.AspNetCore.Mvc;
using Mono.TextTemplating;
using SMS.webapp.RepositoryService;
using SMS.webapp.ViewModel;

namespace SMS.webapp.Controllers;

public class CountryController(ICountryReository countryReository,IStudentRepository studentRepository) : Controller
{
    [HttpGet]
    public async Task<ActionResult<CountryVm>> Index()
    {
        var data = await countryReository.GetAllAsync(x => x.student);
        return View(data);
    }
    [HttpGet]
    public async Task<ActionResult<CountryVm>> CreateOrEdit(int Id, CancellationToken cancellationtoken)
    {
        ViewData["StudentId"] = studentRepository.DropDown();
        if (Id == 0)
        {
            return View(new CountryVm());

        }
        else
        {
            return View(await countryReository.GetByIdAsync(Id, cancellationtoken));
        }
    }
    [HttpPost]
    public async Task<ActionResult<CountryVm>> CreateOrEdit(int Id, CountryVm countryVm, CancellationToken cancellationToken)
    {
        if (Id == 0)
        {
            await countryReository.InsertAsync(countryVm, cancellationToken);
            return RedirectToAction(nameof(Index));
        }
        else
        {
            await countryReository.UpdateAsync(Id, countryVm, cancellationToken);
            return RedirectToAction(nameof(Index));
        }
    }
    public async Task<ActionResult<CountryVm>> Delete(int Id, CancellationToken cancellationToken)
    {
        if (Id != 0)
        {
            await countryReository.DeleteAsync(Id, cancellationToken);
            return RedirectToAction(nameof(Index));
        }
        else
        {
            return RedirectToAction(nameof(Index));
        }
    }



}
