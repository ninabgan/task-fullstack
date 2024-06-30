using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Data.DBWrapper
{
    public class DBWrapper : IDBWrapper
    {
        private readonly UserDbContext _userDbContext;

        public DBWrapper(UserDbContext userDbContext)
        {
            _userDbContext = userDbContext ?? throw new ArgumentNullException(nameof(userDbContext));
        }


        // User object methods
        public User CreateUser(User user)
        {
            _userDbContext.Users.Add(user);
            var saveChanges = _userDbContext.SaveChanges();

            if (saveChanges <= 0)
            {
                throw new ArgumentException("Failed while creating record");
            }

            return user;
        }


        public DeleteUserResponse DeleteUser(int id)
        {
            var user = _userDbContext.Users.Where(x => x.Id == id).FirstOrDefault();
            if(user != null)
            {
                _userDbContext.Users.Remove(user);
            }

            if(_userDbContext.SaveChanges() > 0)
            {
                return new DeleteUserResponse
                {
                    Status = 200,
                    Succeeded = true
                };
            } else
            {
                return new DeleteUserResponse
                {
                    Status = 400,
                    Succeeded = false,
                    StatusMessage = "The record does not exist in database"
                };
            }
        }


        public List<User> GetUsers()
        {
            var userList = _userDbContext.Users.ToList();
            return userList;
        }

        public User UpdateUser(User user)
        {
            _userDbContext.Users.Update(user);
            var saveChanges = _userDbContext.SaveChanges();

            if (saveChanges <= 0)
            {
                throw new ArgumentException("Failed while updating database");
            }

            return user;
        }


        // UserRole object methods


        public List<UserRole> GetUserRoles()
        {
            var userRoleList = _userDbContext.UserRoles.ToList();
            return userRoleList;
        }

        public UserRole CreateUserRole(UserRole userRole)
        {
            _userDbContext.UserRoles.Add(userRole);
            var saveChanges = _userDbContext.SaveChanges();

            if (saveChanges <= 0)
            {
                throw new ArgumentException("Failed while creating record");
            }

            return userRole;
        }


        public UserRole UpdateUserRole(UserRole userRole)
        {
            _userDbContext.UserRoles.Update(userRole);
            var saveChanges = _userDbContext.SaveChanges();

            if (saveChanges <= 0)
            {
                throw new ArgumentException("Failed while updating database");
            }

            return userRole;
        }

        public User GetUser(int id)
        {
            var user = _userDbContext.Users.Where(x => x.Id == id).FirstOrDefault();
            if (user == null)
            {
                throw new ArgumentException("Record not found");
            }
            return user;
        }

        // Unit object

        public List<Unit> GetUnits()
        {
            var unitList = _userDbContext.Units.ToList();
            return unitList;
        }


        // Role object

        public List<Role> GetRoles()
        {
            var roleList = _userDbContext.Roles.ToList();
            return roleList;
        }
    }

    public class DeleteUserResponse
    {
        public int Status { get; set; }
        public string StatusMessage { get; set; }
        public bool Succeeded { get; set; }
    }
}
