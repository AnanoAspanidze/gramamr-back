using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Grammar.Data.Interfaces.Admin.Interfaces;
using Grammar.Data.Models.Admin.Models.SubCategories;
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
        [HttpGet]
        [Route("subcategories")]
        public async Task<IActionResult> GetSubCategoriesListAsync()
        {
            var model = await _subCategoriesServices.GetAllSubCategoriesAsync();
            if (model == null)
            {
                return BadRequest("საკითხები არ მოიძებნა");
            }
            return Ok(model);
        }

        [HttpGet]
        [Route("subcategorydetails")]
        public async Task<IActionResult> GetSubCategoryDetailsAsync(int id)
        {
            var model = await _subCategoriesServices.GetSubCategoryDetailsAsync(id);

            if (model == null)
            {
                return BadRequest("საკითხი არ მოიძებნა");
            }
            return Ok(model);
        }

        [HttpPost]
        [Route("createsubcategories")]
        public async Task<IActionResult> CreateSubCategoriesAsync(AdminSubCategoryCreateModel model)
        {
            if (ModelState.IsValid)
            {
                var modelCreated = await _subCategoriesServices.CreateSubCategoriesAsync(model);
                if (modelCreated)
                    return Ok("საკითხი დამატებულია");
                else
                    return BadRequest("შეცდომა საკითხის დამატების დროს");
            }
            return BadRequest("შეცდომა საკითხის დამატების დროს");
        }
        [HttpPut]
        [Route("editsubcategories")]
        public async Task<IActionResult> EditSubCategoriesAsync(int id, AdminSubCategoryEditModel model)
        {
            if (ModelState.IsValid)
            {
                var modelCreated = await _subCategoriesServices.EditSubCategoriesAsync(id, model);
                if (modelCreated)
                    return Ok("საკითხი წარმატებით დარედაქტირდა");
                else
                    return BadRequest("შეცდომა საკითხის რედაქტირების დროს");
            }
            return BadRequest("შეცდომა საკითხის რედაქტირების დროს");
        }

        // action for block word
        [HttpPost("HideSubCategory/{id}")]
        public async Task<IActionResult> BlockWord(int id)
        {
            if (ModelState.IsValid)
            {
                var model = await _subCategoriesServices.HideCategoryAsync(id);
                if (model == true) return Ok("საკითხი წარმატებით დაიბლოკა");
                return Ok(model);
            }
                return BadRequest("შეცდომა საკითხის  დაბლოკვის დროს");
        }

        // action for unblock word
        [HttpPost("unHideSubCategory/{id}")]
        public async Task<IActionResult> UnBlockWord(int id)
        {
            if (ModelState.IsValid)
            {
                var model = await _subCategoriesServices.UnHideCategoryAsync(id);
                if (model == true) return Ok("საკითხი წარმატებით განიბლოკა");
                return Ok(model);
            }
                return BadRequest("შეცდომა საკითხის   განბლოკვის დროს");
        }
    }
}
