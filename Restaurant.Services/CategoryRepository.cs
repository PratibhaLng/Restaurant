using Restaurant.Db;
using Restaurant.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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


        public Category EditCategory(Category category)
        {
            //var existingCategory = _Context.Categories.Find(category.Id);
            // if (existingCategory != null)
            //{

            _Context.Categories.Update(category);
            _Context.SaveChanges();
            return null;
            //    }
            //return category;
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
