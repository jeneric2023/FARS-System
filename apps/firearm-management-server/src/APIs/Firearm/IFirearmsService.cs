using FirearmManagement.APIs.Common;
using FirearmManagement.APIs.Dtos;

namespace FirearmManagement.APIs;

public interface IFirearmsService
{
    /// <summary>
    /// Create one Firearm
    /// </summary>
    public Task<Firearm> CreateFirearm(FirearmCreateInput firearm);

    /// <summary>
    /// Delete one Firearm
    /// </summary>
    public Task DeleteFirearm(FirearmWhereUniqueInput uniqueId);

    /// <summary>
    /// Find many Firearms
    /// </summary>
    public Task<List<Firearm>> Firearms(FirearmFindManyArgs findManyArgs);

    /// <summary>
    /// Meta data about Firearm records
    /// </summary>
    public Task<MetadataDto> FirearmsMeta(FirearmFindManyArgs findManyArgs);

    /// <summary>
    /// Get one Firearm
    /// </summary>
    public Task<Firearm> Firearm(FirearmWhereUniqueInput uniqueId);

    /// <summary>
    /// Update one Firearm
    /// </summary>
    public Task UpdateFirearm(FirearmWhereUniqueInput uniqueId, FirearmUpdateInput updateDto);
}
