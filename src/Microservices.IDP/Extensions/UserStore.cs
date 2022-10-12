using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microservices.IDP.Infrastructure.Entities;
using Microservices.IDP.Persistence;
using Microservices.IDP.Infrastructure.Persistence;

namespace Microservices.IDP.Extensions;

public class UserStore : UserStore<User, IdentityRole, MSIdentityContext>
{
    public UserStore(MSIdentityContext context, IdentityErrorDescriber describer = null)
        : base(context, describer)
    {
    }

    // override GetRolesAsync return role ids
    public override async Task<IList<string>> GetRolesAsync(User user, CancellationToken cancellationToken = new CancellationToken())
    {
        var query = from userRole in Context.UserRoles
                    join role in Context.Roles on userRole.RoleId equals role.Id
                    where userRole.UserId.Equals(user.Id)
                    select role.Id; // select role Id
        return await query.ToListAsync(cancellationToken);
    }
}