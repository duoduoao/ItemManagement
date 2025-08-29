


using System.Reflection.Metadata.Ecma335;

namespace WebAppMVC.Models
{
    public static class CategoryInMemoryRepository  
    {
        private static List<Category> categories  = new List<Category>()
            {
                new Category { CategoryId = 1, Name = "Toy", Description = "Toy"},
                new Category { CategoryId = 2, Name = "Cloth", Description = "Cloth"},
                new Category { CategoryId = 3, Name = "Food", Description = "Food"},
            };
   

        public static void AddCategory(Category category)
        {
            if (categories.Any(x => x.Name.Equals(category.Name, StringComparison.OrdinalIgnoreCase))) return;

            if (categories != null && categories.Count > 0)
            {
                var maxId = categories.Max(x => x.CategoryId);
                category.CategoryId = maxId + 1;
            }
            else
            {
                //to fix initial issue
                category.CategoryId = 1;
            }
            

            categories.Add(category);
        }

        public static void UpdateCategory(int categoryId,Category category)
        {
            var categoryToUpdate = categories?.FirstOrDefault(x => x.CategoryId == categoryId);
            // GetCategoryById(categoryId);

            //error : categoryToUpdate=category, because it's will be new object
            if (categoryToUpdate != null)
            {
                categoryToUpdate.Name = category.Name;
                categoryToUpdate.Description = category.Description;
            }
        }

        public static IEnumerable<Category> GetCategories()
        {
            return categories;
        }

        public static Category GetCategoryById(int categoryId)
        {
           var category = categories?.FirstOrDefault(x => x.CategoryId == categoryId);

            if (category != null) {
                return new Category
                {
                    CategoryId = category.CategoryId,
                    Name = category.Name,
                    Description = category.Description
                };
            
            }
            return null;

        }

        public static void DeleteCategory(int categoryId)
        {
            var category = categories?.FirstOrDefault(x => x.CategoryId == categoryId);
            if (category != null)
            {
                categories.Remove(category);
            }
            //categories?.Remove(GetCategoryById(categoryId));
        }
    }
}
