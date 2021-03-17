using Grammar.Data.Models.Admin.Models.Exercises;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Grammar.Data.Interfaces.Admin.Interfaces
{
   public interface IAdminExercisesServices
    {
        Task<IEnumerable<AdminExerciseModel>> GetAllExercisesAsync();

        Task<bool> CreateExercisesAsync(AdminExerciseCreateModel model);

        Task<AdminExerciseDetailsModel> ExerciseDetailsAsync(int itemId);

        Task<bool> EdiExerciseAsync(AdminExerciseEditModel model);
    }
}
