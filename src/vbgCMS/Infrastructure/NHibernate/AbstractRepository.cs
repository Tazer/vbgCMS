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
        protected readonly ISession Session;
        protected readonly IQueryable<T> Queryable;

        public AbstractRepository(ISession session)
        {
            Session = session;
            Queryable = session.Linq<T>();
        }

        public void Save(T obj)
        {
            Session.SaveOrUpdate(obj);
        }

        public ICollection<T> Get()
        {
            return Queryable.ToList();
        }

        public T Get(IdT id)
        {
            return Session.Get<T>(id);
        }

        public T Load(IdT id)
        {
            return Session.Load<T>(id);
        }

        public void Delete(T obj)
        {
            throw new NotImplementedException();
        }
    }
}
