using Grammar.Data.Models.Admin.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Grammar.Data.Interfaces.Admin.Interfaces
{
   public interface IAdminCategoriesServices
    {
        Task<IEnumerable<AdminCategoryModel>> GetAllCategoriesAsync();
    }
}
