using Microsoft.AspNetCore.Mvc;

namespace FirearmManagement.APIs;

[ApiController()]
public class FirearmsController : FirearmsControllerBase
{
    public FirearmsController(IFirearmsService service)
        : base(service) { }
}
