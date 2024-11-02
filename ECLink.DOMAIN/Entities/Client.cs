using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECLink.DOMAIN.Entities
{
    public class Client : BaseEntity<int>
    {
        public required string Name { get; set; }
    }
}