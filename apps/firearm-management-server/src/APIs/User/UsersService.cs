using FirearmManagement.Infrastructure;

namespace FirearmManagement.APIs;

public class UsersService : UsersServiceBase
{
    public UsersService(FirearmManagementDbContext context)
        : base(context) { }
}
