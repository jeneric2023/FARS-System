using FirearmManagement.Infrastructure;

namespace FirearmManagement.APIs;

public class NotificationsService : NotificationsServiceBase
{
    public NotificationsService(FirearmManagementDbContext context)
        : base(context) { }
}
