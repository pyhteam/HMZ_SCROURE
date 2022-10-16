
using HMZ.Service.DTOs.Queries;
using HMZ.Service.DTOs.Views;

namespace HMZ.Service.Services.CategoryServices
{
    public interface ICategoryService
    {
        Task<List<CategoryView>> GetAll();
        Task<CategoryView> GetById(string id);
        Task<int> Create(CategoryQuery category);
        Task<int> Update(CategoryQuery category, string id);
        Task<bool> Delete(string id);
    }
}
