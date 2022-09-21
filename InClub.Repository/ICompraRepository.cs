using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using InClub.Entities;

namespace InClub.Repository
{
   
    public interface ICompraRepository : IGenericRepository<CompraEntity>
    {

        Task<int> InsertCompra(CompraEntity item);
        IEnumerable<CompraEntity> GetLstItem(CompraFilter filter, CompraFilterLstItemType filterType, Pagination pagination);

        Task<bool> EditeCompra(CompraEntity Item);

        Task<bool> DeleteCompra(int ID);

    }
}
