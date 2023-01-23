using LinqToSql.Queries.ObjectModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqToSql.Queries
{
    public class Q2Join : QBase
    {
        public List<A> items = Models.items;
        public List<B> items2 = Models.items2;  

        public Q2Join() { }

        public override void QToObjects()
        {
            var q = from T in items
                    join T1 in items2
                    on T.Id equals T1.Id
                    select T1;

            Out(q.ToList());

            IEnumerable<A> q1 = items.Join(items2, key1 => key1.Id, key2 => key2.Id, (item1, item2) => new A { Id = item1.Id, Email = item1.Email, Name = item1.Name });
            Out(q1);

            var q2 = from p in items
                     join add in items2 on p.Id equals add.Id into gj
                     from x in gj.DefaultIfEmpty()
                     select new A { Id = p.Id, Name = p.Name, Email = p.Name, B = x };
            Out(q2);

            var q3 = (from p in items
                      join add in items2 on p.Id equals add.Id into gj
                      from x in gj.DefaultIfEmpty()
                      select new A { Id = p.Id, Name = p.Name, Email = p.Email, B = x }).ToList()
                     .GroupBy(a => new { a.B?.Address, a.B?.City })
                     .Select(grp => grp.Count());
            Out(q3);

            var q4 = from p in items
                     from add in items2
                     select new
                     {
                         Name = p.Name,
                         City = add?.City,
                         Total = items.Count() * items2.Count()
                     };
            Out(q4);

            var q5 = items.GroupJoin(items2, it => it.Id, it2 => it2.Id, (it, it2) =>
            new {
                Persons = it,
                Addresses = it2.Count()
            });

            Out(q5);
        }
    }
}
