using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using vbgCMS.Infrastructure.CMS;
using vbgCMS.Infrastructure.CMS.Interfaces;
using vbgCMS.Infrastructure.NHibernate;

namespace vbgCMS.Data
{
   public class PageRepository : AbstractRepository<Page,long> , IPageRepository
   {
       public PageRepository(ISession session) : base(session)
       {
       }
   }
}
