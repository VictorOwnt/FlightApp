using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightAppApi.Model
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> GetCategories();
        void SaveChanges();
        Category GetCategoryWithProducts(string categoryName);
    }
}
