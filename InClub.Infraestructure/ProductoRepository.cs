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
   
    [Export(typeof(IProductoRepository))]
    public class ProductoRepository : BaseRepository, IProductoRepository
    {
        #region Constructor
        [ImportingConstructor]
        public ProductoRepository(IConnectionFactory cn) : base(cn)
        {
        }
        #endregion
        #region Public Methods
        public async Task<int> InsertProducto(ProductoEntity item)
        {
            int id = 0;
            int Codigo = 0;
            var query = "usp_Producto_Insert";


            var param = new DynamicParameters();
            param.Add("@Descripcion", item.Descripcion, DbType.String);
            param.Add("@Precio", item.Precio, DbType.Decimal);
            param.Add("@UsrReg", item.UsrReg, DbType.Int32);

            param.Add("@IdSalida", 0, DbType.Int32, direction: ParameterDirection.Output);
            id = SqlMapper.Execute(this._connectionFactory.GetConnection, query, param, commandType: CommandType.StoredProcedure);

            Codigo = param.Get<int>("@IdSalida");

            return Codigo;
        }

        public async Task<bool> DeleteProducto(int ID)
        {
            bool exito = false;
            var regAfectados = 0;
            var query = "usp_Producto_Delete";
            var param = new DynamicParameters();

            param.Add("@IdProducto", ID, DbType.Int32);



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
        public bool Update(ProductoEntity item)
        {
            throw new NotImplementedException();
        }
        public async Task<bool> EditeProducto(ProductoEntity item)
        {
            var exito = false;
            long id = 0;
            var query = "usp_Producto_Update";

            var param = new DynamicParameters();

            param.Add("@IdProducto", item.IdProducto, DbType.Int32);

            param.Add("@Descripcion", item.Descripcion, DbType.String);
            param.Add("@Precio", item.Precio, DbType.Decimal);

            param.Add("@UsrMod", item.UsrMod, DbType.Int32);

            param.Add("@IdSalida", 0, DbType.Int32, direction: ParameterDirection.Output);
            id = SqlMapper.Execute(this._connectionFactory.GetConnection, query, param, commandType: CommandType.StoredProcedure);
            //id = (long)SqlMapper.Execute(this._connectionFactory.GetConnection, query, param, commandType: CommandType.StoredProcedure);
            if (id != 0) { exito = true; }
            return exito;
        }

        public IEnumerable<ProductoEntity> GetLstItem(ProductoFilter filter, ProductoFilterLstItemType filterType, Pagination pagination)
        {

            IEnumerable<ProductoEntity> lstItemFound = new List<ProductoEntity>();
            switch (filterType)
            {
                case ProductoFilterLstItemType.Undefined:
                    lstItemFound = this.GetById(filter.IdProducto);
                    break;
                case ProductoFilterLstItemType.ByPagination:
                    lstItemFound = this.GetByPagination();

                    break;
                default:
                    break;
            }
            return lstItemFound;
        }
        #endregion

        private IEnumerable<ProductoEntity> GetById(int Id)
        {
            IEnumerable<ProductoEntity> lstFound = new List<ProductoEntity>();
            var query = "usp_Producto_Get";
            var param = new DynamicParameters();

            param.Add("@IdProducto", Id, DbType.Int32);

            lstFound = SqlMapper.Query<ProductoEntity>(this._connectionFactory.GetConnection, query, param, commandType: CommandType.StoredProcedure);
            return lstFound;
        }
        private IEnumerable<ProductoEntity> GetByPagination()
        {
            IEnumerable<ProductoEntity> lstFound = new List<ProductoEntity>();
            var query = "usp_Producto_Get";
            var param = new DynamicParameters();

            param.Add("@IdProducto", 0, DbType.Int32);

            lstFound = SqlMapper.Query<ProductoEntity>(this._connectionFactory.GetConnection, query, param, commandType: CommandType.StoredProcedure);
            return lstFound;
        }



    }
}
