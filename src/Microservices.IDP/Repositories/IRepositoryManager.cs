using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Storage;
using Microservices.IDP.Infrastructure.Entities;
using Microservices.IDP.Infrastructure.Repositories;

namespace Microservices.IDP.Infrastructure.Repositories;

public interface IRepositoryManager
{
    UserManager<User> UserManager { get; }
    RoleManager<IdentityRole> RoleManager { get; }
    IPermissionRepository Permission { get; }
    Task<int> SaveAsync();
    Task<IDbContextTransaction> BeginTransactionAsync();
    Task EndTransactionAsync();
    void RollbackTransaction();

}