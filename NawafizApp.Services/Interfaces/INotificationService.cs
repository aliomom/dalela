using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NawafizApp.Services.Dtos;

namespace NawafizApp.Services.Interfaces
{
   public interface INotificationService
    {
        int AddFavourite(FavouriteDto dto);
        bool Edit(FavouriteDto dto);
        List<FavouriteDto> getAllfavourite();
        FavouriteDto GetById(int id);
        bool deletefavourite(int id);
        List<NotificationDto> getAllUsersNotification();
        int createfavouritNotification(NotificationDto dt, List<int> ids);
        int createfollowerNotification(NotificationDto dt, List<int> ids);
        int createAllNotification(NotificationDto dt);
    }
}
