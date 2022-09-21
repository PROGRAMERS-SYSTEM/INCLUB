using System;
using InClub.Entities;
using InClub.Domain;
using InClub.Exceptions;
using System.Threading.Tasks;

namespace InClub.Service
{
    public class UsuarioService
    {
        public async Task<UsuarioResponse> Execute(UsuarioRequest request)
        {
            UsuarioResponse response = new UsuarioResponse();
            response.InitializeResponse(request);
            try
            {
                if (response.LstError.Count == 0)
                {
                    switch (request.Operation)
                    {
                        case Operation.Undefined:
                            break;
                        case Operation.Add:
                            response.IdDocumento = await new UsuarioDomain().CreateUsuario(request.Item);
                            break;
                        case Operation.Edit:
                            response.Item = await new UsuarioDomain().UpdateUsuario(request.Item);
                            break;
                        case Operation.Delete:
                            response.Item = await new UsuarioDomain().DeleteUsuario(request.Item.IdUsuario);
                            break;
                        default:
                            break;
                    }
                    response.IsSuccess = true;
                }
            }
            catch (CustomException ex)
            {
                response.LstError.Add(ex.CustomMessage);
            }
            catch (Exception ex)
            {
                response.LstError.Add("Server Error");
            }
            return response;
        }

        public UsuarioLstItemResponse GetLstDocumento(UsuarioLstItemRequest request)
        {
            UsuarioLstItemResponse response = new UsuarioLstItemResponse();
            //response.ValidateRequest(request);
            response.InitializeResponse(request);
            try
            {
                if (response.LstError.Count == 0)
                {
                    switch (request.FilterType)
                    {
                        case UsuarioFilterLstItemType.Undefined:
                            response.LstItem = new UsuarioDomain().GetById(request.Filter, request.FilterType, request.Pagination);
                            break;
                        case UsuarioFilterLstItemType.ByPagination:
                            response.LstItem = new UsuarioDomain().GetByPagination(request.Filter, request.FilterType, request.Pagination);
                            break;
                        default:
                            break;
                    }
                    response.IsSuccess = true;
                }
            }
            catch (CustomException ex)
            {
                response.LstError.Add(ex.CustomMessage);
            }
            catch (Exception ex)
            {
                response.LstError.Add("Server Error");
            }
            return response;
        }
    }
}
