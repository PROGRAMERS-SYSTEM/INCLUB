using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using InClub.Entities;
using InClub.Service;

namespace InClub.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {


        [HttpGet("GetByPagination", Name = "Producto_GetByPagination")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public IActionResult Get()
        {
            ProductoLstItemResponse response = null;
            ProductoLstItemRequest request = new ProductoLstItemRequest()
            {
                //Filter = new DocumentoFilter() { ID = ID },// Cambiar 
                FilterType = ProductoFilterLstItemType.ByPagination
            };
            //request.Pagination.PageIndex = 0;
            //request.Pagination.PageSize = 0;
            try
            {
                response = new ProductoService().GetLstDocumento(request);
                if (!response.IsSuccess)
                    return BadRequest(response);
            }
            catch (Exception)
            {
                throw;
            }
            return Ok(response);
        }

        [HttpGet("{ID}", Name = "Producto_Get")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult Get(int ID)
        {
            ProductoLstItemResponse response = null;
            ProductoLstItemRequest request = new ProductoLstItemRequest()
            {
                Filter = new ProductoFilter() { IdProducto = ID },
                FilterType = ProductoFilterLstItemType.Undefined
            };
            try
            {
                response = new ProductoService().GetLstDocumento(request);
                if (!response.IsSuccess)
                    return BadRequest(response);

            }
            catch (Exception)
            {
                throw;
            }
            return Ok(response);
        }

        // POST: api/Documento
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ProductoEntity Producto)
        {
            ProductoResponse response = null;
            ProductoRequest request = new ProductoRequest()
            {
                Item = Producto,
                Operation = Operation.Add
            };
            try
            {
                response = await new ProductoService().Execute(request);
                if (!response.IsSuccess)
                    return BadRequest(response);
            }
            catch (Exception)
            {
                throw;
            }
            return Ok(response);
        }

        // POST: api/Documento
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] ProductoEntity Producto)
        {
            ProductoResponse response = null;
            ProductoRequest request = new ProductoRequest()
            {
                Item = Producto,
                Operation = Operation.Edit
            };
            try
            {
                response = await new ProductoService().Execute(request);
                if (!response.IsSuccess)
                    return BadRequest(response);
            }
            catch (Exception)
            {
                throw;
            }
            return Ok(response);
        }


        [HttpPost("Delete", Name = "Producto_Delete")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> PostDelete([FromBody] ProductoEntity Producto)
        {
            ProductoResponse response = null;
            ProductoRequest request = new ProductoRequest()
            {
                Item = Producto,
                Operation = Operation.Delete
            };
            try
            {
                response = await new ProductoService().Execute(request);
                if (!response.IsSuccess)
                    return BadRequest(response);
            }
            catch (Exception)
            {
                throw;
            }
            return Ok(response);
        }

    }
}
