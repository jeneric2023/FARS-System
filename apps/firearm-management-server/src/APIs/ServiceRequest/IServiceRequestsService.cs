using FirearmManagement.APIs.Common;
using FirearmManagement.APIs.Dtos;

namespace FirearmManagement.APIs;

public interface IServiceRequestsService
{
    /// <summary>
    /// Create one ServiceRequest
    /// </summary>
    public Task<ServiceRequest> CreateServiceRequest(ServiceRequestCreateInput servicerequest);

    /// <summary>
    /// Delete one ServiceRequest
    /// </summary>
    public Task DeleteServiceRequest(ServiceRequestWhereUniqueInput uniqueId);

    /// <summary>
    /// Find many ServiceRequests
    /// </summary>
    public Task<List<ServiceRequest>> ServiceRequests(ServiceRequestFindManyArgs findManyArgs);

    /// <summary>
    /// Meta data about ServiceRequest records
    /// </summary>
    public Task<MetadataDto> ServiceRequestsMeta(ServiceRequestFindManyArgs findManyArgs);

    /// <summary>
    /// Get one ServiceRequest
    /// </summary>
    public Task<ServiceRequest> ServiceRequest(ServiceRequestWhereUniqueInput uniqueId);

    /// <summary>
    /// Update one ServiceRequest
    /// </summary>
    public Task UpdateServiceRequest(
        ServiceRequestWhereUniqueInput uniqueId,
        ServiceRequestUpdateInput updateDto
    );
}
