using Grammar.Core.Profiles;
using Grammar.Data.Entities;
using Grammar.Data.Interfaces.Admin.Interfaces;
using Grammar.Data.Models.Admin.Models;
using Grammar.Data.Models.Admin.Models.SubCategories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Grammar.Core.Admin.Services
{
    public class AdminSubCategoriesServices : IAdminSubCategoriesServices
    {
        private GrammarDbContext _context;
        public AdminSubCategoriesServices(GrammarDbContext context)
        {
            _context = context;
        }

        private async Task<bool> CheckSubcategoryName(string name)
        {
            var result = _context.SubCategories.FirstOrDefaultAsync(e => e.Name == name) == null ? true : false;
            return await Task.FromResult(result);
        }

        private async Task<SubCategories> getSubcategoryFromDb(int id)
        {
            var result = _context.SubCategories.FirstOrDefaultAsync(e => e.Id == id);
            return await result;
        }
        public async Task<IEnumerable<AdminSubCategoryModel>> GetAllSubCategoriesAsync()
        {
            var Subcategories = _context.SubCategories.Include(e=>e.Category);

            var result = Mapping.Mapper.Map<IEnumerable<AdminSubCategoryModel>>(Subcategories);

            return await Task.FromResult(result);
        }

        public async Task<AdminSubCategoryModel> GetSubCategoryDetailsAsync(int id)
        {
            var Subcategories = _context.SubCategories.FirstOrDefaultAsync(e => e.Id==id);

            var result = Mapping.Mapper.Map<AdminSubCategoryModel>(Subcategories);

            return await Task.FromResult(result);
        }

        
        public async Task<bool> CreateSubCategoriesAsync(AdminSubCategoryCreateModel model)
        {
            var ifCategoryExist = await CheckSubcategoryName(model.Name);
 
            if(!ifCategoryExist)
            {
                var newSubCategory = Mapping.Mapper.Map<SubCategories>(model);
                     await _context.SubCategories.AddAsync(newSubCategory);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }
        public async Task<bool> EditSubCategoriesAsync(int id, AdminSubCategoryEditModel model)
        {
            var subcategory = await getSubcategoryFromDb(id);
            if (subcategory != null)
            {
                Mapping.Mapper.Map(model, subcategory);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<bool> HideCategoryAsync(int id)
        {
            var subcategory = await getSubcategoryFromDb(id);
            if (subcategory != null)
            {
                subcategory.IsActive = false;
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<bool> UnHideCategoryAsync(int id)
        {
            var subcategory = await getSubcategoryFromDb(id);
            if (subcategory != null)
            {
                subcategory.IsActive = true;
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}
