using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using NHibernate.Linq;

namespace vbgCMS.Infrastructure.NHibernate
{
    public class AbstractQuery<T>
    {
        IQueryable<T> _queryable;

        public AbstractQuery(ISession session)
        {
            _queryable = session.Linq<T>();
        }
    }
}
