using FirearmManagement.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace FirearmManagement.Infrastructure;

public class FirearmManagementDbContext : DbContext
{
    public FirearmManagementDbContext(DbContextOptions<FirearmManagementDbContext> options)
        : base(options) { }

    public DbSet<ServiceRequestDbModel> ServiceRequests { get; set; }

    public DbSet<FirearmDbModel> Firearms { get; set; }

    public DbSet<NotificationDbModel> Notifications { get; set; }

    public DbSet<UserDbModel> Users { get; set; }
}
