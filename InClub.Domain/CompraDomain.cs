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
    public class CompraDomain
    {
        #region MEF
        //This attribute declares something to be an import; that is, it will be filled by the composition engine when the object is composed.        
        [Import]
        private ICompraRepository _CompraRepository { get; set; }
        #endregion
        #region Constructor
        public CompraDomain()
        {
            //MEF will create an instance of the exported class and assign it to the import property for you.
            _CompraRepository = MEFContainer.Container.GetExport<ICompraRepository>();
        }

        #endregion
        public async Task<int> CreateCompra(CompraEntity Compra)
        {
            int id = 0;
            id = await _CompraRepository.InsertCompra(Compra);
            return id;
        }


        public IEnumerable<CompraEntity> GetByPagination(CompraFilter filter, CompraFilterLstItemType filterType, Pagination pagination)
        {

            List<CompraEntity> lst = null;
            lst = _CompraRepository.GetLstItem(filter, filterType, pagination).ToList();
            return lst;
        }



        public IEnumerable<CompraEntity> GetById(CompraFilter filter, CompraFilterLstItemType filterType, Pagination pagination)
        {

            List<CompraEntity> lst = null;
            lst = _CompraRepository.GetLstItem(filter, filterType, pagination).ToList();
            return lst;
        }

        public IEnumerable<CompraEntity> GetByUsuario(CompraFilter filter, CompraFilterLstItemType filterType, Pagination pagination)
        {

            List<CompraEntity> lst = null;
            lst = _CompraRepository.GetLstItem(filter, filterType, pagination).ToList();
            return lst;
        }
        public async Task<bool> DeleteCompra(Int32 ID)
        {
            using (TransactionScope tx = new TransactionScope())
            {
                if (await _CompraRepository.DeleteCompra(ID))
                {
                    tx.Complete();
                    return true;
                }
            }
            return false;
        }


        public async Task<bool> UpdateCompra(CompraEntity Compra)
        {
            using (TransactionScope tx = new TransactionScope())
            {
                if (await _CompraRepository.EditeCompra(Compra))
                {
                    tx.Complete();
                    return true;
                }
            }
            return false;
        }
    }
}
