using System;
using System.Collections.Generic;

namespace LinqToSql.Model
{
    public partial class Address
    {
        public int Id { get; set; }
        public string? Address1 { get; set; }
        public string? City { get; set; }

        public virtual Person IdNavigation { get; set; } = null!;
    }
}
