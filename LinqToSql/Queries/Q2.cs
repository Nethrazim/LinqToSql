using LinqToSql.Queries.ObjectModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqToSql.Queries
{
    public class Q2 : QBase
    {
        public List<A> items = Models.items;
        public List<B> items2 = Models.items2;  

        public Q2() { }

        public override void QToObjects()
        {
            var q = from T in items
                    join T1 in items2
                    on T.Id equals T1.Id
                    select T1;

            Out(q.ToList());

            IEnumerable<A> q1 = items.Join(items2, key1 => key1.Id, key2 => key2.Id, (item1, item2) => new A { Id = item1.Id, Email = item1.Email, Name = item1.Name });
            Out(q1);
        }
    }
}
