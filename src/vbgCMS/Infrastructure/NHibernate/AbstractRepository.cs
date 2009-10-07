using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using NHibernate.Linq;

namespace vbgCMS.Infrastructure.NHibernate
{
    public abstract class AbstractRepository<T, IdT>
    {
        private readonly ISession _session;
        private readonly IQueryable<T> _queryable;

        public AbstractRepository(ISession session)
        {
            _session = session;
            _queryable = session.Linq<T>();
        }

        public void Save(T obj)
        {
            throw new NotImplementedException();
        }

        public IList<T> Get()
        {
            return _queryable.ToList();
        }

        public T Get(IdT id)
        {
            throw new NotImplementedException();
        }

        public T Load(IdT id)
        {
            throw new NotImplementedException();
        }

        public void Delete(T obj)
        {
            throw new NotImplementedException();
        }
    }
}
