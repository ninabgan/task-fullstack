using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class UserRole
    {
        public int Id { get; set; }
        public int? Version { get; set; }
        public int UserId { get; set; }
        public User? User { get; set; }
        public int? UnitId { get; set; }
        public Unit? Unit { get; set; }
        public int? RoleId { get; set; }
        public Role? Role { get; set; }
        public DateTime? ValidFrom { get; set; }
        public DateTime? ValidTo { get; set; }
    }
}
