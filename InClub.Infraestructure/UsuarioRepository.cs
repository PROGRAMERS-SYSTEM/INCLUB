using System.Collections.Generic;
using InClub.Repository;
using Dapper;
using InClub.Entities;
using System.Linq;
using System.Data;
using System.Composition;
using System;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Net;

namespace InClub.Infraestructure
{
   

    [Export(typeof(IUsuarioRepository))]
    public class UsuarioRepository : BaseRepository, IUsuarioRepository
    {
        #region Constructor
        [ImportingConstructor]
        public UsuarioRepository(IConnectionFactory cn) : base(cn)
        {
        }
        #endregion
        #region Public Methods
        public async Task<int> InsertUsuario(UsuarioEntity item)
        {
            int id = 0;
            int Codigo = 0;
            var query = "usp_Usuario_Insert";


            var param = new DynamicParameters();
            param.Add("@Usuario", item.Usuario, DbType.String);
            param.Add("@Password", item.Password, DbType.String);        
            param.Add("@UsrReg", item.UsrReg, DbType.Int32);

            param.Add("@IdSalida", 0, DbType.Int32, direction: ParameterDirection.Output);
            id = SqlMapper.Execute(this._connectionFactory.GetConnection, query, param, commandType: CommandType.StoredProcedure);

            Codigo = param.Get<int>("@IdSalida");

            return Codigo;
        }

        public async Task<bool> DeleteUsuario(int ID)
        {
            bool exito = false;
            var regAfectados = 0;
            var query = "usp_Usuario_Delete";
            var param = new DynamicParameters();

            param.Add("@IdUsuario", ID, DbType.Int32);
            


            regAfectados = SqlMapper.Execute(this._connectionFactory.GetConnection, query, param, commandType: CommandType.StoredProcedure);
            exito = regAfectados != 0;
            return exito;
        }
        public bool Delete(string id)
        {
            throw new NotImplementedException();
        }
        public bool Delete(long ID)
        {
            throw new NotImplementedException();
        }
        public bool Update(UsuarioEntity item)
        {
            throw new NotImplementedException();
        }
        public async Task<bool> EditeUsuario(UsuarioEntity item)
        {
            var exito = false;
            long id = 0;
            var query = "usp_Usuario_Update";

            var param = new DynamicParameters();

            param.Add("@IdUsuario", item.IdUsuario, DbType.Int32);
            param.Add("@Usuario", item.Usuario, DbType.String);
            param.Add("@Password", item.Password, DbType.String);
            param.Add("@UsrMod", item.UsrMod, DbType.Int32);

            param.Add("@IdSalida", 0, DbType.Int32, direction: ParameterDirection.Output);
            id = SqlMapper.Execute(this._connectionFactory.GetConnection, query, param, commandType: CommandType.StoredProcedure);
            //id = (long)SqlMapper.Execute(this._connectionFactory.GetConnection, query, param, commandType: CommandType.StoredProcedure);
            if (id != 0) { exito = true; }
            return exito;
        }

        public IEnumerable<UsuarioEntity> GetLstItem(UsuarioFilter filter, UsuarioFilterLstItemType filterType, Pagination pagination)
        {

            IEnumerable<UsuarioEntity> lstItemFound = new List<UsuarioEntity>();
            switch (filterType)
            {
                case UsuarioFilterLstItemType.Undefined:
                    lstItemFound = this.GetById(filter.IdUsuario);
                    break;
                case UsuarioFilterLstItemType.ByPagination:
                    lstItemFound = this.GetByPagination();

                    break;
                default:
                    break;
            }
            return lstItemFound;
        }
        #endregion

        private IEnumerable<UsuarioEntity> GetById(int Id)
        {
            IEnumerable<UsuarioEntity> lstFound = new List<UsuarioEntity>();
            var query = "usp_Usuario_Get";
            var param = new DynamicParameters();

            param.Add("@IdUsuario", Id, DbType.Int32);

            lstFound = SqlMapper.Query<UsuarioEntity>(this._connectionFactory.GetConnection, query, param, commandType: CommandType.StoredProcedure);
            return lstFound;
        }
        private IEnumerable<UsuarioEntity> GetByPagination()
        {
            IEnumerable<UsuarioEntity> lstFound = new List<UsuarioEntity>();
            var query = "usp_Usuario_Get";
            var param = new DynamicParameters();

            param.Add("@IdUsuario", 0, DbType.Int32);

            lstFound = SqlMapper.Query<UsuarioEntity>(this._connectionFactory.GetConnection, query, param, commandType: CommandType.StoredProcedure);
            return lstFound;
        }



    }
}
