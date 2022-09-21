using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using InClub.Entities;

namespace InClub.Repository
{
   
    public interface IUsuarioRepository : IGenericRepository<UsuarioEntity>
    {

        Task<int> InsertUsuario(UsuarioEntity item);
        IEnumerable<UsuarioEntity> GetLstItem(UsuarioFilter filter, UsuarioFilterLstItemType filterType, Pagination pagination);

        Task<bool> EditeUsuario(UsuarioEntity Item);

        Task<bool> DeleteUsuario(int ID);

    }
}
