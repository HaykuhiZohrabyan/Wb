using Microsoft.AspNetCore.Mvc;
using Wb.Common.ViewModels;
using Wb.BLL.Services.Interfaces;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Wb.Controllers
{
    public class VendorController : Controller
    {
        private readonly IVendorService _vendorService;
        public VendorController(IVendorService vendorService)
        {
            _vendorService=vendorService;
        }
        public async Task<IActionResult>   Index()
        {
            var list= await _vendorService.GetAll();
            return View(list);
        }

        [HttpGet]
        public async Task<IActionResult> AddEdit()
        {
            var countries= await _vendorService.GetCountries();
            ViewBag.countries = new SelectList(countries,nameof(VendorCountryVM.Id),nameof(VendorCountryVM.Name));
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddEdit(VendorAddEditVM model)
        {
            await _vendorService.Add(model);
            return RedirectToAction("Index");
        }
    }
}
