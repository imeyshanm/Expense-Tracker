using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Expense_Tracker.DBContexts;
using Expense_Tracker.Model;
using Expense_Tracker.DTO;
using Expense_Tracker.Repository;
using MapsterMapper;
//using Nelibur.ObjectMapper;
//using AutoMapper;

namespace Expense_Tracker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CategoryController(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }
        //public CategoryController(ICategoryRepository categoryRepository)
        //{
        //    _categoryRepository = categoryRepository;
        //}

        // GET: api/Category
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoryDto>>> GetCategorys()
        {
            //await _categoryRepository.GetCategories().ToListAsync()
            var Categorie = await _categoryRepository.GetCategories();
            //var categorydto = TinyMapper.Map<IEnumerable<CategoryDto>>(Categorie);
            var categorydto = _mapper.Map<IEnumerable<CategoryDto>>(Categorie);
            return categorydto.ToList();
        }

        // GET: api/Category/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CategoryDto>> GetCategory(int id)
        {
            var category = await _categoryRepository.GetCategory(id);
            //var categorydto = TinyMapper.Map<CategoryDto>(category);
            var categorydto = _mapper.Map<CategoryDto>(category);

            if (categorydto == null)
            {
                return NotFound();
            }

            return categorydto;
        }

        // PUT: api/Category/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCategory(int id, CategoryDto category)
        {
            if (id != category.CategoryID)
            {
                return BadRequest();
            }

            try
            {
                //var CategoryDto= TinyMapper.Map<Category>(category);
                var CategoryDto = _mapper.Map<Category>(category);

                await _categoryRepository.UpdateCategory(CategoryDto);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await CategoryExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Category
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CategoryDto>> PostCategory(CategoryDto category)
        {
            await _categoryRepository.InsertCategory(null);

            return CreatedAtAction("GetCategory", new { id = category.CategoryID }, category);
        }

        // DELETE: api/Category/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var category = await _categoryRepository.GetCategory(id);
            if (category == null)
            {
                return NotFound();
            }

            await _categoryRepository.DeleteCategory(id);

            return NoContent();
        }

        private async Task<bool> CategoryExists(int id)
        {
            return await _categoryRepository.GetCategory(id) == null;
        }
    }
}
