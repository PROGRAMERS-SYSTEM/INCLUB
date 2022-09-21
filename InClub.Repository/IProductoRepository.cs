using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using InClub.Entities;

namespace InClub.Repository
{

    public interface IProductoRepository : IGenericRepository<ProductoEntity>
    {

        Task<int> InsertProducto(ProductoEntity item);
        IEnumerable<ProductoEntity> GetLstItem(ProductoFilter filter, ProductoFilterLstItemType filterType, Pagination pagination);

        Task<bool> EditeProducto(ProductoEntity Item);

        Task<bool> DeleteProducto(int ID);

    }
}
