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
    public class UsuarioController : ControllerBase
    {



        [HttpGet("GetByPagination", Name = "Usuario_GetByPagination")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public IActionResult Get()
        {
            UsuarioLstItemResponse response = null;
            UsuarioLstItemRequest request = new UsuarioLstItemRequest()
            {
                //Filter = new DocumentoFilter() { ID = ID },// Cambiar 
                FilterType = UsuarioFilterLstItemType.ByPagination
            };
            //request.Pagination.PageIndex = 0;
            //request.Pagination.PageSize = 0;
            try
            {
                response = new UsuarioService().GetLstDocumento(request);
                if (!response.IsSuccess)
                    return BadRequest(response);
            }
            catch (Exception)
            {
                throw;
            }
            return Ok(response);
        }

        [HttpGet("{ID}", Name = "Usuario_Get")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult Get(int ID)
        {
            UsuarioLstItemResponse response = null;
            UsuarioLstItemRequest request = new UsuarioLstItemRequest()
            {
                Filter = new UsuarioFilter() { IdUsuario = ID },
                FilterType = UsuarioFilterLstItemType.Undefined
            };
            try
            {
                response = new UsuarioService().GetLstDocumento(request);
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
        public async Task<IActionResult> Post([FromBody] UsuarioEntity Usuario)
        {
            UsuarioResponse response = null;
            UsuarioRequest request = new UsuarioRequest()
            {
                Item = Usuario,
                Operation = Operation.Add
            };
            try
            {
                response = await new UsuarioService().Execute(request);
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
        public async Task<IActionResult> Put([FromBody] UsuarioEntity Usuario)
        {
            UsuarioResponse response = null;
            UsuarioRequest request = new UsuarioRequest()
            {
                Item = Usuario,
                Operation = Operation.Edit
            };
            try
            {
                response = await new UsuarioService().Execute(request);
                if (!response.IsSuccess)
                    return BadRequest(response);
            }
            catch (Exception)
            {
                throw;
            }
            return Ok(response);
        }


        [HttpPost("Delete", Name = "Usuario_Delete")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> PostDelete([FromBody] UsuarioEntity Usuario)
        {
            UsuarioResponse response = null;
            UsuarioRequest request = new UsuarioRequest()
            {
                Item = Usuario,
                Operation = Operation.Delete
            };
            try
            {
                response = await new UsuarioService().Execute(request);
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
