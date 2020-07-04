using AutoMapper;
using NawafizApp.Common;
using NawafizApp.Domain.Entities;
using NawafizApp.Services.Dtos;
using NawafizApp.Services.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NawafizApp.Services
{
    public static class DtoMappings
    {
        public static void Initialize()
        {
            Mapper.Initialize(cfg =>
            {
                // ENTITY TO DTO
                #region ENTITY TO DTO
                cfg.CreateMap<User, IdentityUser>()
                    .ForMember(dest => dest.Id,
                        opts => opts.MapFrom(src => src.UserId));
                ;
                cfg.CreateMap<Language, LanguageDto>();
                cfg.CreateMap<User, UserDto>();//.ForMember(des=>des.Role ,opt=>opt.MapFrom(src=>src.Roles.ToList()[0].Name));
               
               cfg.CreateMap<State , StateDto>();
                cfg.CreateMap<Region, RegionDto>();
                cfg.CreateMap<Neighborhood, NeihborhoodDto>();
                cfg.CreateMap<MainCategoryDal, MainCategoryDalDto>();
                cfg.CreateMap<SubCategoryDal, SubCategoryDalDto>();
                cfg.CreateMap<Branch, BranchDto>();
                cfg.CreateMap<Break, BreakDto>();
                cfg.CreateMap<ClientOffer, ClientOfferDto>();
                cfg.CreateMap<ShopDal, ShopDalDto>();
                cfg.CreateMap<MainCategoryOffers, MainCategoryOffersDto>();
                cfg.CreateMap<SubCategetoryOffers, SubCategetoryOffersDto>();
                cfg.CreateMap<ShopDal, BranchAndShopDalDto>();
                cfg.CreateMap<Branch, BranchAndShopDalDto>();
                cfg.CreateMap<Offer, OfferDto>();
                cfg.CreateMap<Favourite, FavouriteDto>();
                cfg.CreateMap<GalleryPhoto, GalleryPhotoDto>();
                cfg.CreateMap<Follower, FollowerDto>();
                cfg.CreateMap<Notification, NotificationDto>();
                //cfg.CreateMap< GuideTown , InputGuideTownDto>();
                // cfg.CreateMap<City, InputCityDto>();

                //cfg.CreateMap<CategoryDescription, CategoryDto>();

                //cfg.CreateMap<Languages2, Languages2Dto>();


                #endregion

                // DTO TO ENTITY
                #region DTO TO ENTTY
                cfg.CreateMap<IdentityUser, User>()
                    .ForMember(dest => dest.UserId,
                        opts => opts.MapFrom(src => src.Id));
                ;
                cfg.CreateMap<LanguageDto, Language>();
                cfg.CreateMap<StateDto, State>();
                cfg.CreateMap<RegionDto, Region>();
                cfg.CreateMap<NeihborhoodDto, Neighborhood>();
                cfg.CreateMap<MainCategoryDalDto, MainCategoryDal>();
                cfg.CreateMap<SubCategoryDalDto, SubCategoryDal>();
                cfg.CreateMap<BranchDto, Branch>();
                cfg.CreateMap<BreakDto, Break>();
                cfg.CreateMap<ClientOfferDto, ClientOffer>();
                cfg.CreateMap<ShopDalDto, ShopDal>();
                cfg.CreateMap<MainCategoryOffersDto, MainCategoryOffers>();
                cfg.CreateMap<SubCategetoryOffersDto, SubCategetoryOffers>();
                cfg.CreateMap<OfferDto, Offer>();
                cfg.CreateMap<BranchAndShopDalDto, ShopDal>();
                cfg.CreateMap<BranchAndShopDalDto, Branch>();
                cfg.CreateMap<FavouriteDto, Favourite>();
                cfg.CreateMap<GalleryPhotoDto, GalleryPhoto>();
                cfg.CreateMap<FollowerDto, Follower>();
                cfg.CreateMap<NotificationDto, Notification>();
                //cfg.CreateMap<Languages2Dto, Languages2>();
                #endregion
            });

        }
    }
}
