using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Grammar.Data.Interfaces.Admin.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Grammar.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TypesController : Controller
    {
        private readonly IAdminTypesServices _adminTypesServices;

        public TypesController(IAdminTypesServices adminTypesServices)
        {
            _adminTypesServices = adminTypesServices;
        }

        // action for list of Categories

        [HttpGet]
        [Route("type")]
        public async Task<IActionResult> GetSubCategoriesListAsync()
        {
            var model = await _adminTypesServices.GetAllTypesAsync();
            if (model == null)
            {
                return BadRequest("ტიპები არ მოიძებნა");
            }
            return Ok(model);
        }
    }
}
