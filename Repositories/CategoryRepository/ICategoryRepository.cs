using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Reformation.Models;

namespace Reformation.Repositories.CategoryRepository
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<CategoryModel>> GetAll();
        Task<CategoryModel> GetById(int id);
        Task<CategoryModel> Create(CategoryModel category);
        Task<CategoryModel> Update(CategoryModel category);
        Task<CategoryModel> Delete(int id);
    }
}

