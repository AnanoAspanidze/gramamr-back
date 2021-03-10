using Grammar.Core.Profiles;
using Grammar.Data.Entities;
using Grammar.Data.Interfaces.Admin.Interfaces;
using Grammar.Data.Models.Admin.Models;
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
        public async Task<IEnumerable<AdminSubCategoryModel>> GetAllSubCategoriesAsync()
        {
            var Subcategories = _context.SubCategories.Include(e=>e.Category);

            var result = Mapping.Mapper.Map<IEnumerable<AdminSubCategoryModel>>(Subcategories);

            return await Task.FromResult(result);
        }
    }
}
