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
   public class AdminCategoriesServices : IAdminCategoriesServices
    {
        private GrammarDbContext _context;
        public AdminCategoriesServices(GrammarDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<AdminCategoryModel>> GetAllCategoriesAsync()
        {
            var categories = _context.Categories;

            var result = Mapping.Mapper.Map<IEnumerable<AdminCategoryModel>>(categories);

            return await Task.FromResult(result);
        }
    }
}
