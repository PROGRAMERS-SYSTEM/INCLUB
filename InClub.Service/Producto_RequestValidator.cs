using System;
using System.Collections.Generic;
using System.Text;
using InClub.Entities;
using System.Linq;

namespace InClub.Service
{
    public static class Producto_RequestValidator
    {
        #region Validate 
        public static void ValidateRequest(this ProductoResponse response, ProductoRequest request)
        {
            if (request.Item == null)
            {
                response.LstError.Add("Se requiere la entidad Producto");
            }
            if (string.IsNullOrEmpty(request.ServerName))
            {
                response.LstError.Add("No se identifico el servidor de origen para la solicitud");
            }
            if (string.IsNullOrEmpty(request.UserName))
            {
                response.LstError.Add("No se identifico el Producto que realizo la solicitud");
            }
        }
        #endregion
        #region Initialize 
        public static void InitializeResponse(this ProductoResponse response, ProductoRequest request)
        {
            response.Ticket = request.Ticket;
            response.ServerName = request.ServerName;
            response.UserName = request.UserName;
        }
        public static void InitializeResponse(this ProductoItemResponse response, ProductoItemRequest request)
        {
            response.Ticket = request.Ticket;
            response.ServerName = request.ServerName;
            response.UserName = request.UserName;
        }
        public static void InitializeResponse(this ProductoLstItemResponse response, ProductoLstItemRequest request)
        {
            response.Ticket = request.Ticket;
            response.ServerName = request.ServerName;
            response.UserName = request.UserName;
            response.Pagination = request.Pagination;
        }
        #endregion
    }
}
