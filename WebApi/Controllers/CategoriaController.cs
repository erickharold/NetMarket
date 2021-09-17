using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;


namespace WebApi.Controllers
{
    //[Route("api/[controller]")]
    //[ApiController]
    public class CategoriaController : BaseApiController
    {
        private readonly IGenericRepository<Categoria> _categoriaRepository;

        public CategoriaController(IGenericRepository<Categoria> categoriaRepository)
        {
            _categoriaRepository = categoriaRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<Categoria>>> GetCategoriaAll()
        {
            var categorias = await _categoriaRepository.GetAllAsync();
            return Ok(categorias);
            
            //var productos = await _productoRepository.GetProductoAsync();
            //return Ok(productos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Categoria>> GetCategoriaById(int id)
        {
            return await _categoriaRepository.GetByIdAsync(id);

            //return await _productoRepository.GetProductoByIdAsync(id);
            //return Ok(productos);
        }
    }
}
