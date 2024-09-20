using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InfrastructureMMO.Entities;

namespace InfrastructureMMO.Services.Interfaces
{
    public interface IUserService
    {
        List<UserEntity> GetAll();
        UserEntity GetByLastId(string id);
        List<UserEntity> GetByLastUpdatePwd();
        Task<UserEntity> CreateUser(UserEntity user);
        Task<UserEntity> UpdateUser(string id, string email, string status, DateTime lastUpdatePwd);
        Task<UserEntity> Delete(string id);
    }
}
