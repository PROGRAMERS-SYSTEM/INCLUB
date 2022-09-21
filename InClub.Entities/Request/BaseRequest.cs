using System;
using System.Collections.Generic;
using System.Text;

namespace InClub.Entities
{
    public enum Operation : byte
    {
        Undefined,
        Add,
        Edit,
        Delete
    }

    public class Pagination
    {
        public int PageIndex { get; set; } = 0;
        public int PageSize { get; set; } = 0;
        public int TotalRows { get; set; } = 0;
    }

    public abstract class BaseRequest
    {
        public Guid Ticket { get; set; } = Guid.NewGuid();
        public string ClientName { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;
        public string ServerName { get; set; } = string.Empty;
    }

    public abstract class OperationRequest<T> : BaseRequest
    {
        public T Item { get; set; }
        public Operation Operation { get; set; }
        public string Dni { get; set; }
    }

    public abstract class FilterItemRequest<T, F> : BaseRequest
    {
        public T Filter { get; set; }
        public F FilterType { get; set; }
    }

    public abstract class FilterLstItemRequest<T, F> : BaseRequest
    {
        public T Filter { get; set; }
        public F FilterType { get; set; }
        public Pagination Pagination { get; set; } = new Pagination();
    }
}
