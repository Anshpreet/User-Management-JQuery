
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserManagementJQuery.Models;

namespace UserManagementJQuery.Repository
{
    public class UserData
    {
        BookstoreManagementContext _Context;


       public UserData(BookstoreManagementContext bookstoreManagementContext)
        {
            _Context = bookstoreManagementContext;
        }


        public List<User> GetUsers() 
        {
            try
            {
                var users =  _Context.Users.ToList();
                return users;
            }
            catch (Exception ex)
            {
                throw new SqlException("server error occured!", ex);
            }
        }

        public async Task<bool> AddUser(User user)
        {

            try
            {

                int rows = 0;
                _Context.Add(user);
                rows = await _Context.SaveChangesAsync();
                if (rows == 0)
                {
                    return false;
                }
                else
                    return true;
            }
            catch (Exception ex)
            {
                throw new SqlException("server error occured!", ex);
            }
        }

        public async Task<bool> UpdateUser(User user)
        {
            User user1 = await _Context.Users.FirstOrDefaultAsync(s => s.UserId == user.UserId);
            try
            {
                int rows = 0;
                user1.UserName = user.UserName;
                user1.EmailId = user.EmailId;
                rows = await _Context.SaveChangesAsync();
                if (rows == 0)
                    return false;
                else
                    return true;
            }
            catch (Exception ex)
            {
                throw new SqlException("server error occured!", ex);
            }
        }

        public async Task<bool> DeleteUser(int id)
        {
            try
            {
                User user = await _Context.Users.FirstOrDefaultAsync(s => s.UserId == id);
                if (user != null)
                {
                    int rows = 0;
                    user.IsDeleted = true;
                    rows = await _Context.SaveChangesAsync();
                    if (rows == 0)
                        return false;
                    else
                        return true;
                }
                else
                    return false;
            }
            catch (Exception ex)
            {
                throw new SqlException("server error occured", ex);
            }
        }
    }
}
