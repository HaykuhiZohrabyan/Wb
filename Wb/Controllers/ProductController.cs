using Microsoft.AspNetCore.Mvc;
using Wb.Common.ViewModels;
using Wb.BLL.Services.Interfaces;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Hosting;
using System.IO;
namespace Wb.Controllers
{
    public class ProductController : Controller
    {
        private readonly IVendorService _vendorService;
        private readonly IProductService _productService;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public ProductController(IVendorService vendorService, IProductService productService, IWebHostEnvironment webHostEnvironment)
        {
            _vendorService = vendorService;
            _productService = productService;
            _webHostEnvironment = webHostEnvironment;
        }
        public async Task<IActionResult> Index()
        {
            var list = await _productService.GetAll();
            return View(list);
        }
        [HttpGet]
        public async Task<IActionResult> AddEdit(int? id=null)
        {
            var model= id.HasValue?await _productService.GetById(id.Value):new ProductVM();
            var vendorList = await _vendorService.GetAll();
            ViewBag.vendors = new SelectList(vendorList, "Id", "Name");
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddEdit(ProductVM model,IFormFile ImageFileName)
        {
            if(ImageFileName !=null)
            { 
                if(model.Id>0)
                {
                    System.IO.File.Delete(_webHostEnvironment.WebRootPath + "/images/products/" + model.ImageFileName);
                }
            string savepath = _webHostEnvironment.WebRootPath + "/images/products/";
            string fileName = Guid.NewGuid().ToString() + Path.GetExtension(ImageFileName.FileName);
            using(var filestream= new FileStream(savepath+fileName,FileMode.Create))
            {
                await ImageFileName.CopyToAsync(filestream);
            }
                model.ImageFileName = fileName;
            }
            if(model.Id==0)
            {
               await _productService.Add(model);
            }
            else
            {
              
                await _productService.Update(model);
            }
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int id)
        {
            await _productService.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
