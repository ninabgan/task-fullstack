using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class User
    {
        public int Id { get; set; }
        public int? Version { get; set; }
        public string? Name { get; set; }
        public ICollection<UserRole>? UserRoles { get; set; }
    }
}
