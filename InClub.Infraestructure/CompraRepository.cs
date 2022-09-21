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
   
    [Export(typeof(ICompraRepository))]
    public class CompraRepository : BaseRepository, ICompraRepository
    {
        #region Constructor
        [ImportingConstructor]
        public CompraRepository(IConnectionFactory cn) : base(cn)
        {
        }
        #endregion
        #region Public Methods
        public async Task<int> InsertCompra(CompraEntity item)
        {
            int id = 0;
            int Codigo = 0;
            var query = "usp_Compra_Insert";


            var param = new DynamicParameters();
            param.Add("@Boleta", item.Boleta, DbType.String);
            param.Add("@Numero", item.Numero, DbType.Int32);
            param.Add("@UsrReg", item.UsrReg, DbType.Int32);

            param.Add("@IdSalida", 0, DbType.Int32, direction: ParameterDirection.Output);
            id = SqlMapper.Execute(this._connectionFactory.GetConnection, query, param, commandType: CommandType.StoredProcedure);

            Codigo = param.Get<int>("@IdSalida");

            return Codigo;
        }

        public async Task<bool> DeleteCompra(int ID)
        {
            bool exito = false;
            var regAfectados = 0;
            var query = "usp_Compra_Delete";
            var param = new DynamicParameters();

            param.Add("@IdCompra", ID, DbType.Int32);



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
        public bool Update(CompraEntity item)
        {
            throw new NotImplementedException();
        }
        public async Task<bool> EditeCompra(CompraEntity item)
        {
            var exito = false;
            long id = 0;
            var query = "usp_Compra_Update";

            var param = new DynamicParameters();

            param.Add("@IdCompra", item.IdCompra, DbType.Int32);
            param.Add("@Boleta", item.Boleta, DbType.String);
            param.Add("@Numero", item.Numero, DbType.Int32);

            param.Add("@UsrMod", item.UsrMod, DbType.Int32);

            param.Add("@IdSalida", 0, DbType.Int32, direction: ParameterDirection.Output);
            id = SqlMapper.Execute(this._connectionFactory.GetConnection, query, param, commandType: CommandType.StoredProcedure);
            //id = (long)SqlMapper.Execute(this._connectionFactory.GetConnection, query, param, commandType: CommandType.StoredProcedure);
            if (id != 0) { exito = true; }
            return exito;
        }

        public IEnumerable<CompraEntity> GetLstItem(CompraFilter filter, CompraFilterLstItemType filterType, Pagination pagination)
        {

            IEnumerable<CompraEntity> lstItemFound = new List<CompraEntity>();
            switch (filterType)
            {
                case CompraFilterLstItemType.Undefined:
                    lstItemFound = this.GetById(filter.IdCompra);
                    break;
                case CompraFilterLstItemType.ByPagination:
                    lstItemFound = this.GetByPagination();

                    break;
                case CompraFilterLstItemType.ByIdDocumento:
                    lstItemFound = this.GetByUsuario(filter.IdUsuario);

                    break;
                default:
                    break;
            }
            return lstItemFound;
        }
        #endregion

        private IEnumerable<CompraEntity> GetById(int Id)
        {
            IEnumerable<CompraEntity> lstFound = new List<CompraEntity>();
            var query = "usp_Compra_Get";
            var param = new DynamicParameters();

            param.Add("@IdCompra", Id, DbType.Int32);

            lstFound = SqlMapper.Query<CompraEntity>(this._connectionFactory.GetConnection, query, param, commandType: CommandType.StoredProcedure);
            return lstFound;
        }

        private IEnumerable<CompraEntity> GetByUsuario(int Id)
        {
            IEnumerable<CompraEntity> lstFound = new List<CompraEntity>();
            var query = "usp_Compra_Get";
            var param = new DynamicParameters();

            param.Add("@IdUsuario", Id, DbType.Int32);

            lstFound = SqlMapper.Query<CompraEntity>(this._connectionFactory.GetConnection, query, param, commandType: CommandType.StoredProcedure);
            return lstFound;
        }
        private IEnumerable<CompraEntity> GetByPagination()
        {
            IEnumerable<CompraEntity> lstFound = new List<CompraEntity>();
            var query = "usp_Compra_Get";
            var param = new DynamicParameters();

            param.Add("@IdCompra", 0, DbType.Int32);

            lstFound = SqlMapper.Query<CompraEntity>(this._connectionFactory.GetConnection, query, param, commandType: CommandType.StoredProcedure);
            return lstFound;
        }



    }
}
