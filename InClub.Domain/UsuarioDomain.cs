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
    public class UsuarioDomain
    {
        #region MEF
        //This attribute declares something to be an import; that is, it will be filled by the composition engine when the object is composed.        
        [Import]
        private IUsuarioRepository _UsuarioRepository { get; set; }
        #endregion
        #region Constructor
        public UsuarioDomain()
        {
            //MEF will create an instance of the exported class and assign it to the import property for you.
            _UsuarioRepository = MEFContainer.Container.GetExport<IUsuarioRepository>();
        }

        #endregion
        public async Task<int> CreateUsuario(UsuarioEntity Usuario)
        {
            int id = 0;
            id = await _UsuarioRepository.InsertUsuario(Usuario);
            return id;
        }


        public IEnumerable<UsuarioEntity> GetByPagination(UsuarioFilter filter, UsuarioFilterLstItemType filterType, Pagination pagination)
        {

            List<UsuarioEntity> lst = null;
            lst = _UsuarioRepository.GetLstItem(filter, filterType, pagination).ToList();
            return lst;
        }


        public IEnumerable<UsuarioEntity> GetById(UsuarioFilter filter, UsuarioFilterLstItemType filterType, Pagination pagination)
        {

            List<UsuarioEntity> lst = null;
            lst = _UsuarioRepository.GetLstItem(filter, filterType, pagination).ToList();
            return lst;
        }


        public async Task<bool> DeleteUsuario(Int32 ID)
        {
            using (TransactionScope tx = new TransactionScope())
            {
                if (await _UsuarioRepository.DeleteUsuario(ID))
                {
                    tx.Complete();
                    return true;
                }
            }
            return false;
        }


        public async Task<bool> UpdateUsuario(UsuarioEntity Usuario)
        {
            using (TransactionScope tx = new TransactionScope())
            {
                if (await _UsuarioRepository.EditeUsuario(Usuario))
                {
                    tx.Complete();
                    return true;
                }
            }
            return false;
        }
    }
}
