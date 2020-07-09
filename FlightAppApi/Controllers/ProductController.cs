using FlightAppApi.DTO;
using FlightAppApi.Model;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightAppApi.Controllers
{
    [ApiConventionType(typeof(DefaultApiConventions))]
    [Produces("application/json")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productRepository;

        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        /// <summary>
        /// Get all products
        /// </summary>        
        [HttpGet]
        public IEnumerable<Product> GetProducts()
        {
            return _productRepository.GetAllProducts();
        }

        /// <summary>
        /// Get all products from category
        /// </summary>        

        [HttpGet("{category}")]
        public IEnumerable<Product> GetProductsFromCategory(Category category)
        {
            return _productRepository.GetProductsByCategory(category);
        }
    }
}
