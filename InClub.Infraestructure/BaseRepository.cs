using System;
using System.Collections.Generic;
using System.Composition;
using System.Text;
using InClub.Repository;

namespace InClub.Infraestructure
{
    public abstract class BaseRepository
    {
        #region IoC
        [Import]
        public IConnectionFactory _connectionFactory { get; set; }

        [ImportingConstructor]
        public BaseRepository(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }
        #endregion
    }
}
