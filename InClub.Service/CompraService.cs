using System;
using InClub.Entities;
using InClub.Domain;
using InClub.Exceptions;
using System.Threading.Tasks;

namespace InClub.Service
{
    public  class CompraService
    {
        public async Task<CompraResponse> Execute(CompraRequest request)
        {
            CompraResponse response = new CompraResponse();
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
                            response.IdDocumento = await new CompraDomain().CreateCompra(request.Item);
                            break;
                        case Operation.Edit:
                            response.Item = await new CompraDomain().UpdateCompra(request.Item);
                            break;
                        case Operation.Delete:
                            response.Item = await new CompraDomain().DeleteCompra(request.Item.IdCompra);
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

        public CompraLstItemResponse GetLstDocumento(CompraLstItemRequest request)
        {
            CompraLstItemResponse response = new CompraLstItemResponse();
            //response.ValidateRequest(request);
            response.InitializeResponse(request);
            try
            {
                if (response.LstError.Count == 0)
                {
                    switch (request.FilterType)
                    {
                        case CompraFilterLstItemType.Undefined:
                            response.LstItem = new CompraDomain().GetById(request.Filter, request.FilterType, request.Pagination);
                            break;
                        case CompraFilterLstItemType.ByPagination:
                            response.LstItem = new CompraDomain().GetByPagination(request.Filter, request.FilterType, request.Pagination);
                            break;
                        case CompraFilterLstItemType.ByIdDocumento:
                            response.LstItem = new CompraDomain().GetByUsuario(request.Filter, request.FilterType, request.Pagination);
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
