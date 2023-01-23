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
        public int sequence = 0;
        public LinqToSqlSQLContext dbContext { get; set; }
        public virtual string FileName { 
            get {
                return this.GetType().FullName;
            } 
        }

        public QBase(LinqToSqlSQLContext dbContext = null)
        {
            this.dbContext = dbContext ?? new LinqToSqlSQLContext();
        }

        public virtual void Out<T>(IEnumerable<T> items)
        {
            Console.WriteLine($"FileName {FileName} Exemple <<{++sequence}>> :");
            foreach (var item in items)
            {
                Console.WriteLine(item);
            }
        }

        public virtual void Out(IEnumerable<int> items)
        {
            Console.WriteLine($"FileName {FileName} Exemple <<{++sequence}>> :");
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
            Console.WriteLine($"FileName {FileName} SQL LOG FOR <<{sequence}>> :");
            dbContext  = dbContext ??  new LinqToSqlSQLContext();
        }

    }
}
