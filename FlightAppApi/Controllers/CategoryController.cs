using FlightAppApi.Model;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace FlightAppApi.Controllers
{
    [ApiConventionType(typeof(DefaultApiConventions))]
    [Produces("application/json")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        /// <summary>
        /// Get all categories
        /// </summary>        
        [HttpGet]
        [AllowAnonymous]
        public IEnumerable<Category> GetProducts()
        {
            return _categoryRepository.GetCategories();
        }

        /// <summary>
        /// Get all products from category
        /// </summary>        

        [HttpGet("{category}")]
        [AllowAnonymous]
        public IEnumerable<Product> GetProductsFromCategory(string category)
        {
            //return _productRepository.GetProductsByCategory(category);
            return null;
        }
    }
}
