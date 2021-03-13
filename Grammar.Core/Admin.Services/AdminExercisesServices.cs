using Grammar.Core.Profiles;
using Grammar.Data.Entities;
using Grammar.Data.Interfaces.Admin.Interfaces;
using Grammar.Data.Models.Admin.Models.Exercises;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Grammar.Core.Admin.Services
{
   public class AdminExercisesServices : IAdminExercisesServices
    {
        private GrammarDbContext _context;
        public AdminExercisesServices(GrammarDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<AdminExerciseModel>> GetAllExercisesAsync()
        {

            var exercises = await _context.Exercises
            .Include(e => e.Type)
            .Include(e => e.SubCategory)
            .ThenInclude(e => e.Category).ToListAsync();
            var result = Mapping.Mapper.Map<IEnumerable<AdminExerciseModel>>(exercises);

            return await Task.FromResult(result);

        }


    }
}
