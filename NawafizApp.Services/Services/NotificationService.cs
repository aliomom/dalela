using NawafizApp.Domain;
using NawafizApp.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NawafizApp.Services.Dtos;
using NawafizApp.Domain.Entities;
using AutoMapper;
using NawafizApp.Common;

namespace NawafizApp.Services.Services
{
   public class NotificationService:INotificationService
    {


        private readonly IUnitOfWork _unitOfWork;
        public NotificationService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }

        public int AddFavourite(FavouriteDto dto)
        {
            Favourite f = new Favourite();
            f.ArabicName = dto.ArabicName;
            f.EngName = dto.EngName;
            f.FrenchName = dto.FrenchName;
            f.PersianName = dto.PersianName;
            f.RussName = dto.RussName;
            f.Users.Add(_unitOfWork.UserRepository.FindById(dto.userid));
            if (dto.subCatIds.Count > 0)
            {
                foreach (int i in dto.subCatIds)
                {
                    f.SubCategoryDals.Add(_unitOfWork.SubCategoryDalRepository.FindById(i));
                }
            }
            _unitOfWork.FavouriteRepository.Add(f);
            _unitOfWork.SaveChanges();
            return f.Id;
        }

        public int createfavouritNotification(NotificationDto dt,List<int> ids)
        {
            foreach (var item3 in ids)
            {
                var list = _unitOfWork.FavouriteRepository.GetAll().Where(x => x.Id == item3);


                Notification n = new Notification();
                foreach (var item in list)
                {
                    if (item.Users != null)
                    {


                        foreach (User item1 in _unitOfWork.UserRepository.FindBy(x => x.Favourites.Where(y => y.Id == item.Id).Any()))
                        {
                            n.senderId = dt.senderId;
                            n.title = dt.title;
                            n.time = dt.time;
                            n.date = dt.date;
                            n.content = dt.content;
                            n.RevieverId = item1.UserId;
                          

                        }
                        _unitOfWork.NotificationRepository.Add(n);
                        n = new Notification();
                        _unitOfWork.SaveChanges();

                    }

                }
            }
                return 0;
           
        }
        public int createfollowerNotification(NotificationDto dt, List<int> ids)
        {
            foreach (var item3 in ids)
            {
               
               var list = _unitOfWork.FollowerRepository.FindBy(x=>x.ShopDals.Where(y=>y.Id==item3).Any());
                Notification n = new Notification();

                foreach (var item in list)
                {
                    if (item.User != null)
                    {
                        n.senderId = dt.senderId;
                        n.title = dt.title;
                        n.time = dt.time;
                        n.date = dt.date;
                        n.content = dt.content;
                        n.RevieverId = item.User.UserId;
                        _unitOfWork.NotificationRepository.Add(n);
                        n = new Notification();
                        _unitOfWork.SaveChanges();
                    }
                }
         
            }
            return 0;

        }
        public int createAllNotification(NotificationDto dt)
        {


            var list = _unitOfWork.UserRepository.GetAll().Where(x => x.Roles.Where(y => y.Name != "Admin").Any());
                Notification n = new Notification();

                foreach (var item in list)
                {
                   
                        n.senderId = dt.senderId;
                        n.title = dt.title;
                        n.time = dt.time;
                        n.date = dt.date;
                        n.content = dt.content;
                        n.RevieverId = item.UserId;
                        _unitOfWork.NotificationRepository.Add(n);
                        n = new Notification();
                        _unitOfWork.SaveChanges();
                    }
             

       
            return 0;

        }
        public bool deletefavourite(int id)
        {
            var n = _unitOfWork.FavouriteRepository.FindById(id);
            if (n == null)
            {
                return false;
            }
            _unitOfWork.FavouriteRepository.Remove(n);
            _unitOfWork.SaveChanges();
            return true;
        }

        public bool Edit(FavouriteDto dto)
        {
            var n = _unitOfWork.FavouriteRepository.FindById(dto.Id);
            var s = _unitOfWork.SubCategoryDalRepository.GetAll();
            n.Id = dto.Id;
            n.ArabicName = dto.ArabicName;
            n.EngName = dto.EngName;
            n.FrenchName = dto.FrenchName;
            n.PersianName = dto.PersianName;
            n.RussName = dto.RussName;
           // if (dto.subCatIds != null)
           // {
           //     foreach (SubCategoryDal Sub in _unitOfWork.SubCategoryDalRepository.FindBy(x => x.Favourites.Where(y => y.Id == n.Id).Any()))
           //     {
           //     n.SubCategoryDals.Remove(Sub);               
           //     }               
           //     if (dto.subCatIds.Count > 0)
           //     {
           //     foreach (int i in dto.subCatIds)
           //         {
           //n.SubCategoryDals = new List<SubCategoryDal>();
           //n.SubCategoryDals.Add(_unitOfWork.SubCategoryDalRepository.FindById(i));
           //         }
           //     }
            
           // }         
        _unitOfWork.FavouriteRepository.Update(n);
        _unitOfWork.SaveChanges();        
        return true;
        }

    
        public List<FavouriteDto> getAllfavourite()
        {
            List<Favourite> list = _unitOfWork.FavouriteRepository.GetAll();
            FavouriteDto fav = new FavouriteDto();
            List<FavouriteDto> dto = new List<FavouriteDto>();
           
            foreach (Favourite item in list)
            {
                fav.subCatIds = new List<int>();
                fav.subcatname = new List<string>();
                fav.Id = item.Id;           
                fav.ArabicName = item.ArabicName;
                fav.EngName = item.EngName;
                fav.FrenchName = item.FrenchName;
                fav.PersianName = item.PersianName;
                fav.RussName = item.RussName;
            
                if (item.SubCategoryDals.AsEnumerable()!=null)
                {
            
                    foreach (SubCategoryDal Sub in _unitOfWork.SubCategoryDalRepository.FindBy(x=>x.Favourites.Where(y=>y.Id==item.Id).Any()))
                    {
                        fav.subCatIds.Add(Sub.Id);
                        fav.subcatname.Add(Sub.ArabicName+"\n");
                    }
                }
               
                dto.Add(fav);
                fav = new FavouriteDto();
            }
            return dto; 
        }

        public FavouriteDto GetById(int id)
        {
            var list =_unitOfWork.FavouriteRepository.FindById(id);
            FavouriteDto fav = new FavouriteDto();
            fav.subCatIds = new List<int>();
            fav.subcatname = new List<string>();
            fav.Id = list.Id;
            fav.ArabicName = list.ArabicName;
            fav.EngName = list.EngName;
            fav.FrenchName = list.FrenchName;
            fav.PersianName = list.PersianName;
            fav.RussName = list.RussName;
            
            if (list.SubCategoryDals.AsEnumerable() != null)
            {

                foreach (SubCategoryDal Sub in _unitOfWork.SubCategoryDalRepository.FindBy(x => x.Favourites.Where(y => y.Id == list.Id).Any()))
                {
                    fav.subCatIds.Add(Sub.Id);
                    fav.subcatname.Add(Sub.ArabicName + "\n");
                }
            }

            return fav;
        }

        public List<NotificationDto> getAllUsersNotification()
        {
            var model = _unitOfWork.NotificationRepository.GetAll();
            NotificationDto dto = new NotificationDto();
            List<NotificationDto> list = new List<NotificationDto>();
            foreach (var item in model)
            {
                dto.title = item.title;
                dto.content = item.content;
                dto.date = item.date;
                dto.time = item.time;
                dto.strdate = DateTimeHelper.ConvertDateToString(item.date, DateFormats.DD_MM_YYYY);
                dto.strtime = DateTimeHelper.ConvertTimeToString(item.time, TimeFormats.HH_MM_AM);
                list.Add(dto);
                dto = new NotificationDto();
                
            }
            return list;
        }
    }
}
