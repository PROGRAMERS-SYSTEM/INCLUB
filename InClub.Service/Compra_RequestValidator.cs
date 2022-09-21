using System;
using System.Collections.Generic;
using System.Text;
using InClub.Entities;
using System.Linq;

namespace InClub.Service
{
    public static  class Compra_RequestValidator
    {
        #region Validate 
        public static void ValidateRequest(this CompraResponse response, CompraRequest request)
        {
            if (request.Item == null)
            {
                response.LstError.Add("Se requiere la entidad Compra");
            }
            if (string.IsNullOrEmpty(request.ServerName))
            {
                response.LstError.Add("No se identifico el servidor de origen para la solicitud");
            }
            if (string.IsNullOrEmpty(request.UserName))
            {
                response.LstError.Add("No se identifico el Compra que realizo la solicitud");
            }
        }
        #endregion
        #region Initialize 
        public static void InitializeResponse(this CompraResponse response, CompraRequest request)
        {
            response.Ticket = request.Ticket;
            response.ServerName = request.ServerName;
            response.UserName = request.UserName;
        }
        public static void InitializeResponse(this CompraItemResponse response, CompraItemRequest request)
        {
            response.Ticket = request.Ticket;
            response.ServerName = request.ServerName;
            response.UserName = request.UserName;
        }
        public static void InitializeResponse(this CompraLstItemResponse response, CompraLstItemRequest request)
        {
            response.Ticket = request.Ticket;
            response.ServerName = request.ServerName;
            response.UserName = request.UserName;
            response.Pagination = request.Pagination;
        }
        #endregion
    }
}
