using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using vbgCMS.Infrastructure.NHibernate.Interfaces;

namespace vbgCMS.Infrastructure.CMS.Interfaces
{
    public interface IPageRepository : IGet<Page>, ILoad<Page, long>, IGetById<Page, long>, ISave<Page>
    {

    }
}
