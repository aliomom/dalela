using NawafizApp.Domain;
using NawafizApp.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NawafizApp.Services.Dtos;
using NawafizApp.Domain.Entities;

namespace NawafizApp.Services.Services
{
 public   class FollowerService : IFollowerService
    {
        private readonly IUnitOfWork _unitOfWork;
        public FollowerService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }

        public List<FollowerDto> getAllFollowers()
        {
            List<Follower> list = _unitOfWork.FollowerRepository.GetAll();
            FollowerDto fav = new FollowerDto();
            List<FollowerDto> dto = new List<FollowerDto>();

            foreach (Follower item in list)
            {
                fav.shopdalids = new List<int>();
                fav.shopdalnames = new List<string>();
                fav.Id = item.Id;
                fav.UserId = item.User.UserId;
                fav.userName = item.User.FullName;
              

                if (item.ShopDals.AsEnumerable() != null)
                {

                    foreach (ShopDal Shop in _unitOfWork.ShopDalRepository.FindBy(x => x.Followers.Where(y => y.Id == item.Id).Any()))
                    {
                        fav.shopdalids.Add(Shop.Id);
                      
                        fav.shopdalnames.Add(Shop.ArabicName + "\n");
                    }
                }

                dto.Add(fav);
                fav = new FollowerDto();
            }
            return dto;
        }
    }
}
