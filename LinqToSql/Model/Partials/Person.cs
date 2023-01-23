using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqToSql.Model
{
    public partial class Person
    {
        public override string ToString()
        {
            return $"Id = {Id} Name = {Name} Email = {Email}";
        }
    }
}
