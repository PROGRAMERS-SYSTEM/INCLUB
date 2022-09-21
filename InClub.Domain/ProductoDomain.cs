using System.Transactions;
using System.Linq;
using InClub.Repository;
using InClub.Entities;
using InClub.Exceptions;
using System.Collections.Generic;
using System.Composition;
using InClub.Util;
using System;
using System.Threading.Tasks;

namespace InClub.Domain
{
    public class ProductoDomain
    {

        #region MEF
        //This attribute declares something to be an import; that is, it will be filled by the composition engine when the object is composed.        
        [Import]
        private IProductoRepository _ProductoRepository { get; set; }
        #endregion
        #region Constructor
        public ProductoDomain()
        {
            //MEF will create an instance of the exported class and assign it to the import property for you.
            _ProductoRepository = MEFContainer.Container.GetExport<IProductoRepository>();
        }

        #endregion
        public async Task<int> CreateProducto(ProductoEntity Producto)
        {
            int id = 0;
            id = await _ProductoRepository.InsertProducto(Producto);
            return id;
        }


        public IEnumerable<ProductoEntity> GetByPagination(ProductoFilter filter, ProductoFilterLstItemType filterType, Pagination pagination)
        {

            List<ProductoEntity> lst = null;
            lst = _ProductoRepository.GetLstItem(filter, filterType, pagination).ToList();
            return lst;
        }


        public IEnumerable<ProductoEntity> GetById(ProductoFilter filter, ProductoFilterLstItemType filterType, Pagination pagination)
        {

            List<ProductoEntity> lst = null;
            lst = _ProductoRepository.GetLstItem(filter, filterType, pagination).ToList();
            return lst;
        }


        public async Task<bool> DeleteProducto(Int32 ID)
        {
            using (TransactionScope tx = new TransactionScope())
            {
                if (await _ProductoRepository.DeleteProducto(ID))
                {
                    tx.Complete();
                    return true;
                }
            }
            return false;
        }


        public async Task<bool> UpdateProducto(ProductoEntity Producto)
        {
            using (TransactionScope tx = new TransactionScope())
            {
                if (await _ProductoRepository.EditeProducto(Producto))
                {
                    tx.Complete();
                    return true;
                }
            }
            return false;
        }
    }
}
