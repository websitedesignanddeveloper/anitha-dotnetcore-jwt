using System;
using System.Collections.Generic;

#nullable disable

namespace WebAppJwt.Models
{
    public partial class Organization
    {
        public int OrganizationId { get; set; }
        public string OrganizationName { get; set; }
        public string Membership { get; set; }
    }
}
