using Restaurant.Db;
using Restaurant.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Services
{
    public class CategoryRepository :ICategoryRepository
    {

        private RestaurantDbContext _Context;
        public CategoryRepository(RestaurantDbContext Context)
        {
            _Context = Context;
        }

        public Category AddCategory(Category category)
        {
            //  category.Id = Id;
            _Context.Categories.Add(category);
            _Context.SaveChanges();
            return category;
        }


        public void DeleteCategory(int Id)
        {



            var result = _Context.Categories.Where(a => a.Id == Id).FirstOrDefault();
            if (result != null)
            {

                _Context.Categories.Remove(result);
                _Context.SaveChanges();


            }

        }

        public async Task<Category> EditCategory(int Id, Category category)
       
        {

            var _temp = GetCategory(Id);
            if (_temp != null)
            {
                _temp.Name = category.Name;
               
                await _Context.SaveChangesAsync();
                return _temp;

            }
            return null;

        }
    

        public List<Category> GetAllCategory()
        {
            return _Context.Categories.ToList();
        }

        public Category GetCategory(int Id)
        {
            return _Context.Categories.FirstOrDefault(a => a.Id == Id);
        }
    }
}
