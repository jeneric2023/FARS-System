using FirearmManagement.APIs.Dtos;
using FirearmManagement.Infrastructure.Models;

namespace FirearmManagement.APIs.Extensions;

public static class NotificationsExtensions
{
    public static Notification ToDto(this NotificationDbModel model)
    {
        return new Notification
        {
            CreatedAt = model.CreatedAt,
            Id = model.Id,
            UpdatedAt = model.UpdatedAt,
        };
    }

    public static NotificationDbModel ToModel(
        this NotificationUpdateInput updateDto,
        NotificationWhereUniqueInput uniqueId
    )
    {
        var notification = new NotificationDbModel { Id = uniqueId.Id };

        if (updateDto.CreatedAt != null)
        {
            notification.CreatedAt = updateDto.CreatedAt.Value;
        }
        if (updateDto.UpdatedAt != null)
        {
            notification.UpdatedAt = updateDto.UpdatedAt.Value;
        }

        return notification;
    }
}
