using FirearmManagement.APIs;
using FirearmManagement.APIs.Common;
using FirearmManagement.APIs.Dtos;
using FirearmManagement.APIs.Errors;
using Microsoft.AspNetCore.Mvc;

namespace FirearmManagement.APIs;

[Route("api/[controller]")]
[ApiController()]
public abstract class ServiceRequestsControllerBase : ControllerBase
{
    protected readonly IServiceRequestsService _service;

    public ServiceRequestsControllerBase(IServiceRequestsService service)
    {
        _service = service;
    }

    /// <summary>
    /// Create one ServiceRequest
    /// </summary>
    [HttpPost()]
    public async Task<ActionResult<ServiceRequest>> CreateServiceRequest(
        ServiceRequestCreateInput input
    )
    {
        var serviceRequest = await _service.CreateServiceRequest(input);

        return CreatedAtAction(
            nameof(ServiceRequest),
            new { id = serviceRequest.Id },
            serviceRequest
        );
    }

    /// <summary>
    /// Delete one ServiceRequest
    /// </summary>
    [HttpDelete("{Id}")]
    public async Task<ActionResult> DeleteServiceRequest(
        [FromRoute()] ServiceRequestWhereUniqueInput uniqueId
    )
    {
        try
        {
            await _service.DeleteServiceRequest(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Find many ServiceRequests
    /// </summary>
    [HttpGet()]
    public async Task<ActionResult<List<ServiceRequest>>> ServiceRequests(
        [FromQuery()] ServiceRequestFindManyArgs filter
    )
    {
        return Ok(await _service.ServiceRequests(filter));
    }

    /// <summary>
    /// Meta data about ServiceRequest records
    /// </summary>
    [HttpPost("meta")]
    public async Task<ActionResult<MetadataDto>> ServiceRequestsMeta(
        [FromQuery()] ServiceRequestFindManyArgs filter
    )
    {
        return Ok(await _service.ServiceRequestsMeta(filter));
    }

    /// <summary>
    /// Get one ServiceRequest
    /// </summary>
    [HttpGet("{Id}")]
    public async Task<ActionResult<ServiceRequest>> ServiceRequest(
        [FromRoute()] ServiceRequestWhereUniqueInput uniqueId
    )
    {
        try
        {
            return await _service.ServiceRequest(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Update one ServiceRequest
    /// </summary>
    [HttpPatch("{Id}")]
    public async Task<ActionResult> UpdateServiceRequest(
        [FromRoute()] ServiceRequestWhereUniqueInput uniqueId,
        [FromQuery()] ServiceRequestUpdateInput serviceRequestUpdateDto
    )
    {
        try
        {
            await _service.UpdateServiceRequest(uniqueId, serviceRequestUpdateDto);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }
}
