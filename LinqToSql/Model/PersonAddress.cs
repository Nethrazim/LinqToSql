using System;
using System.Collections.Generic;

namespace LinqToSql.Model
{
    public partial class PersonAddress
    {
        public int PersonAddressId { get; set; }
        public string? Address { get; set; }
        public string? City { get; set; }

        public virtual Person PersonAddressNavigation { get; set; } = null!;
    }
}
