using System;
using System.Collections.Generic;
using System.Text;

namespace InClub.Entities
{
    public abstract class BaseResponse : BaseRequest
    {
        public bool IsSuccess { get; set; } = false;
        public List<string> LstError { get; set; } = new List<string>();
    }

    public abstract class ItemResponse<T> : BaseResponse
    {
        public T Item { get; set; }
        public int IdDocumento { get; set; } = 0;
        public string Respuesta { get; set; } = "";
        public long CodigoRegistro { get; set; } = 0;
    }

    public abstract class LstItemResponse<T> : BaseResponse
    {
        public IEnumerable<T> LstItem { get; set; } = new List<T>();
        public Pagination Pagination { get; set; } = new Pagination();
    }
}
