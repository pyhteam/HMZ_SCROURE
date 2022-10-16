using HMZ.Data.Enities;
using HMZ.Service.DTOs.Views;
using HMZ.Service.Repository;
using Microsoft.EntityFrameworkCore;

namespace HMZ.Service.Services.CategoryServices
{
    public class CategoryService : BaseService, ICategoryService
    {
        protected CategoryService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public async Task<int> Create(CategoryView categoryView)
        {
            if (categoryView == null)
            {
                return 0;
            }
            var category = new Category
            {
                Name = categoryView.Name,
                Description = categoryView.Description
            };
            await _unitOfWork.GetRepository<Category>().AddAsync(category);
            return await _unitOfWork.SaveChangesAsync();
        }

        public async Task<bool> Delete(Guid id)
        {
            var category = await _unitOfWork.GetRepository<Category>().GetAsync(id);
            if (category == null)
            {
                return false;
            }
            _unitOfWork.GetRepository<Category>().Delete(category);
            return await _unitOfWork.SaveChangesAsync() > 0;
        }

        public async Task<List<CategoryView>> GetAll()
        {
            var categories = await _unitOfWork.GetRepository<Category>().AsQueryable()
            .Select(x => new CategoryView
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                CreatedDate = x.CreatedDate,
                ModifiedDate = x.ModifiedDate,
                IsDeleted = x.IsDeleted
            }).ToListAsync();
            return categories;
        }

        public async Task<CategoryView> GetById(Guid id)
        {
            var category = _unitOfWork.GetRepository<Category>().AsQueryable();
            var categoryView = await category.Where(x => x.Id == id)
            .Select(x => new CategoryView
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                CreatedDate = x.CreatedDate,
                ModifiedDate = x.ModifiedDate,
                IsDeleted = x.IsDeleted
            }).FirstOrDefaultAsync();
            return categoryView;
        }

        public async Task<int> Update(CategoryView categoryView)
        {
            if (categoryView == null)
            {
                return 0;
            }
            var category = await _unitOfWork.GetRepository<Category>().GetAsync(categoryView.Id);
            if (category == null)
            {
                return 0;
            }
            category.Name = categoryView.Name;
            category.Description = categoryView.Description;
            _unitOfWork.GetRepository<Category>().UpdateAsync(category);
            return await _unitOfWork.SaveChangesAsync();

        }
    }
}
