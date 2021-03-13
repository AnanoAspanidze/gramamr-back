using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Grammar.Data.Interfaces.Admin.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Grammar.API.Controllers.PublicControllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : Controller
    {
        private readonly IAdminCategoriesServices _categoriesServices;

        public CategoriesController(IAdminCategoriesServices categoriesServices)
        {
            _categoriesServices = categoriesServices;
        }

        // action for list of Categories
      
        [HttpGet]
        [Route("categories")]
        public async Task<IActionResult> GetSubCategoriesListAsync()
        {
            var model = await _categoriesServices.GetAllCategoriesAsync();
            if (model == null)
            {
                return BadRequest("კატეგორიები არ მოიძებნა");
            }
            return Ok(model);
        }
    }
}
