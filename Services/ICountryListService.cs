using CountryListDemo.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CountryListDemo.Services
{
    public interface ICountryListService
    {
        Task<List<CountryListModel>> GetCountryLists();
    }
}
