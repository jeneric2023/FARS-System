using FirearmManagement.Infrastructure;

namespace FirearmManagement.APIs;

public class FirearmsService : FirearmsServiceBase
{
    public FirearmsService(FirearmManagementDbContext context)
        : base(context) { }
}
