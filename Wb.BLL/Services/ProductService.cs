using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wb.BLL.Services.Interfaces;
using Wb.Common.ViewModels;
using Wb.DAL.Entities;
using Wb.DAL.Repository;
using Microsoft.EntityFrameworkCore;
namespace Wb.BLL.Services
{
    public class ProductService:IProductService
    {
        private readonly DataContext _context;
        public ProductService(DataContext dataContext)
        {
            _context = dataContext;
        }
        public async Task Add(ProductVM model)
        {
            Product product = new()
            {
                Name = model.Name,
                Description = model.Description,
                Discount=model.Discount,
                CreatedDate=DateTime.Now,
                ImageFileName=model.ImageFileName,
                Price=model.Price,
                VendorId=model.VendorId
            };
            await _context.AddAsync(product);
            await _context.SaveChangesAsync();
        }

        public async Task<List<ProductVM>> GetAll()
        {
            var list = await _context.Products
                .Select(p => new ProductVM
                {
                    Id=p.Id,
                    Description=p.Description,
                    Discount=p.Discount,
                    ImageFileName=p.ImageFileName,
                    Name=p.Name,
                    Price=p.Price
                }).ToListAsync();
            return list;
        }

        public async Task<ProductVM> GetById(int id)
        {
            
            var entity = await _context.Products
                .FirstOrDefaultAsync(p=>p.Id==id);

            var vm = new ProductVM
            {
                Id=entity.Id,
                Description=entity.Description,
                Discount =entity.Discount,
                ImageFileName=entity.ImageFileName,
                Name=  entity.Name,
                Price=entity.Price,
                VendorId=entity.VendorId
            };

            return vm;
        }

       public async Task Update(ProductVM model)
        {
            
            var entity = await _context.Products
                .FindAsync(model.Id);
            entity.Description = model.Description;
            entity.Discount = model.Discount;
            entity.ImageFileName = model.ImageFileName; 
            entity.Name = model.Name;
            entity.VendorId = model.VendorId;
            entity.Price = model.Price;
            
            await _context.SaveChangesAsync();
        }
        public async Task Delete(int id)
        {
            var entity = await _context.Products.FindAsync(id);
            _context.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}
