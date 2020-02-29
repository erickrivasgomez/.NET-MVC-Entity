using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Training.API.Operations.Products;
using Training.DTO;

namespace Training.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IServiceProvider _IoC;

        public ProductsController(IServiceProvider services)
        {
            _IoC = services;
        }


        // GET: api/Product
        [HttpGet]
        public async Task<List<DTO.Product>> GetProducts()
        {
            DTO.Product product = new Product();
            List<DTO.Product> lista_product = new List<Product> { product };
            // return lista_product;
            return await _IoC.GetService<GetAllProducts>().Execute();
        }

        // GET: api/Product/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Product
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Product/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
