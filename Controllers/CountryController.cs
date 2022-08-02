using CountryListDemo.Models;
using CountryListDemo.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CountryListDemo.Controllers
{
    public class CountryController : Controller
    {
        private readonly ICountryListService _countryListService;

        public CountryController(ICountryListService countryListService)
        {
            _countryListService = countryListService;
        }

        public async Task<ActionResult> Index()
        {
            List<CountryListModel> countryLists = new List<CountryListModel>();

            countryLists = await _countryListService.GetCountryLists();

            return View(countryLists);
        }
    }
}
