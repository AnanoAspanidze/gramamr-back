using Grammar.Data.Models.Admin.Models;
using Grammar.Data.Models.Admin.Models.SubCategories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Grammar.Data.Interfaces.Admin.Interfaces
{
  public interface IAdminSubCategoriesServices
    {
        Task<IEnumerable<AdminSubCategoryModel>> GetAllSubCategoriesAsync();

        Task<bool> CreateSubCategoriesAsync(AdminSubCategoryCreateModel model);

        Task<AdminSubCategoryModel> GetSubCategoryDetailsAsync(int id);

        Task<bool> EditSubCategoriesAsync(int id, AdminSubCategoryEditModel model);

        Task<bool> HideCategoryAsync(int id);

        Task<bool> UnHideCategoryAsync(int id);
    }
}
