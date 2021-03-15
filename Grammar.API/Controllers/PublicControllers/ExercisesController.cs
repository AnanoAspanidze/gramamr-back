using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Grammar.Data.Interfaces.Admin.Interfaces;
using Grammar.Data.Models.Admin.Models.Exercises;
using Microsoft.AspNetCore.Mvc;

namespace Grammar.API.Controllers.PublicControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExercisesController : Controller
    {
        private readonly IAdminExercisesServices _exercisesServices;

        public ExercisesController(IAdminExercisesServices exercisesServices)
        {
            _exercisesServices = exercisesServices;
        }
        // action for list of exercises
        [HttpGet]
        [Route("exercises")]
        public async Task<IActionResult> GetExercisesAsync()
        {
            var model = await _exercisesServices.GetAllExercisesAsync();
            if (model == null)
            {
                return BadRequest("სავარჯიშოები არ მოიძებნა");
            }
            return Ok(model);
        }

        // action for add words
        [HttpPost]
        [Route("CreateExercise")]
        public async Task<IActionResult> CreateExerciseAsync([FromBody] AdminExerciseCreateModel model)
        {
            if (ModelState.IsValid)
            {
                var isSuccessful = await _exercisesServices.CreateExercisesAsync(model);
                if (isSuccessful)
                    return Ok("სიტყვა წარმატებით დაემატა");
            else
                    return BadRequest("შეცდომა სავარჯიშოს დამატებაში");
            }
            else
            {
                return BadRequest("შეცდომა სიტყვის დამატებაში");
            }
        }
    }
}
