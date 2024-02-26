using AutoMapper;
using SMS.webapp.DatabaseContext;
using SMS.webapp.Models;
using SMS.webapp.Services;
using SMS.webapp.ViewModel;

namespace SMS.webapp.RepositoryService;

public class CountryRepository:RepositoryService<Country,CountryVm>,ICountryReository 

{
    public CountryRepository(IMapper mapper,ApplicationDbContext dbContext):base(mapper,dbContext)
    { 
    
    }
}
