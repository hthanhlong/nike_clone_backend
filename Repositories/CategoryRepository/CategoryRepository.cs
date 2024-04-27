using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Reformation.Database;
using Reformation.Models;

namespace Reformation.Repositories.CategoryRepository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public CategoryRepository(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public Task<CategoryModel> AddCategory(CategoryModel category)
        {
            if (category == null)
            {
                throw new ArgumentNullException(nameof(category));
            }
            var categoryEntity = _mapper.Map<CategoryModel>(category);
            _context.CategoryModel.AddAsync(categoryEntity);
            _context.SaveChangesAsync();
            return Task.FromResult(_mapper.Map<CategoryModel>(categoryEntity));
        }

        public Task<CategoryModel> DeleteCategory(int id)
        {
            if (id == 0)
            {
                throw new ArgumentNullException(nameof(id));
            }
            var categoryEntity = _context.CategoryModel.Find(id);
            if (categoryEntity == null)
            {
                throw new ArgumentNullException(nameof(categoryEntity));
            }
            _context.CategoryModel.Remove(categoryEntity);
            _context.SaveChangesAsync();
            return Task.FromResult(_mapper.Map<CategoryModel>(categoryEntity));
        }

        public Task<IEnumerable<CategoryModel>> GetCategories()
        {
            var categories = _context.CategoryModel.ToList();
            return Task.FromResult(_mapper.Map<IEnumerable<CategoryModel>>(categories));

        }

        public Task<CategoryModel> GetCategory(int id)
        {
            if (id == 0)
            {
                throw new ArgumentNullException(nameof(id));
            }
            var category = _context.CategoryModel.Find(id);
            return Task.FromResult(_mapper.Map<CategoryModel>(category));
        }

        public Task<CategoryModel> UpdateCategory(CategoryModel category)
        {
            if (category == null)
            {
                throw new ArgumentNullException(nameof(category));
            }
            var categoryEntity = _mapper.Map<CategoryModel>(category);
            _context.CategoryModel.Update(categoryEntity);
            _context.SaveChangesAsync();
            return Task.FromResult(_mapper.Map<CategoryModel>(categoryEntity));

        }
    }
}