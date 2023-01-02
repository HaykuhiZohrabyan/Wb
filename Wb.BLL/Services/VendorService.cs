using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wb.BLL.Services.Interfaces;
using Wb.DAL.Repository;
using Wb.Common.ViewModels;
using Wb.DAL.Entities;
using Microsoft.EntityFrameworkCore;
namespace Wb.BLL.Services
{
    public class VendorService:IVendorService
    {
        private readonly  DataContext _dataContext;
        public VendorService (DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public async Task Add(VendorAddEditVM model)
        {
            var vendor = new Vendor
            {
                Name = model.Name,
                CreatedDate = DateTime.Now,
                CountryId = model.VendorCountryId
            };

            await _dataContext.AddAsync(vendor);
            await _dataContext.SaveChangesAsync();
        }

        public async Task<List<VendorCountryVM>> GetCountries()
        {
            var list = await _dataContext.VendorCountries
                .Select(v => new VendorCountryVM
                {
                    Id = v.Id,
                    Name = v.Name,
                }).ToListAsync();

            return list;
        }

        public async Task<List<VendorListVM>> GetAll()
        {
            var list = await _dataContext.Vendors
                .Select(v => new VendorListVM
                {
                    Name=v.Name,
                    Id=v.Id,
                    CountryName=v.VendorCountry.Name
                }).ToListAsync();
            return list;
        }
    }
}
