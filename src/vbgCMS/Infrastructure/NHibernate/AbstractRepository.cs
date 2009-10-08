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
            _session.Save(obj);
        }

        public ICollection<T> Get()
        {
            return _queryable.ToList();
        }

        public T Get(IdT id)
        {
            return _session.Get<T>(id);
        }

        public T Load(IdT id)
        {
            return _session.Load<T>(id);
        }

        public void Delete(T obj)
        {
            throw new NotImplementedException();
        }
    }
}
