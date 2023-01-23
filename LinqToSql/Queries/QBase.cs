using LinqToSql.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqToSql.Queries
{
    public abstract class QBase
    {
        public LinqToSqlSQLContext dbContext { get; set; }
        public QBase(LinqToSqlSQLContext dbContext = null)
        {
            this.dbContext = dbContext ?? new LinqToSqlSQLContext();
        }

        public virtual void Out<T>(IEnumerable<T> items)
        {
            foreach (var item in items)
            {
                Console.WriteLine(item);
            }
        }

        public virtual void Out(IEnumerable<int> items)
        {
            foreach (var item in items)
            {
                Console.WriteLine(item);
            }
        }

        public virtual void QToObjects()
        {
        }

        public virtual void QToSql()
        {
            dbContext  = dbContext ??  new LinqToSqlSQLContext();
        }

    }
}
