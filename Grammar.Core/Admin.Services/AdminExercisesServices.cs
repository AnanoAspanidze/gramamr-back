using Grammar.Core.Profiles;
using Grammar.Data.Entities;
using Grammar.Data.Interfaces.Admin.Interfaces;
using Grammar.Data.Models.Admin.Models.Exercises;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Grammar.Data.Models.Admin.Models.Exercises.Quersions;
using Grammar.Data.Models.Admin.Models.Exercises.Answers;

namespace Grammar.Core.Admin.Services
{
   public class AdminExercisesServices : IAdminExercisesServices
    {
        private GrammarDbContext _context;
        public AdminExercisesServices(GrammarDbContext context)
        {
            _context = context;
        }

        private async Task<bool> CheckIfDescriptionExsit(string descr)
        {
            var checkIfDescriptionExist = await _context.Exercises.
                 FirstOrDefaultAsync(e => e.Description == descr) == null ? true : false;
            return checkIfDescriptionExist;
        }

        public async Task<AdminExerciseDetailsModel> ExerciseDetailsAsync(int itemId)
        {
            var exercise = await _context.Exercises.Where(e=>e.Id==itemId)
               .Include(e => e.Questions)
               .ThenInclude(e => e.Answers).FirstOrDefaultAsync();
            var result = Mapping.Mapper.Map<AdminExerciseDetailsModel> (exercise);
            return result;
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

       public async Task<bool> CreateExercisesAsync(AdminExerciseCreateModel model)
        {
            if (await CheckIfDescriptionExsit(model.Description))
                {
                var newExercise = Mapping.Mapper.Map<Exercises>(model);
                newExercise.UserId = 1;
                newExercise.Date = DateTime.Now; 
                await _context.Exercises.AddAsync(newExercise);
                await _context.SaveChangesAsync();


                foreach (var quest in model.Questions)
                {
                    await AddQuestionsAsync(newExercise.Id, quest);
                }
                return true;
            }
                return false;
        }

        private async Task AddQuestionsAsync(int exerciseId, AdminCreateQuestionModel model)
        {
                var newQuestion = Mapping.Mapper.Map<Questions>(model);
                newQuestion.ExerciseId = exerciseId;
                await _context.Questions.AddAsync(newQuestion);
                await _context.SaveChangesAsync();

                foreach(var answ in model.Answers)
                {
                    await AddAnswersAsync(newQuestion.Id,answ);
                }
        }

        private async Task AddAnswersAsync(int questionId, AdminCreateAnswerModel model)
        {

            var newAnswers = Mapping.Mapper.Map<Answers>(model);
            newAnswers.QuestionId = questionId;

            await _context.Answers.AddAsync(newAnswers);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> EdiExerciseAsync(AdminExerciseEditModel model)
        {
            var exercise = await _context.Exercises.Where(e => e.Id == model.Id)
              .Include(e => e.Questions)
              .ThenInclude(e => e.Answers).FirstOrDefaultAsync();
            if (exercise != null)
            {

                Mapping.Mapper.Map(model, exercise);
                await _context.SaveChangesAsync();
                return true;
            }
            else
                return false;
        }

        private async Task EdiQuestionsAsync(Exercises exercises, AdminExerciseEditModel model)
        {
            var selectedQuestionsId = model.Questions;
            var oldQuestionsId = exercises.Questions.AsEnumerable();
            var deletedQuestionsId = selectedQuestionsId.Where(f => !oldQuestionsId.Any(e=>e.Id == f.Id)).ToList();
            var newQuestionsId = oldQuestionsId.Where(f => !selectedQuestionsId.Any(e => e.Id == f.Id)).ToList();

            //var newQuesion = model.Questions.Where(e => newQuestionsId.Any(j => e.Id == j)).ToList();

        }
    }

}
