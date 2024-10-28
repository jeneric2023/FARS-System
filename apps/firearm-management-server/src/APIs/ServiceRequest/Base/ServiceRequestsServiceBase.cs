using FirearmManagement.APIs;
using FirearmManagement.APIs.Common;
using FirearmManagement.APIs.Dtos;
using FirearmManagement.APIs.Errors;
using FirearmManagement.APIs.Extensions;
using FirearmManagement.Infrastructure;
using FirearmManagement.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace FirearmManagement.APIs;

public abstract class ServiceRequestsServiceBase : IServiceRequestsService
{
    protected readonly FirearmManagementDbContext _context;

    public ServiceRequestsServiceBase(FirearmManagementDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Create one ServiceRequest
    /// </summary>
    public async Task<ServiceRequest> CreateServiceRequest(ServiceRequestCreateInput createDto)
    {
        var serviceRequest = new ServiceRequestDbModel
        {
            CreatedAt = createDto.CreatedAt,
            UpdatedAt = createDto.UpdatedAt
        };

        if (createDto.Id != null)
        {
            serviceRequest.Id = createDto.Id;
        }

        _context.ServiceRequests.Add(serviceRequest);
        await _context.SaveChangesAsync();

        var result = await _context.FindAsync<ServiceRequestDbModel>(serviceRequest.Id);

        if (result == null)
        {
            throw new NotFoundException();
        }

        return result.ToDto();
    }

    /// <summary>
    /// Delete one ServiceRequest
    /// </summary>
    public async Task DeleteServiceRequest(ServiceRequestWhereUniqueInput uniqueId)
    {
        var serviceRequest = await _context.ServiceRequests.FindAsync(uniqueId.Id);
        if (serviceRequest == null)
        {
            throw new NotFoundException();
        }

        _context.ServiceRequests.Remove(serviceRequest);
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Find many ServiceRequests
    /// </summary>
    public async Task<List<ServiceRequest>> ServiceRequests(ServiceRequestFindManyArgs findManyArgs)
    {
        var serviceRequests = await _context
            .ServiceRequests.ApplyWhere(findManyArgs.Where)
            .ApplySkip(findManyArgs.Skip)
            .ApplyTake(findManyArgs.Take)
            .ApplyOrderBy(findManyArgs.SortBy)
            .ToListAsync();
        return serviceRequests.ConvertAll(serviceRequest => serviceRequest.ToDto());
    }

    /// <summary>
    /// Meta data about ServiceRequest records
    /// </summary>
    public async Task<MetadataDto> ServiceRequestsMeta(ServiceRequestFindManyArgs findManyArgs)
    {
        var count = await _context.ServiceRequests.ApplyWhere(findManyArgs.Where).CountAsync();

        return new MetadataDto { Count = count };
    }

    /// <summary>
    /// Get one ServiceRequest
    /// </summary>
    public async Task<ServiceRequest> ServiceRequest(ServiceRequestWhereUniqueInput uniqueId)
    {
        var serviceRequests = await this.ServiceRequests(
            new ServiceRequestFindManyArgs
            {
                Where = new ServiceRequestWhereInput { Id = uniqueId.Id }
            }
        );
        var serviceRequest = serviceRequests.FirstOrDefault();
        if (serviceRequest == null)
        {
            throw new NotFoundException();
        }

        return serviceRequest;
    }

    /// <summary>
    /// Update one ServiceRequest
    /// </summary>
    public async Task UpdateServiceRequest(
        ServiceRequestWhereUniqueInput uniqueId,
        ServiceRequestUpdateInput updateDto
    )
    {
        var serviceRequest = updateDto.ToModel(uniqueId);

        _context.Entry(serviceRequest).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.ServiceRequests.Any(e => e.Id == serviceRequest.Id))
            {
                throw new NotFoundException();
            }
            else
            {
                throw;
            }
        }
    }
}
