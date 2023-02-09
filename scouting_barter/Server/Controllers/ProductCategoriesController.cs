﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using scouting_barter.Server.Data;
using scouting_barter.Server.IRepository;
using scouting_barter.Shared.Domain;

namespace scouting_barter.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductCategoriesController : ControllerBase
    {
        //private readonly ApplicationDbContext _context;
        private readonly IUnitOfWork _unitOfWork;

        //public ProductCategoriesController(ApplicationDbContext context)
        public ProductCategoriesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: api/ProductCategories
        [HttpGet]
        //public async Task<ActionResult<IEnumerable<ProductCategory>>> GetProductCategories()
        public async Task<IActionResult> GetProductCategories()
        {
            //return await _context.ProductCategories.ToListAsync();
            var ProductCategories = await _unitOfWork.ProductCategories.GetAll();
            return Ok(ProductCategories);
        }

        // GET: api/ProductCategories/5
        [HttpGet("{id}")]
        //public async Task<ActionResult<ProductCategory>> GetProductCategory(int id)
        public async Task<IActionResult> GetProductCategory(int id)
        {
            //var ProductCategory = await _context.ProductCategories.FindAsync(id);
            var ProductCategory = await _unitOfWork.ProductCategories.Get(q => q.Id == id);

            if (ProductCategory == null)
            {
                return NotFound();
            }

            //return ProductCategory;
            return Ok(ProductCategory);
        }

        // PUT: api/ProductCategories/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProductCategory(int id, ProductCategory ProductCategory)
        {
            if (id != ProductCategory.Id)
            {
                return BadRequest();
            }

            //_context.Entry(ProductCategory).State = EntityState.Modified;
            _unitOfWork.ProductCategories.Update(ProductCategory);

            try
            {
                //await _context.SaveChangesAsync();
                await _unitOfWork.Save(HttpContext);
            }
            catch (DbUpdateConcurrencyException)
            {
                //if (!ProductCategoryExists(id))
                if (!await ProductCategoryExists(id))
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

        // POST: api/ProductCategories
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ProductCategory>> PostProductCategory(ProductCategory ProductCategory)
        {
            //_context.ProductCategories.Add(ProductCategory);
            //await _context.SaveChangesAsync();
            await _unitOfWork.ProductCategories.Insert(ProductCategory);
            await _unitOfWork.Save(HttpContext);

            return CreatedAtAction("GetProductCategory", new { id = ProductCategory.Id }, ProductCategory);
        }

        // DELETE: api/ProductCategories/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProductCategory(int id)
        {
            //var ProductCategory = await _context.ProductCategories.FindAsync(id);
            var ProductCategory = await _unitOfWork.ProductCategories.Get(q => q.Id == id);
            if (ProductCategory == null)
            {
                return NotFound();
            }

            //_context.ProductCategories.Remove(ProductCategory);
            //await _context.SaveChangesAsync();
            await _unitOfWork.ProductCategories.Delete(id);
            await _unitOfWork.Save(HttpContext);

            return NoContent();
        }

        //private bool ProductCategoryExists(int id)
        private async Task<bool> ProductCategoryExists(int id)
        {
            //return _context.ProductCategories.Any(e => e.Id == id);
            var ProductCategory = await _unitOfWork.ProductCategories.Get(q => q.Id == id);
            return ProductCategory != null;
        }
    }
}
