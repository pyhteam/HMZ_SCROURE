using HMZ.Data.Enities;
using HMZ.Service.DTOs.Views;
using HMZ.Service.Repository;
using Microsoft.EntityFrameworkCore;

namespace HMZ.Service.Services.ProductServices
{
    public class ProductService : BaseService, IProductService
    {
        public ProductService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public async Task<List<ProductView>> GetAll()
        {
            var products = await this._unitOfWork.GetRepository<Product>().AsQueryable()
                .Select(x => new ProductView
                {
                    Id = x.Id,
                    Name = x.Name,
                    Description = x.Description,
                    Price = x.Price,
                    CreatedDate = x.CreatedDate,
                    ModifiedDate = x.ModifiedDate,
                    IsDeleted = x.IsDeleted
                }).ToListAsync();
            return products;
        }
    }
}