using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace InClub.Repository
{
    public interface IConnectionFactory
    {
        IDbConnection GetConnection { get; }

    }
}
