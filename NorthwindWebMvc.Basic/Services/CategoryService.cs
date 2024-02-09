using AutoMapper;
using NorthwindWebMvc.Basic.Models;
using NorthwindWebMvc.Basic.Models.Dto;
using NorthwindWebMvc.Basic.Repository;

namespace NorthwindWebMvc.Basic.Services
{
    public class CategoryService : ICategoryService<CategoryDto>
    {
        private readonly IRepositoryBase<Category> _repositoryBase;
        private readonly IMapper _mapper;

        public CategoryService(IRepositoryBase<Category> repositoryBase, IMapper mapper)
        {
            _repositoryBase = repositoryBase;
            _mapper = mapper;
        }

        public CategoryDto Create(CategoryDto entity)
        {
            var category = _mapper.Map<Category>(entity);
            var result = _repositoryBase.Save(category);

            var response = _mapper.Map<CategoryDto>(result);

            return response;
        }

        public void Delete(int id)
        {
            _repositoryBase.Delete(id);
        }

        public void Edit(int id, CategoryDto entity)
        {
            var category = _mapper.Map<Category>(entity);
            _repositoryBase.Update(id,category);
        }

        public IEnumerable<CategoryDto> GetAll()
        {
            var categories = _repositoryBase.GetAll();
            //var categoryDto = categories.Select(c => new CategoryDto
            //{
            //    CategoryName = c.CategoryName,
            //    Description = c.Description,
            //    Photo = c.Photo
            //}).ToList();

            var categoryDto = _mapper.Map<IEnumerable<CategoryDto>>(categories);

            return categoryDto;
        }

        public CategoryDto GetById(int id)
        {
            var category = _repositoryBase.Get(id);
            var categoryDto = _mapper.Map<CategoryDto>(category);

            return categoryDto;
        }
    }
}
