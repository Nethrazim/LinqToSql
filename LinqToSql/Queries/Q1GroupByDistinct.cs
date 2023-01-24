using LinqToSql.Model;
using LinqToSql.Queries.ObjectModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models = LinqToSql.Queries.ObjectModels.Models;

namespace LinqToSql.Queries
{

    public class Q1GroupByDistinct : QBase
    {
        public Q1GroupByDistinct() { }

        public List<A> items = Models.items;

        public void QToObjects()
        {
            base.QToObjects();
            Out(items.Distinct(new DistinctItemComparer()).ToList());

            var duplicate = items.GroupBy(g => new { g.Name, g.Email }).Select(grp => new { Name = grp.Key.Name, Email = grp.Key.Email, Id = grp.Max(x => x.Id) }).ToList();
            
            items.RemoveAll(x => duplicate.Where(z => z.Id != x.Id && z.Name == z.Name && z.Email == x.Email).Count() == 1);

            Models.RefreshData();

            Out(items);

            var groupedResult = from s in items
                                group s by s.Name;
            Out(groupedResult);
        }

        public void QToSql()
        {
            base.QToSql();

            Out(dbContext.Persons.GroupBy(key => new { key.Name, key.Email }).Select(grp => grp.FirstOrDefault()).ToList());

            var duplicate = items.GroupBy(g => new { g.Name, g.Email }).Select(grp => new { Name = grp.Key.Name, Email = grp.Key.Email, Id = grp.Max(x => x.Id) }).ToList();
        }

        public class DistinctItemComparer : EqualityComparer<A>
        {
            public override bool Equals(A x, A y)
            {
                return (x.Id != y.Id &&
                     x.Name == y.Name &&
                     x.Email == y.Email);
            }

            public override int GetHashCode(A obj)
            {
                return obj.Name.GetHashCode() ^ obj.Email.GetHashCode();
            }
        }
    }
}
