using Data.Entities;
using Infrastructure.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Infrastructure.Contexts;

public class ApiContext(DbContextOptions<ApiContext> options) : IdentityDbContext<ApplicationUser>(options)
{
    public DbSet<AddressEntity> Addresses { get; set; }

    public DbSet<SubscribersEntity> Subscribers { get; set; }
}
