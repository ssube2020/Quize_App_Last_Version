using System;
using Quize_App.Models.Users;

namespace Quize_App.Contracts
{
    public interface IUserService
    {
        /// <summary>
        /// Gets all the users
        /// </summary>
        /// <returns>List of users</returns>
        
        Task<List<UserResponse>> GetList();
        Task<UserResponse> GetById(string Id);
        Task<UserResponse> Update(UserUpdateRequest request);
        Task<bool> Delete(string Id);
    }
}

