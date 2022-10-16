
using HMZ.Service.DTOs.Views;

namespace HMZ.Service.Services.CategoryServices
{
    public interface ICategoryService
    {
        Task<List<CategoryView>> GetAll();
        Task<CategoryView> GetById(Guid id);
        Task<int> Create(CategoryView category);
        Task<int> Update(CategoryView category);
        Task<bool> Delete(Guid id);
    }
}
