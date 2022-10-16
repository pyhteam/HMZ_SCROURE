
using HMZ.Service.DTOs.Views;

namespace HMZ.Service.Services.ProductServices
{
    public interface IProductService
    {
        Task<List<ProductView>> GetAll();
    }
}
