using LinqToSql.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqToSql.Queries
{
    public class A
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        public override string ToString()
        {
            return $"Id = {Id} Name = {Name}";
        }
    }

    public class Q1 : QBase
    {
        public Q1() : base(null) { }

        public List<A> items = new List<A>();

        public override void Seed()
        {
            items.AddRange(new List<A> {
                new A { Id = 1, Name = "Vlad", Email = "a@gmail.com" },
                new A { Id = 2, Name = "Vlad", Email = "a@gmail.com" },
                new A { Id = 3, Name = "Vlad", Email = "1a@gmail.com"},
                new A { Id = 4, Name = "Banzo", Email = "b@gmail.com"},
                new A { Id = 5, Name = "Banzo", Email ="b@gmail.com" }
            });
        }

        public void QToObjects()
        {
            base.QToObjects();
            Out(items.Distinct(new DistinctItemComparer()).ToList());

            var duplicate = items.GroupBy(g => new { g.Name, g.Email }).Select(grp => new { Name = grp.Key.Name, Email = grp.Key.Email, Id = grp.Max(x => x.Id) }).ToList();
            
            items.RemoveAll(x => duplicate.Where(z => z.Id != x.Id && z.Name == z.Name && z.Email == x.Email).Count() == 1);

            Out(items);
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
