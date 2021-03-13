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
   public class AdminTypesServices : IAdminTypesServices
    {
        private GrammarDbContext _context;
        public AdminTypesServices(GrammarDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<AdminTypeModel>> GetAllTypesAsync()
        {
            var types = _context.Types;

            var result = Mapping.Mapper.Map<IEnumerable<AdminTypeModel>>(types);

            return await Task.FromResult(result);
        }
    }
}
