using FirearmManagement.Infrastructure;

namespace FirearmManagement.APIs;

public class ServiceRequestsService : ServiceRequestsServiceBase
{
    public ServiceRequestsService(FirearmManagementDbContext context)
        : base(context) { }
}
