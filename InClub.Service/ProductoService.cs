using System;
using InClub.Entities;
using InClub.Domain;
using InClub.Exceptions;
using System.Threading.Tasks;

namespace InClub.Service
{
    public class ProductoService
    {
        public async Task<ProductoResponse> Execute(ProductoRequest request)
        {
            ProductoResponse response = new ProductoResponse();
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
                            response.IdDocumento = await new ProductoDomain().CreateProducto(request.Item);
                            break;
                        case Operation.Edit:
                            response.Item = await new ProductoDomain().UpdateProducto(request.Item);
                            break;
                        case Operation.Delete:
                            response.Item = await new ProductoDomain().DeleteProducto(request.Item.IdProducto);
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

        public ProductoLstItemResponse GetLstDocumento(ProductoLstItemRequest request)
        {
            ProductoLstItemResponse response = new ProductoLstItemResponse();
            //response.ValidateRequest(request);
            response.InitializeResponse(request);
            try
            {
                if (response.LstError.Count == 0)
                {
                    switch (request.FilterType)
                    {
                        case ProductoFilterLstItemType.Undefined:
                            response.LstItem = new ProductoDomain().GetById(request.Filter, request.FilterType, request.Pagination);
                            break;
                        case ProductoFilterLstItemType.ByPagination:
                            response.LstItem = new ProductoDomain().GetByPagination(request.Filter, request.FilterType, request.Pagination);
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
