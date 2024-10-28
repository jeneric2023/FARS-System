using FirearmManagement.APIs.Dtos;
using FirearmManagement.Infrastructure.Models;

namespace FirearmManagement.APIs.Extensions;

public static class ServiceRequestsExtensions
{
    public static ServiceRequest ToDto(this ServiceRequestDbModel model)
    {
        return new ServiceRequest
        {
            CreatedAt = model.CreatedAt,
            Id = model.Id,
            UpdatedAt = model.UpdatedAt,
        };
    }

    public static ServiceRequestDbModel ToModel(
        this ServiceRequestUpdateInput updateDto,
        ServiceRequestWhereUniqueInput uniqueId
    )
    {
        var serviceRequest = new ServiceRequestDbModel { Id = uniqueId.Id };

        if (updateDto.CreatedAt != null)
        {
            serviceRequest.CreatedAt = updateDto.CreatedAt.Value;
        }
        if (updateDto.UpdatedAt != null)
        {
            serviceRequest.UpdatedAt = updateDto.UpdatedAt.Value;
        }

        return serviceRequest;
    }
}
