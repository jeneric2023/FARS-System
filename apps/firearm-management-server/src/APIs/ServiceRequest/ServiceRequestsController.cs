using Microsoft.AspNetCore.Mvc;

namespace FirearmManagement.APIs;

[ApiController()]
public class ServiceRequestsController : ServiceRequestsControllerBase
{
    public ServiceRequestsController(IServiceRequestsService service)
        : base(service) { }
}
