using NawafizApp.Data;
using NawafizApp.Domain;
using NawafizApp.Resolver;
using NawafizApp.Services.Dtos;
using NawafizApp.Services.Dtos.Validators;
using NawafizApp.Services.Identity;
using NawafizApp.Services.Interfaces;
using NawafizApp.Services.Services;
using FluentValidation;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace NawafizApp.Services
{
    [Export(typeof(IComponent))]
    public class DependencyResolver : IComponent
    {
        public void SetUp(IRegisterComponent registerComponent)
        {
            registerComponent.RegisterTypeWithInjectedConstructor<IUnitOfWork, UnitOfWork>("NawafizApp");
            registerComponent.RegisterTypeWithTransientLifetimeManager<IUserStore<IdentityUser, Guid>, UserStore>();
            registerComponent.RegisterTypeWithTransientLifetimeManager<IRoleStore<IdentityRole,Guid>,RoleStore>();

            // Services
            registerComponent.RegisterType<ILanguageService, LanguageService>();
            registerComponent.RegisterType<IUserService,UserService>();
            registerComponent.RegisterType<IArabicServiceAPI, ArabicServiceAPI>();
            registerComponent.RegisterType<INotificationService, NotificationService>();
            registerComponent.RegisterType<IStateService, StateService>();
            registerComponent.RegisterType<IRegionService, RegionService>();
            registerComponent.RegisterType<INeihborhoodService, NeihborhoodService>();
            registerComponent.RegisterType<IMainCategoryDalService, MainCategoryDalService>();
            registerComponent.RegisterType<ISubCategoryDalService, SubCategoryDalService>();
            registerComponent.RegisterType<IBreakService, BreakService>();
            registerComponent.RegisterType<IBranchService, BranchService>();
            registerComponent.RegisterType<IClientOfferService, ClientOfferService>();
            registerComponent.RegisterType<IShopDalService, ShopDalService>();
            registerComponent.RegisterType<IMainCategoryOffersService, MainCategoryOffersService>();
            registerComponent.RegisterType<ISubCategetoryOffersService, SubCategetoryOffersService>();
            registerComponent.RegisterType<IOfferService, OfferService>();
            registerComponent.RegisterType<IBranchAndShopDalService, BranchAndShopDalService>();
            registerComponent.RegisterType<IGalleryPhotoService, GalleryPhotoService>();
            registerComponent.RegisterType<IFollowerService, FollowerService>();
            // Validators
            registerComponent.RegisterType<IValidator<LanguageDto>, LanguageValidator>();
            registerComponent.RegisterType<IValidator<StateDto>, StateValidator>();
            registerComponent.RegisterType<IValidator<RegionDto>, RegionValidator>();
            registerComponent.RegisterType<IValidator<NeihborhoodDto>, NeiborHoodValidator>();
            registerComponent.RegisterType<IValidator<RegisterUserDto>, RegisterUserValidator>();
            registerComponent.RegisterType<IValidator<MainCategoryDalDto>, MainCategoryDalValidator>();
            registerComponent.RegisterType<IValidator<SubCategoryDalDto>, SubCategoryDalValidator>();
            registerComponent.RegisterType<IValidator<SubCategetoryOffersDto>, SubCategetoryOffersValidator>();
            registerComponent.RegisterType<IValidator<MainCategoryOffersDto>, MainCategoryOffersValidator>();
            registerComponent.RegisterType<IValidator<OfferDto>, OfferValidator>();
            registerComponent.RegisterType<IValidator<BranchAndShopDalDto>, BranchAndShopDalValidator>();
            registerComponent.RegisterType<IValidator<BranchDto>, BranchValidator>();
            registerComponent.RegisterType<IValidator<FavouriteDto>, FavouriteValidator>();
        }
    }
}
