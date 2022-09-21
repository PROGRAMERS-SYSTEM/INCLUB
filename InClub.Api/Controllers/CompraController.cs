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
    public class CompraController : ControllerBase
    {


        [HttpGet("GetByPagination", Name = "Compra_GetByPagination")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public IActionResult Get()
        {
            CompraLstItemResponse response = null;
            CompraLstItemRequest request = new CompraLstItemRequest()
            {
                //Filter = new DocumentoFilter() { ID = ID },// Cambiar 
                FilterType = CompraFilterLstItemType.ByPagination
            };
            //request.Pagination.PageIndex = 0;
            //request.Pagination.PageSize = 0;
            try
            {
                response = new CompraService().GetLstDocumento(request);
                if (!response.IsSuccess)
                    return BadRequest(response);
            }
            catch (Exception)
            {
                throw;
            }
            return Ok(response);
        }

        [HttpGet("{ID}", Name = "Compra_Get")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult Get(int ID)
        {
            CompraLstItemResponse response = null;
            CompraLstItemRequest request = new CompraLstItemRequest()
            {
                Filter = new CompraFilter() { IdCompra = ID },
                FilterType = CompraFilterLstItemType.Undefined
            };
            try
            {
                response = new CompraService().GetLstDocumento(request);
                if (!response.IsSuccess)
                    return BadRequest(response);

            }
            catch (Exception)
            {
                throw;
            }
            return Ok(response);
        }

        [HttpGet("ByUsuario/{IDUSUARIO}", Name = "Compra_GetByUsuario")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult GetByUsuario(int IDUSUARIO)
        {
            CompraLstItemResponse response = null;
            CompraLstItemRequest request = new CompraLstItemRequest()
            {
                Filter = new CompraFilter() { IdUsuario = IDUSUARIO },
                FilterType = CompraFilterLstItemType.ByIdDocumento
            };
            try
            {
                response = new CompraService().GetLstDocumento(request);
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
        public async Task<IActionResult> Post([FromBody] CompraEntity Compra)
        {
            CompraResponse response = null;
            CompraRequest request = new CompraRequest()
            {
                Item = Compra,
                Operation = Operation.Add
            };
            try
            {
                response = await new CompraService().Execute(request);
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
        public async Task<IActionResult> Put([FromBody] CompraEntity Compra)
        {
            CompraResponse response = null;
            CompraRequest request = new CompraRequest()
            {
                Item = Compra,
                Operation = Operation.Edit
            };
            try
            {
                response = await new CompraService().Execute(request);
                if (!response.IsSuccess)
                    return BadRequest(response);
            }
            catch (Exception)
            {
                throw;
            }
            return Ok(response);
        }


        [HttpPost("Delete", Name = "Compra_Delete")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> PostDelete([FromBody] CompraEntity Compra)
        {
            CompraResponse response = null;
            CompraRequest request = new CompraRequest()
            {
                Item = Compra,
                Operation = Operation.Delete
            };
            try
            {
                response = await new CompraService().Execute(request);
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
