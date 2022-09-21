using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using InClub.Repository;
using InClub.Entities;
using InClub.Util;
using System.Composition;

namespace InClub.Infraestructure
{
    [Export(typeof(IConnectionFactory))]
    public class ConnectionFactory : IConnectionFactory
    {
        public IDbConnection GetConnection
        {
            get
            {
                DbProviderFactory dbProvider = DbProviderFactories.GetFactory(TrackerConfig.databaseProvider);
                DbConnection cn = dbProvider.CreateConnection();
                cn.ConnectionString = TrackerConfig.connectionString;
                return cn;
            }
        }


    }
}
