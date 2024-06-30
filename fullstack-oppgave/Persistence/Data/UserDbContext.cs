using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Data
{
    public class UserDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Unit> Units { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<Role> Roles { get; set; }

        public UserDbContext(DbContextOptions<UserDbContext> options) : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<User>().HasData(new List<User>
            {
                new User
                {
                    Id = 1,
                    Version = 1,
                    Name = "Alice"
                },
                new User
                {
                    Id = 2,
                    Version = 2,
                    Name = "Bob"
                },
                new User
                {
                    Id = 3,
                    Version = 1,
                    Name = "Eve"
                }
            });

            builder.Entity<Unit>().HasData(new List<Unit>
            {
                new Unit
                {Id = 11, Version = 2, Name = "Kreftregisteret"},
                new Unit
                {Id = 12, Version = 1, Name = "Akershus universitetssykehus HF"},
                new Unit
                {Id = 13, Version = 2, Name = "Sørlandet sykehus HF"},
                new Unit
                {Id = 14, Version = 1, Name = "Vestre Viken HF"}
            });


            builder.Entity<Role>().HasData(new List<Role>
            {
                new Role
                {Id = 101, Version = 1, Name = "User administration"},
                new Role
                {Id = 102, Version = 2, Name = "Endoscopist administration"},
                new Role
                {Id = 103, Version = 1, Name = "Report colonoscopy capacity"},
                new Role
                {Id = 104, Version = 2, Name = "Send invitations"},
                new Role
                {Id = 105, Version = 1, Name = "View statistics"},
            });

            builder.Entity<UserRole>().HasData(new List<UserRole>
            {
                new UserRole { 
                    Id = 1001, Version = 1, UserId = 1, UnitId = 11, RoleId = 101, ValidFrom = DateTime.Parse("2019-01-02 00:00:00"), ValidTo = DateTime.Parse("2019-12-31 23:59:59") },

                new UserRole
                {
                    Id = 1002,
                    Version = 2,
                    UserId = 1,
                    UnitId = 11,
                    RoleId = 104,
                    ValidFrom = DateTime.Parse("2019-01-02"),
                    ValidTo = DateTime.Parse("2019-12-31 23:59:59")
                },
                new UserRole
                {
                    Id = 1003,
                    Version = 1,
                    UserId = 1,
                    UnitId = 11,
                    RoleId = 105,
                    ValidFrom = DateTime.Parse("2019-06-11 00:00:00"),
                    ValidTo = DateTime.Parse("2019-12-31 23:59:59")
                },
                new UserRole
                {
                    Id = 1004,
                    Version = 2,
                    UserId = 2,
                    UnitId = 12,
                    RoleId = 101,
                    ValidFrom = DateTime.Parse("2020-01-28 00:00:00"),
                    ValidTo = null
                }

                //{ Id = 1005, Version = 1, UserId = 2, UnitId = 12, RoleId = 105, ValidFrom = "2020-01-28", ValidTo = null },
                //{ Id = 1006, Version = 1, UserId = 2, UnitId = 14, RoleId = 101, ValidFrom = "2020-01-28", ValidTo = null },
                //{ Id = 1007, Version = 1, UserId = 2, UnitId = 14, RoleId = 102, ValidFrom = "2020-01-28", ValidTo = null },
                //{ Id = 1008, Version = 1, UserId = 1, UnitId = 11, RoleId = 101, ValidFrom = "2020-02-01 07:00:00", ValidTo = null },
                //{ Id = 1009, Version = 1, UserId = 1, UnitId = 11, RoleId = 104, ValidFrom = "2020-02-01", ValidTo = null }
            });
        }
    }
}