using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    //[Route("api/[controller]")]
    //[ApiController]
    public class MarcaController : BaseApiController
    {
        private readonly IGenericRepository<Marca> _marcaRepository;

        public MarcaController(IGenericRepository<Marca> categoriaRepository)
        {
            _marcaRepository = categoriaRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<Marca>>> GetMarcaAll()
        {
            var marcas = await _marcaRepository.GetAllAsync();
            return Ok(marcas);

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Marca>> GetMarcaById(int id)
        {
            return await _marcaRepository.GetByIdAsync(id);
        }

    }
}
