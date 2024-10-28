using FirearmManagement.APIs;
using FirearmManagement.APIs.Common;
using FirearmManagement.APIs.Dtos;
using FirearmManagement.APIs.Errors;
using FirearmManagement.APIs.Extensions;
using FirearmManagement.Infrastructure;
using FirearmManagement.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace FirearmManagement.APIs;

public abstract class FirearmsServiceBase : IFirearmsService
{
    protected readonly FirearmManagementDbContext _context;

    public FirearmsServiceBase(FirearmManagementDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Create one Firearm
    /// </summary>
    public async Task<Firearm> CreateFirearm(FirearmCreateInput createDto)
    {
        var firearm = new FirearmDbModel
        {
            CreatedAt = createDto.CreatedAt,
            UpdatedAt = createDto.UpdatedAt
        };

        if (createDto.Id != null)
        {
            firearm.Id = createDto.Id;
        }

        _context.Firearms.Add(firearm);
        await _context.SaveChangesAsync();

        var result = await _context.FindAsync<FirearmDbModel>(firearm.Id);

        if (result == null)
        {
            throw new NotFoundException();
        }

        return result.ToDto();
    }

    /// <summary>
    /// Delete one Firearm
    /// </summary>
    public async Task DeleteFirearm(FirearmWhereUniqueInput uniqueId)
    {
        var firearm = await _context.Firearms.FindAsync(uniqueId.Id);
        if (firearm == null)
        {
            throw new NotFoundException();
        }

        _context.Firearms.Remove(firearm);
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Find many Firearms
    /// </summary>
    public async Task<List<Firearm>> Firearms(FirearmFindManyArgs findManyArgs)
    {
        var firearms = await _context
            .Firearms.ApplyWhere(findManyArgs.Where)
            .ApplySkip(findManyArgs.Skip)
            .ApplyTake(findManyArgs.Take)
            .ApplyOrderBy(findManyArgs.SortBy)
            .ToListAsync();
        return firearms.ConvertAll(firearm => firearm.ToDto());
    }

    /// <summary>
    /// Meta data about Firearm records
    /// </summary>
    public async Task<MetadataDto> FirearmsMeta(FirearmFindManyArgs findManyArgs)
    {
        var count = await _context.Firearms.ApplyWhere(findManyArgs.Where).CountAsync();

        return new MetadataDto { Count = count };
    }

    /// <summary>
    /// Get one Firearm
    /// </summary>
    public async Task<Firearm> Firearm(FirearmWhereUniqueInput uniqueId)
    {
        var firearms = await this.Firearms(
            new FirearmFindManyArgs { Where = new FirearmWhereInput { Id = uniqueId.Id } }
        );
        var firearm = firearms.FirstOrDefault();
        if (firearm == null)
        {
            throw new NotFoundException();
        }

        return firearm;
    }

    /// <summary>
    /// Update one Firearm
    /// </summary>
    public async Task UpdateFirearm(FirearmWhereUniqueInput uniqueId, FirearmUpdateInput updateDto)
    {
        var firearm = updateDto.ToModel(uniqueId);

        _context.Entry(firearm).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.Firearms.Any(e => e.Id == firearm.Id))
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
