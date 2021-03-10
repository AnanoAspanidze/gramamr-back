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
    public class SubCategoriesController : Controller
    {
        private readonly IAdminSubCategoriesServices _subCategoriesServices;

        public SubCategoriesController(IAdminSubCategoriesServices subCategoriesServices)
        {
            _subCategoriesServices = subCategoriesServices;
        }
        // action for list of SubCategories
        #region SubCategories
        [HttpGet]
        [Route("subcategories")]
        public async Task<IActionResult> GetSubCategoriesListAsync()
        {
            var model = await _subCategoriesServices.GetAllSubCategoriesAsync();
            return Ok(model);
        }
    }
}
#endregion