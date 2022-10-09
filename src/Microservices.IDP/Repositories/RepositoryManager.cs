using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Storage;
using Microservices.IDP.Infrastructure.Domains;
using Microservices.IDP.Infrastructure.Entities;
using Microservices.IDP.Persistence;

namespace Microservices.IDP.Infrastructure.Repositories;

public class RepositoryManager : IRepositoryManager
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly MSIdentityContext _dbContext;
    private readonly Lazy<IPermissionRepository> _permissionRepository;
    private readonly IMapper _mapper;

    public RepositoryManager(MSIdentityContext dbContext, IUnitOfWork unitOfWork, UserManager<User> userManager,
        RoleManager<IdentityRole> roleManager, IMapper mapper)
    {
        _dbContext = dbContext;
        _unitOfWork = unitOfWork;
        UserManager = userManager;
        RoleManager = roleManager;
        _mapper = mapper;

        _permissionRepository = new Lazy<IPermissionRepository>(() =>
            new PermissionRepository(_dbContext, _unitOfWork, userManager, _mapper));
    }

    public UserManager<User> UserManager { get; }
    public RoleManager<IdentityRole> RoleManager { get; }
    public IPermissionRepository Permission => _permissionRepository.Value;

    public Task<int> SaveAsync()
        => _unitOfWork.CommitAsync();

    public Task<IDbContextTransaction> BeginTransactionAsync()
        => _dbContext.Database.BeginTransactionAsync();

    public Task EndTransactionAsync()
        => _dbContext.Database.CommitTransactionAsync();

    public void RollbackTransaction()
        => _dbContext.Database.RollbackTransactionAsync();
}