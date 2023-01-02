using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wb.Common.ViewModels;

namespace Wb.BLL.Services.Interfaces
{
    public interface IProductService
    {
        Task Add(ProductVM model);
        Task<List<ProductVM>> GetAll();
        Task<ProductVM> GetById(int id);
        Task Update (ProductVM model);
        Task Delete(int id);
    }
}
