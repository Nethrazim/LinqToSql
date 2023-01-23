using LinqToSql.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqToSql.Queries
{
    public class QBase
    {
        public LinqToSqlSQLContext dbContext { get; set; }
        public QBase(LinqToSqlSQLContext dbContext)
        {
            this.dbContext = dbContext ?? new LinqToSqlSQLContext();
            Seed();
        }

        public virtual void Out<T>(List<T> items)
        {
            foreach (var item in items)
            {
                Console.WriteLine(item);
            }
        }

        public virtual void Out(List<int> items)
        {
            foreach (var item in items)
            {
                Console.WriteLine(item);
            }
        }

        public virtual void Seed() { 

        }
        public virtual void QToObjects()
        {
        }

        public virtual void QToSql()
        {
        }

    }
}
