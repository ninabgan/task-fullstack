using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Data.DBWrapper
{
    public interface IDBWrapper
    {
        // User
        List<User> GetUsers();
        User GetUser(int id);
        User CreateUser(User user);
        DeleteUserResponse DeleteUser(int id);
        User UpdateUser(User user);


        // Unit
        List<Unit> GetUnits();

        // ROle
        List<Role> GetRoles();

        // User Role
        List<UserRole> GetUserRoles();
        UserRole CreateUserRole(UserRole userRole);
        UserRole UpdateUserRole(UserRole userRole);
    }
}
