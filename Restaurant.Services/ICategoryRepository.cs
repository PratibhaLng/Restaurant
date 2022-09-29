using Restaurant.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Services
{
    public interface ICategoryRepository
    {

        List<Category> GetAllCategory();

        Category GetCategory(int Id);

        Category AddCategory(Category category);


        void DeleteCategory(int Id);

       
        Task<Category> EditCategory(int id, Category category);
    }
}
