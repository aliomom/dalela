using AutoMapper;
using NawafizApp.Domain;
using NawafizApp.Domain.Entities;
using NawafizApp.Services.Dtos;
using NawafizApp.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NawafizApp.Services.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        public UserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Guid Add(UserDto dto)
        {
            var model = Mapper.Map<UserDto, User>(dto);
            _unitOfWork.UserRepository.Add(model);
            _unitOfWork.SaveChanges();
            return model.UserId;
        }
        public bool Edit(UserDto dto)
        {

            User user = Mapper.Map<UserDto, User>(dto);
            if (user == null)
                return false;
            _unitOfWork.UserRepository.Update(user);
            _unitOfWork.SaveChanges();
            return true;
        }
        public void editForAdm(Guid id, string fullname, string userName)
        {
            var user = _unitOfWork.UserRepository.FindById(id);
            user.UserName = userName;
            user.FullName = fullname;
            _unitOfWork.UserRepository.Update(user);
            _unitOfWork.SaveChanges();
        }
        public bool EditUser(EditUserDto dto)
        {

            User user = _unitOfWork.UserRepository.FindById(dto.UserId);
            if (user == null)
                return false;
            user.UserName = dto.username;
            user.FullName = dto.FullName;
           
            if (dto.ShopId!=0)
            {
                user.ShopDals.Add(_unitOfWork.ShopDalRepository.FindById(dto.ShopId));
            }
         
            user.hasToken = false;
            if (dto.Customize==true)
            {
                
                user.Addbranches = dto.Addbranches;
                user.Addnotifications = dto.Addnotifications;
                user.AddCustomeNotifications = dto.AddCustomeNotifications;
                user.numOfBranches = dto.numOfBranches;
                user.NumberOfImagesAddedToranches = dto.NumberOfImagesAddedToranches;
               
                user.Numberofpictures = dto.Numberofpictures;
                if (dto.AddOffers != null)
                {
                    user.AddOffers = dto.AddOffers;
                }
            }
            if (dto.Customize == false)
            {
                user.Addbranches = null;
                user.Addnotifications = null;
                user.AddCustomeNotifications =null;
                user.numOfBranches =null;
                user.NumberOfImagesAddedToranches =null;

                user.Numberofpictures = null;
                if (dto.AddOffers != null)
                {
                    user.AddOffers = null;
                }
            }
          
            user.CreationDate = _unitOfWork.UserRepository.FindById(dto.UserId).CreationDate;
            _unitOfWork.UserRepository.Update(user);
            _unitOfWork.SaveChanges();
            return true;
        }
        public bool Delete(Guid id)
        {
            User user = _unitOfWork.UserRepository.FindById(id);
            if (user == null)
                return false;
            _unitOfWork.UserRepository.Remove(user);
            _unitOfWork.SaveChanges();
            return true;
        }
        public UserDto GetById(Guid id)
        {
            var model = _unitOfWork.UserRepository.FindById(id);
            return Mapper.Map<User, UserDto>(model);
        }
        public EditUserDto GetByIdforEdit(Guid id)
        {
            EditUserDto dto = new EditUserDto();
            var model = _unitOfWork.UserRepository.FindBy(x => x.UserId == id).SingleOrDefault();
          

            
            dto.FullName = model.FullName;
            dto.UserId = model.UserId;
            dto.username = model.UserName;
            if (_unitOfWork.ShopDalRepository.FindBy(x => x.UserId == dto.UserId).FirstOrDefault() != null)
                dto.ShopName = _unitOfWork.ShopDalRepository.FindBy(x => x.UserId == dto.UserId).FirstOrDefault().ArabicName;
            else
                dto.ShopName = "";
            dto.Role = model.Roles.FirstOrDefault().Name;
            if (model.Addbranches.HasValue || model.Addnotifications.HasValue ||
                   model.AddCustomeNotifications.HasValue ||
                   model.AddOffers.HasValue ||
                   model.NumberOfImagesAddedToranches.HasValue ||
                   model.Numberofpictures.HasValue ||
                   model.numOfBranches.HasValue)
            {
                dto.Customize = true;
                dto.Role = model.Roles.FirstOrDefault().Name /*+ "-مخصص"*/;
            }
            if (dto.Customize)
            {
                if (model.Addbranches.HasValue)
                    dto.AddbranchesGET = model.Addbranches;
                else
                    dto.AddbranchesGET = model.Roles.FirstOrDefault().Addbranches;
                if (model.AddCustomeNotifications.HasValue)
                    dto.AddCustomeNotificationsGEt = model.AddCustomeNotifications;
                else
                    dto.AddCustomeNotificationsGEt = model.Roles.FirstOrDefault().AddCustomeNotifications;
                if (model.Addnotifications.HasValue)
                    dto.AddnotificationsGET = model.Addnotifications;
                else
                    dto.AddnotificationsGET = model.Roles.FirstOrDefault().Addnotifications;
                if (model.AddOffers.HasValue)
                    dto.AddOffersGET = model.AddOffers;
                else
                    dto.AddOffersGET = model.Roles.FirstOrDefault().AddOffers;
                if (model.numOfBranches.HasValue)
                    dto.numOfBranches = model.numOfBranches;
                else
                    dto.numOfBranches = model.Roles.FirstOrDefault().numOfBranches;
                if (model.Numberofpictures.HasValue)
                    dto.Numberofpictures = model.Numberofpictures;
                else
                    dto.Numberofpictures = model.Roles.FirstOrDefault().Numberofpictures;
                if (model.NumberOfImagesAddedToranches.HasValue)
                    dto.NumberOfImagesAddedToranches = model.NumberOfImagesAddedToranches;
                else
                    dto.NumberOfImagesAddedToranches = model.Roles.FirstOrDefault().NumberOfImagesAddedToranches;
            }
            else
            {
                dto.AddCustomeNotificationsGEt = model.Roles.FirstOrDefault().AddCustomeNotifications;

                dto.AddnotificationsGET = model.Roles.FirstOrDefault().Addnotifications;

                dto.AddOffersGET = model.Roles.FirstOrDefault().AddOffers;

                dto.numOfBranches = model.Roles.FirstOrDefault().numOfBranches;

                dto.AddbranchesGET = model.Roles.FirstOrDefault().Addbranches;
                dto.Numberofpictures = model.Roles.FirstOrDefault().Numberofpictures;

                dto.NumberOfImagesAddedToranches = model.Roles.FirstOrDefault().NumberOfImagesAddedToranches;
            }
        
           

            return dto;
        }

        public List<RegisterUserDto> GetAll()
        {
            var list = _unitOfWork.UserRepository.FindBy(x => x.Roles.Where(y => y.Name != "Admin").Any()).ToList();
            RegisterUserDto dto = new RegisterUserDto();
            List<RegisterUserDto> res = new List<RegisterUserDto>();
            foreach (var item in list)
            {
                dto.FullName = item.FullName;
                dto.UserId = item.UserId;
                dto.username = item.UserName;
                if (_unitOfWork.ShopDalRepository.FindBy(x => x.UserId == item.UserId).FirstOrDefault() != null)
                    dto.ShopName = _unitOfWork.ShopDalRepository.FindBy(x => x.UserId == item.UserId).FirstOrDefault().ArabicName;
                else
                    dto.ShopName = "";
                dto.Role = geArabicRole( item.Roles.FirstOrDefault().Name);
                if(item.Addbranches.HasValue || item.Addnotifications.HasValue ||
                    item.AddCustomeNotifications.HasValue ||
                    item.AddOffers.HasValue ||
                    item.NumberOfImagesAddedToranches.HasValue ||
                    item.Numberofpictures.HasValue ||
                    item.numOfBranches.HasValue)
                {
                    dto.Customize = true;
                    dto.Role = geArabicRole(item.Roles.FirstOrDefault().Name)+"-مخصص";
                }
                if (dto.Customize)
                {
                    if (item.Addbranches.HasValue)
                        dto.AddbranchesGET = item.Addbranches;
                    else
                        dto.AddbranchesGET = item.Roles.FirstOrDefault().Addbranches;
                    if (item.AddCustomeNotifications.HasValue)
                        dto.AddCustomeNotificationsGEt = item.AddCustomeNotifications;
                    else
                        dto.AddCustomeNotificationsGEt = item.Roles.FirstOrDefault().AddCustomeNotifications;
                    if (item.Addnotifications.HasValue)
                    dto.AddnotificationsGET = item.Addnotifications;
                    else 
                        dto.AddnotificationsGET = item.Roles.FirstOrDefault().Addnotifications;
                    if (item.AddOffers.HasValue)
                    dto.AddOffersGET = item.AddOffers;
                    else
                        dto.AddOffersGET = item.Roles.FirstOrDefault().AddOffers;
                    if(item.numOfBranches.HasValue)
                    dto.numOfBranches = item.numOfBranches;
                    else 
                        dto.numOfBranches = item.Roles.FirstOrDefault().numOfBranches;
                    if(item.Numberofpictures.HasValue)
                    dto.Numberofpictures = item.Numberofpictures;
                    else 
                        dto.Numberofpictures = item.Roles.FirstOrDefault().Numberofpictures;
                    if(item.NumberOfImagesAddedToranches.HasValue)
                    dto.NumberOfImagesAddedToranches = item.NumberOfImagesAddedToranches;
                    else
                        dto.NumberOfImagesAddedToranches = item.Roles.FirstOrDefault().NumberOfImagesAddedToranches;
                }
                else
                {
                    dto.AddCustomeNotificationsGEt = item.Roles.FirstOrDefault().AddCustomeNotifications;

                    dto.AddnotificationsGET = item.Roles.FirstOrDefault().Addnotifications;

                    dto.AddOffersGET = item.Roles.FirstOrDefault().AddOffers;

                    dto.numOfBranches = item.Roles.FirstOrDefault().numOfBranches;

                    dto.AddbranchesGET = item.Roles.FirstOrDefault().Addbranches;
                    dto.Numberofpictures = item.Roles.FirstOrDefault().Numberofpictures;

                    dto.NumberOfImagesAddedToranches = item.Roles.FirstOrDefault().NumberOfImagesAddedToranches;
                }
                res.Add(dto);
                dto = new RegisterUserDto();

            }
            return res;
        }
        public string geArabicRole(string role)
        {
            string result = "";
            switch (role)
            {
                case "normal":result = "عادي"; break;
                case "silver": result = "فضي"; break;
                case "gold": result = "ذهبي"; break;
                case "diamond": result = "الماسي"; break;
                case "blatin": result = "بلاتيني"; break;
                case "super": result = "سوبر"; break;
                case "vip": result = "VIP"; break;

                default:
                    break;
            }
            return result;
        }
        public string getoldrole(Guid userid) {

            var model = _unitOfWork.UserRepository.FindById(userid);
            string role = model.Roles.SingleOrDefault().Name;
            return role;
        }
        public string getrealrole(string role)
        {
            string result = "";
            switch (role)
            {
                case "عادي": result = "normal"; break;
                case "فضي": result = "silver"; break;
                case "ذهبي": result = "gold"; break;
                case "الماسي": result = "diamond"; break;
                case "بلاتيني": result = "blatin"; break;
                case "سوبر": result = "super"; break;
                case "VIP": result = "vip"; break;

                default:
                    break;
            }
            return result;
        }
        public bool HasRole(Guid id,String role)
        {
            return GetById(id).Role == role;
        }
        public bool Exists(Guid id)
        {
            return GetById(id) == null ? false : true;
        }


        public List<UserDto> GetUsersByRole(string role)
        {
            return null;
        }

        public bool IsEmailUnique(string email)
        {
            return _unitOfWork.UserRepository.FindByEmail(email.ToLower()) == null;
        }
    }
}
