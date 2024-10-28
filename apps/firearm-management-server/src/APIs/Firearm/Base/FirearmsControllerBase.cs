using FirearmManagement.APIs;
using FirearmManagement.APIs.Common;
using FirearmManagement.APIs.Dtos;
using FirearmManagement.APIs.Errors;
using Microsoft.AspNetCore.Mvc;

namespace FirearmManagement.APIs;

[Route("api/[controller]")]
[ApiController()]
public abstract class FirearmsControllerBase : ControllerBase
{
    protected readonly IFirearmsService _service;

    public FirearmsControllerBase(IFirearmsService service)
    {
        _service = service;
    }

    /// <summary>
    /// Create one Firearm
    /// </summary>
    [HttpPost()]
    public async Task<ActionResult<Firearm>> CreateFirearm(FirearmCreateInput input)
    {
        var firearm = await _service.CreateFirearm(input);

        return CreatedAtAction(nameof(Firearm), new { id = firearm.Id }, firearm);
    }

    /// <summary>
    /// Delete one Firearm
    /// </summary>
    [HttpDelete("{Id}")]
    public async Task<ActionResult> DeleteFirearm([FromRoute()] FirearmWhereUniqueInput uniqueId)
    {
        try
        {
            await _service.DeleteFirearm(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Find many Firearms
    /// </summary>
    [HttpGet()]
    public async Task<ActionResult<List<Firearm>>> Firearms(
        [FromQuery()] FirearmFindManyArgs filter
    )
    {
        return Ok(await _service.Firearms(filter));
    }

    /// <summary>
    /// Meta data about Firearm records
    /// </summary>
    [HttpPost("meta")]
    public async Task<ActionResult<MetadataDto>> FirearmsMeta(
        [FromQuery()] FirearmFindManyArgs filter
    )
    {
        return Ok(await _service.FirearmsMeta(filter));
    }

    /// <summary>
    /// Get one Firearm
    /// </summary>
    [HttpGet("{Id}")]
    public async Task<ActionResult<Firearm>> Firearm([FromRoute()] FirearmWhereUniqueInput uniqueId)
    {
        try
        {
            return await _service.Firearm(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Update one Firearm
    /// </summary>
    [HttpPatch("{Id}")]
    public async Task<ActionResult> UpdateFirearm(
        [FromRoute()] FirearmWhereUniqueInput uniqueId,
        [FromQuery()] FirearmUpdateInput firearmUpdateDto
    )
    {
        try
        {
            await _service.UpdateFirearm(uniqueId, firearmUpdateDto);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }
}
