using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqToSql.Queries.ObjectModels
{
    public static class Models
    {
        public static List<A> items = new List<A>();
        public static List<B> items2 = new List<B>();

        static Models() //static constructor
        { 
            PopulateData();
        }

        public static void RefreshData()
        {
            PopulateData();
        }

        private static void PopulateData()
        {
            items.Clear();
            items.AddRange(new List<A> {
                new A{ Id= 1, Name="Vlad", Email="a@gmail.com"},
                new A{ Id = 2, Name = "Vlad",Email ="a@gmail.com"},
                new A{ Id = 3, Name ="Vlad", Email = "1a@gmail.com"},
                new A{ Id = 4, Name = "Banzo",Email = "b@gmail.com"},
                new A{ Id = 5, Name="Banzo",Email = "b@gmail.com"},
                new A{ Id = 6, Name = "Petre", Email = "p@gmail.com"},
                new A{ Id = 7, Name = "Branzei Vlad", Email="vb@gmail.com"},

            });

            items2.Clear();
            items2.AddRange(new List<B>
            {
                new B { Id = 1, Address = "Vlad's street", City = "Vlad's City" },
                new B { Id = 2, Address = "Vlad's street", City = "Vlad's City" },
            });
        }
    }

    public class A
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public B B { get; set; }
        public override string ToString()
        {
            return $"Id = {Id} Name = {Name} Email = {Email} B = {{{ B }}}";
        }
    }

    public class B
    {
        public int Id { get; set; }
        public string Address { get; set; }
        public string City { get; set; }

        public override string ToString()
        {
            return $"Id = {Id} Address = {Address} City = {City}";
        }
    }

}
