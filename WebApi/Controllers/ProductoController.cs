﻿using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Core.Specifications;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Dtos;
using WebApi.Errors;

namespace WebApi.Controllers
{
    public class ProductoController : BaseApiController
    {

        //private readonly IProductoRepository _productoRepository;
        private readonly IGenericRepository<Producto> _productoRepository;
        private readonly IMapper _mapper;

        public ProductoController(IGenericRepository<Producto> productoRepository, IMapper mapper)
        {
            _productoRepository = productoRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<Pagination<ProductoDto>>> GetProductos([FromQuery] ProductoSpecificationParams productoParams) 
        {
            var spec = new ProductoWithCategoriaAndMarca(productoParams);

            var productos = await _productoRepository.GetAllWithSpec(spec);

            var specCount = new ProductoForCountingSpecification(productoParams);

            var totalProductos = await _productoRepository.CountAsync(specCount);

            var rounded = Math.Ceiling(Convert.ToDecimal(totalProductos / productoParams.PageSize));

            var totalPages = Convert.ToInt32(rounded);

            var data = _mapper.Map<IReadOnlyList<Producto>, IReadOnlyList<ProductoDto>>(productos);

            return Ok(
                new Pagination<ProductoDto>
                {
                    Count = totalProductos,
                    Data = data,
                    PageCount = totalPages,
                    PageIndex = productoParams.PageIndex,
                    PageSize = productoParams.PageSize
                }) ;

            //return Ok(_mapper.Map<IReadOnlyList<Producto>, IReadOnlyList<ProductoDto>>(productos));


            //var productos = await _productoRepository.GetAllAsync();
            //return Ok(productos);


            //var productos = await _productoRepository.GetProductoAsync();
            //return Ok(productos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductoDto>> GetProducto(int id)
        {

            //INCLUIR LAS RELACIONES DE LAS ENTIDAS MARCA - CATEGORIA Y LA LOGICA DE LA CONDICION
            var spec = new ProductoWithCategoriaAndMarca(id);
            var producto = await _productoRepository.GetByIdWithSpec(spec);


            if(producto == null)
            {
                return NotFound(new CodeErrorResponse(404, "El producto no exite"));
            }

            return _mapper.Map<Producto, ProductoDto>(producto);

            //return await _productoRepository.GetByIdWithSpec(spec);

            //return await _productoRepository.GetByIdAsync(id);
            //return await _productoRepository.GetProductoByIdAsync(id);
            //return Ok(productos);
        }
    }
}
