using FirearmManagement.APIs.Dtos;
using FirearmManagement.Infrastructure.Models;

namespace FirearmManagement.APIs.Extensions;

public static class FirearmsExtensions
{
    public static Firearm ToDto(this FirearmDbModel model)
    {
        return new Firearm
        {
            CreatedAt = model.CreatedAt,
            Id = model.Id,
            UpdatedAt = model.UpdatedAt,
        };
    }

    public static FirearmDbModel ToModel(
        this FirearmUpdateInput updateDto,
        FirearmWhereUniqueInput uniqueId
    )
    {
        var firearm = new FirearmDbModel { Id = uniqueId.Id };

        if (updateDto.CreatedAt != null)
        {
            firearm.CreatedAt = updateDto.CreatedAt.Value;
        }
        if (updateDto.UpdatedAt != null)
        {
            firearm.UpdatedAt = updateDto.UpdatedAt.Value;
        }

        return firearm;
    }
}
