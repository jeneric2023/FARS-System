using Microsoft.AspNetCore.Mvc;

namespace FirearmManagement.APIs;

[ApiController()]
public class NotificationsController : NotificationsControllerBase
{
    public NotificationsController(INotificationsService service)
        : base(service) { }
}
