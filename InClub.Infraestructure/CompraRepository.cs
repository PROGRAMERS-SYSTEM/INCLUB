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
            int reg = 0;

            var param = new DynamicParameters();
            param.Add("@Boleta", item.Boleta, DbType.String);
            param.Add("@Numero", item.Numero, DbType.Int32);
            param.Add("@Total", item.Total, DbType.Decimal);
            param.Add("@UsrReg", item.UsrReg, DbType.Int32);

            param.Add("@IdSalida", 0, DbType.Int32, direction: ParameterDirection.Output);
            id = SqlMapper.Execute(this._connectionFactory.GetConnection, query, param, commandType: CommandType.StoredProcedure);

            Codigo = param.Get<int>("@IdSalida");

            var DC = item.DetalleCompra;
            if (item.DetalleCompra != null)
            {
                foreach (var var in DC.ToList())
                {

                    DetalleCompraEntity obj = new DetalleCompraEntity();

                    obj = var;
                    obj.IdCompra = Codigo;
                    reg = InsertDetalle(obj);
                }
            }

            return Codigo;
        }

        public int InsertDetalle(DetalleCompraEntity item)
        {
            int id = 0;
            int Codigo = 0;
            var query = "usp_DetalleCompra_Insert";

            var param = new DynamicParameters();

            param.Add("@IdCompra", item.IdCompra, DbType.Int32);
            param.Add("@IdProducto", item.IdProducto, DbType.Int32);
            
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
            param.Add("@Total", item.Total, DbType.Decimal);

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
            IEnumerable<CompraEntity> lstFound2 = new List<CompraEntity>();
            var query = "usp_Compra_Get";
            var param = new DynamicParameters();

            param.Add("@IdCompra", Id, DbType.Int32);

            lstFound = SqlMapper.Query<CompraEntity>(this._connectionFactory.GetConnection, query, param, commandType: CommandType.StoredProcedure);
            foreach (var item in lstFound.ToList())
            {
                lstFound2 = lstFound2.Append(new CompraEntity
                {
                    IdCompra=item.IdCompra,
                    Boleta = item.Boleta,
                    Numero=item.Numero,  
                    Total=item.Total,
                    DateReg = item.DateReg,
                    UsrReg = item.UsrReg,
                    DateMod = item.DateMod,
                    UsrMod = item.UsrMod,
                    Estado = item.Estado,
                    DetalleCompra = this.GetByCompra(item.IdCompra)

                });

            }
            return lstFound2;
        }

        private IEnumerable<CompraEntity> GetByUsuario(int Id)
        {
            IEnumerable<CompraEntity> lstFound = new List<CompraEntity>();
            IEnumerable<CompraEntity> lstFound2 = new List<CompraEntity>();
            var query = "usp_Compra_Get_ByUsuario";
            var param = new DynamicParameters();

            param.Add("@IdUsuario", Id, DbType.Int32);

            lstFound = SqlMapper.Query<CompraEntity>(this._connectionFactory.GetConnection, query, param, commandType: CommandType.StoredProcedure);
            foreach (var item in lstFound.ToList())
            {
                lstFound2 = lstFound2.Append(new CompraEntity
                {
                    IdCompra = item.IdCompra,
                    Boleta = item.Boleta,
                    Numero = item.Numero,
                    Total = item.Total,
                    DateReg = item.DateReg,
                    UsrReg = item.UsrReg,
                    DateMod = item.DateMod,
                    UsrMod = item.UsrMod,
                    Estado = item.Estado,
                    DetalleCompra = this.GetByCompra(item.IdCompra)

                });

            }
            return lstFound2;
        }

        private IEnumerable<DetalleCompraEntity> GetByCompra(int Id)
        {
            IEnumerable<DetalleCompraEntity> lstFound = new List<DetalleCompraEntity>();
            var query = "usp_DetalleCompra_Get";
            var param = new DynamicParameters();

            param.Add("@IdCompra", Id, DbType.Int32);

            lstFound = SqlMapper.Query<DetalleCompraEntity>(this._connectionFactory.GetConnection, query, param, commandType: CommandType.StoredProcedure);


            return lstFound;
        }
        private IEnumerable<CompraEntity> GetByPagination()
        {
            IEnumerable<CompraEntity> lstFound = new List<CompraEntity>();
            IEnumerable<CompraEntity> lstFound2 = new List<CompraEntity>();
            var query = "usp_Compra_Get";
            var param = new DynamicParameters();

            param.Add("@IdCompra", 0, DbType.Int32);

            lstFound = SqlMapper.Query<CompraEntity>(this._connectionFactory.GetConnection, query, param, commandType: CommandType.StoredProcedure);
            foreach (var item in lstFound.ToList())
            {
                lstFound2 = lstFound2.Append(new CompraEntity
                {
                    IdCompra = item.IdCompra,
                    Boleta = item.Boleta,
                    Numero = item.Numero,
                    Total = item.Total,
                    DateReg = item.DateReg,
                    UsrReg = item.UsrReg,
                    DateMod = item.DateMod,
                    UsrMod = item.UsrMod,
                    Estado = item.Estado,
                    DetalleCompra = this.GetByCompra(item.IdCompra)

                });

            }
            return lstFound2;
        }



    }
}
