using InfrastructureMMO.Entities;
using InfrastructureMMO.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace InfrastructureMMO.Services
{
    public class UserService: IUserService
    {
        public UserService() { }

        public List<UserEntity> GetAll()
        {
            using var db = new DataContext();
            List<UserEntity> users = new List<UserEntity>();
            users = db.Users.OrderBy(b => b.Email).ToList();
            return users;
        }

        public List<UserEntity> GetByLastUpdatePwd()
        {
            using var db = new DataContext();
            List<UserEntity> users = new List<UserEntity>();
            users = db.Users.Where(b => DateTime.Now >= b.LastUpdatePwd.AddMonths(6)).ToList();
            return users;
        }

        public UserEntity GetByLastId(string id)
        {
            using var db = new DataContext();
            UserEntity user = new UserEntity();
            var userResponse = db.Users.Where(b => b.Id == id);
            if(userResponse.Count() == 0)
            {
                return userResponse.FirstOrDefault();
            }
            return null;
        }

        public async Task<UserEntity> CreateUser(UserEntity user)
        {
            using var db = new DataContext();
            UserEntity userEntity = new UserEntity 
            { 
                Id = Guid.NewGuid().ToString(), 
                Email = user.Email, 
                Status = user.Status, 
                LastUpdatePwd = DateTime.Now
            };
            db.Add(userEntity);
            await db.SaveChangesAsync();
            return userEntity;
        }
        public async Task<UserEntity> UpdateUser(string id, string email, string status, DateTime lastUpdatePwd)
        {
            using var db = new DataContext();
            var userResponse = db.Users.Where(b => b.Id == id);
            if(userResponse.Count() != 0)
            {
                var user = userResponse.FirstOrDefault();
                user.Email = email;
                user.Status = status;
                user.LastUpdatePwd = lastUpdatePwd;
                db.Update(user);
                await db.SaveChangesAsync();
                return user;
            }
            return null;
        }

        public async Task<UserEntity> Delete(string id)
        {
            using var db = new DataContext();
            var userResponse = db.Users.Where(b => b.Id == id);
            if (userResponse.Count() != 0)
            {
                var user = userResponse.FirstOrDefault();
                db.Users.Remove(user);
                await db.SaveChangesAsync();
                return user;
            }
            return null;
        }
    }
}
