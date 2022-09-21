using System;
using System.Collections.Generic;
using System.Text;
using InClub.Entities;
using System.Linq;

namespace InClub.Service
{
    public static  class Usuario_RequestValidator
    {
        #region Validate 
        public static void ValidateRequest(this UsuarioResponse response, UsuarioRequest request)
        {
            if (request.Item == null)
            {
                response.LstError.Add("Se requiere la entidad Usuario");
            }
            if (string.IsNullOrEmpty(request.ServerName))
            {
                response.LstError.Add("No se identifico el servidor de origen para la solicitud");
            }
            if (string.IsNullOrEmpty(request.UserName))
            {
                response.LstError.Add("No se identifico el usuario que realizo la solicitud");
            }
        }
        #endregion
        #region Initialize 
        public static void InitializeResponse(this UsuarioResponse response, UsuarioRequest request)
        {
            response.Ticket = request.Ticket;
            response.ServerName = request.ServerName;
            response.UserName = request.UserName;
        }
        public static void InitializeResponse(this UsuarioItemResponse response, UsuarioItemRequest request)
        {
            response.Ticket = request.Ticket;
            response.ServerName = request.ServerName;
            response.UserName = request.UserName;
        }
        public static void InitializeResponse(this UsuarioLstItemResponse response, UsuarioLstItemRequest request)
        {
            response.Ticket = request.Ticket;
            response.ServerName = request.ServerName;
            response.UserName = request.UserName;
            response.Pagination = request.Pagination;
        }
        #endregion
    }
}
