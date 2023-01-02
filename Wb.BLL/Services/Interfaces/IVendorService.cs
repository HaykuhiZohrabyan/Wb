using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using Wb.Common.ViewModels;
namespace Wb.BLL.Services.Interfaces
{
    public interface IVendorService
    {
        Task Add(VendorAddEditVM model);
        Task<List<VendorCountryVM>> GetCountries();
        Task<List<VendorListVM>> GetAll();
    }
}
