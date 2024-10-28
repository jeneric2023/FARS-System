using FirearmManagement.APIs.Common;
using FirearmManagement.Infrastructure.Models;
using Microsoft.AspNetCore.Mvc;

namespace FirearmManagement.APIs.Dtos;

[BindProperties(SupportsGet = true)]
public class ServiceRequestFindManyArgs
    : FindManyInput<ServiceRequest, ServiceRequestWhereInput> { }
