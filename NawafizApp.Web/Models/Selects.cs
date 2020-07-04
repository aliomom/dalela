using NawafizApp.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NawafizApp.Web.Models
{
    public static class Selects
    {
        public static IList<SelectListItem> states(int? selected)
        {
            var service = DependencyResolver.Current.GetService<IStateService>();

            var list = new List<SelectListItem>
                           {
                               new SelectListItem
                                   {
                                       Selected = !selected.HasValue,
                                       Text = String.Empty,
                                       Value=""
                                   }
                           };

            list.AddRange(service.All()
                              .ToList().OrderByDescending(x=>x.Id)
                              
                              .Select(x => new SelectListItem
                              {
                                  Selected = x.Id == (selected.HasValue ? selected.Value : -1),
                                  Text = x.ArabicName,
                                  Value = x.Id.ToString()
                              })
                              .ToList());

            return list;
        }
        public static IList<SelectListItem> regionsByState(int? selected, int sId)
        {
            var service = DependencyResolver.Current.GetService<IRegionService>();

            var list = new List<SelectListItem>
                           {
                               new SelectListItem
                                   {
                                       Selected = !selected.HasValue,
                                       Text = String.Empty,
                                       Value=""
                                   }
                           };

            list.AddRange(service.getAllRegions().Where(x => x.StateId == sId)
                              .ToList().OrderByDescending(x => x.Id)

                              .Select(x => new SelectListItem
                              {
                                  Selected = x.Id == (selected.HasValue ? selected.Value : -1),
                                  Text = x.ArabicName,
                                  Value = x.Id.ToString()
                              })
                              .ToList());

            return list;
        }
        public static IList<SelectListItem> Roles(int? selected)
        {
           // var service = DependencyResolver.Current.GetService<IRegionService>();

            var list = new List<SelectListItem>
                           {
                               new SelectListItem
                                   {
                                       Selected = !selected.HasValue,
                                       Text = String.Empty,
                                       Value=""
                                   }
                           };
            list.Add(new SelectListItem
            {
                Text="عادي",
                Value = "normal"
            });
            list.Add(new SelectListItem
            {
                Text = "فضي",
                Value = "silver"
            });
            list.Add(new SelectListItem
            {
                Text = "ذهبي",
                Value = "gold"
            });
            list.Add(new SelectListItem
            {
                Text = "بلاتيني",
                Value = "blatin"
            });
            list.Add(new SelectListItem
            {
                Text = "الماسي",
                Value = "diamond"
            });
            list.Add(new SelectListItem
            {
                Text = "سوبر",
                Value = "super"
            });
            list.Add(new SelectListItem
            {
                Text = "VIP",
                Value = "vip"
            });
            return list;
        }
        public static IList<SelectListItem> NeiberHoodByregion(int? selected, int sId)
        {
            var service = DependencyResolver.Current.GetService<INeihborhoodService>();

            var list = new List<SelectListItem>
                           {
                               new SelectListItem
                                   {
                                       Selected = !selected.HasValue,
                                       Text = String.Empty,
                                       Value=""
                                   }
                           };

            list.AddRange(service.getAllNeiborHood().Where(x => x.RegionId == sId)
                              .ToList().OrderByDescending(x => x.Id)

                              .Select(x => new SelectListItem
                              {
                                  Selected = x.Id == (selected.HasValue ? selected.Value : -1),
                                  Text = x.ArabicName,
                                  Value = x.Id.ToString()
                              })
                              .ToList());

            return list;
        }

        public static IList<SelectListItem> subcatByMainCat(int? selected, int sId)
        {
            var service = DependencyResolver.Current.GetService<ISubCategetoryOffersService>();

            var list = new List<SelectListItem>
                           {
                               new SelectListItem
                                   {
                                       Selected = !selected.HasValue,
                                       Text = String.Empty,
                                       Value=""
                                   }
                           };

            list.AddRange(service.getAllSubCategetoryOffers().Where(x => x.MainCategoryOffersId == sId)
                              .ToList().OrderByDescending(x => x.Id)

                              .Select(x => new SelectListItem
                              {
                                  Selected = x.Id == (selected.HasValue ? selected.Value : -1),
                                  Text = x.ArabicName,
                                  Value = x.Id.ToString()
                              })
                              .ToList());

            return list;
        }
        public static IList<SelectListItem> subcatDalByMainCatDal(int? selected, int sId)
        {
            var service = DependencyResolver.Current.GetService<ISubCategoryDalService>();

            var list = new List<SelectListItem>
                           {
                               new SelectListItem
                                   {
                                       Selected = !selected.HasValue,
                                       Text = String.Empty,
                                       Value=""
                                   }
                           };

            list.AddRange(service.getAllSubCategoriesDal().Where(x => x.MainCategoryDalId == sId)
                              .ToList().OrderByDescending(x => x.Id)

                              .Select(x => new SelectListItem
                              {
                                  Selected = x.Id == (selected.HasValue ? selected.Value : -1),
                                  Text = x.ArabicName,
                                  Value = x.Id.ToString()
                              })
                              .ToList());

            return list;
        }
        public static IList<SelectListItem> subcatByMainCatForInitial(int? selected, int sId)
        {
            var service = DependencyResolver.Current.GetService<ISubCategetoryOffersService>();

            var list = new List<SelectListItem>
                           {
                             
                           };

            list.AddRange(service.getAllSubCategetoryOffers().Where(x => x.MainCategoryOffersId == sId)
                              .ToList().OrderByDescending(x => x.Id)

                              .Select(x => new SelectListItem
                              {
                                  Selected = x.Id == (selected.HasValue ? selected.Value : -1),
                                  Text = x.ArabicName,
                                  Value = x.Id.ToString()
                              })
                              .ToList());

            return list;
        }
        public static IList<SelectListItem> subcatDals(int? selected)
        {
            var service = DependencyResolver.Current.GetService<ISubCategoryDalService>();

            var list = new List<SelectListItem>
                           {
                               new SelectListItem
                                   {
                                       Selected = !selected.HasValue,
                                       Text = String.Empty,
                                       Value=""
                                   }
                           };

            list.AddRange(service.getAllSubCategoriesDal()
                              .ToList().OrderByDescending(x => x.Id)

                              .Select(x => new SelectListItem
                              {
                                  Selected = x.Id == (selected.HasValue ? selected.Value : -1),
                                  Text = x.ArabicName,
                                  Value = x.Id.ToString()
                              })
                              .ToList());

            return list;
        }
        public static IList<SelectListItem> favourits(int? selected)
        {
            var service = DependencyResolver.Current.GetService<INotificationService>();

            var list = new List<SelectListItem>
                           {
                               new SelectListItem
                                   {
                                       Selected = !selected.HasValue,
                                       Text = String.Empty,
                                       Value=""
                                   }
                           };

            list.AddRange(service.getAllfavourite()
                              .ToList().OrderByDescending(x => x.Id)

                              .Select(x => new SelectListItem
                              {
                                  Selected = x.Id == (selected.HasValue ? selected.Value : -1),
                                  Text = x.ArabicName,
                                  Value = x.Id.ToString()
                              })
                              .ToList());

            return list;
        }
        public static IList<SelectListItem> titlesfornotification(int? selected)
        {
            var service = DependencyResolver.Current.GetService<INotificationService>();

            var list = new List<SelectListItem>
                           {
                               new SelectListItem
                                   {
                                       Selected = !selected.HasValue,
                                       Text = String.Empty,
                                       Value=""
                                   }
                           };

            list.AddRange(service.getAllUsersNotification()
                              .ToList().OrderByDescending(x => x.Id)

                              .Select(x => new SelectListItem
                              {
                                  Selected = x.Id == (selected.HasValue ? selected.Value : -1),
                                  Text = x.title,
                                  Value = x.title.ToString()
                              })
                              .ToList());

            return list;
        }
        public static IList<SelectListItem> MainCategoriesDl(int? selected)
        {
            var service = DependencyResolver.Current.GetService<IMainCategoryDalService>();

            var list = new List<SelectListItem>
                           {
                               new SelectListItem
                                   {
                                       Selected = !selected.HasValue,
                                       Text = String.Empty,
                                       Value=""
                                   }
                           };

            list.AddRange(service.getMainCategoryDal()
                              .ToList().OrderByDescending(x => x.Id)

                              .Select(x => new SelectListItem
                              {
                                  Selected = x.Id == (selected.HasValue ? selected.Value : -1),
                                  Text = x.ArabicName,
                                  Value = x.Id.ToString()
                              })
                              .ToList());

            return list;
        }
        public static IList<SelectListItem> MainCategoriesOffer(int? selected)
        {
            var service = DependencyResolver.Current.GetService<IMainCategoryOffersService>();

            var list = new List<SelectListItem>
                           {
                               new SelectListItem
                                   {
                                       Selected = !selected.HasValue,
                                       Text = String.Empty,
                                       Value=""
                                   }
                           };

            list.AddRange(service.getMainCategoryOffers()
                              .ToList().OrderByDescending(x => x.Id)

                              .Select(x => new SelectListItem
                              {
                                  Selected = x.Id == (selected.HasValue ? selected.Value : -1),
                                  Text = x.ArabicName,
                                  Value = x.Id.ToString()
                              })
                              .ToList());

            return list;
        }
        public static IList<SelectListItem> shopdals(int? selected)
        {
            var service = DependencyResolver.Current.GetService<IShopDalService>();

            var list = new List<SelectListItem>
                           {
                               new SelectListItem
                                   {
                                       Selected = !selected.HasValue,
                                       Text = String.Empty,
                                       Value=""
                                   }
                           };

            list.AddRange(service.getAllShopDal()
                              .ToList().OrderByDescending(x => x.Id)

                              .Select(x => new SelectListItem
                              {
                                  Selected = x.Id == (selected.HasValue ? selected.Value : -1),
                                  Text = x.ArabicName,
                                  Value = x.ArabicName.ToString()
                              })
                              .ToList());

            return list;
        }
        public static IList<SelectListItem> shopdalids(int? selected)
        {
            var service = DependencyResolver.Current.GetService<IShopDalService>();

            var list = new List<SelectListItem>
                           {
                               new SelectListItem
                                   {
                                       Selected = !selected.HasValue,
                                       Text = String.Empty,
                                       Value=""
                                   }
                           };

            list.AddRange(service.getAllShopDal()
                              .ToList().OrderByDescending(x => x.Id)

                              .Select(x => new SelectListItem
                              {
                                  Selected = x.Id == (selected.HasValue ? selected.Value : -1),
                                  Text = x.ArabicName,
                                  Value = x.Id.ToString()
                              })
                              .ToList());

            return list;
        }
        public static IList<SelectListItem> shopdalidsUsers(int? selected)
        {
            var service = DependencyResolver.Current.GetService<IShopDalService>();

            var list = new List<SelectListItem>
                           {
                               new SelectListItem
                                   {
                                       Selected = !selected.HasValue,
                                       Text = String.Empty,
                                       Value=""
                                   }
                           };

            list.AddRange(service.getAllShopDal().Where(q=>q.UserId == null)
                              .ToList().OrderByDescending(x => x.Id)

                              .Select(x => new SelectListItem
                              {
                                //  Selected = x.Id == (selected.HasValue ? selected.Value : -1),
                                  Text = x.ArabicName,
                                  Value = x.Id.ToString()
                              })
                              .ToList());

            return list;
        }
        public static IList<SelectListItem> users(int? selected)
        {
            var service = DependencyResolver.Current.GetService<IUserService>();

            var list = new List<SelectListItem>
                           {
                               new SelectListItem
                                   {
                                       Selected = !selected.HasValue,
                                       Text = String.Empty,
                                       Value=""
                                   }
                           };

            list.AddRange(service.GetAll()
                              .ToList().OrderByDescending(x => x.UserId)

                              .Select(x => new SelectListItem
                              {
                                  //Selected = x.UserId == (selected.HasValue ? selected.Value : -1),
                                  Text = x.username,
                                  Value = x.UserId.ToString()
                              })
                              .ToList());

            return list;
        }
        public static IList<SelectListItem> Branches(int? selected)
        {
            var service = DependencyResolver.Current.GetService<IBranchService>();

            var list = new List<SelectListItem>
                           {
                               new SelectListItem
                                   {
                                       Selected = !selected.HasValue,
                                       Text = String.Empty,
                                       Value=""
                                   }
                           };

            list.AddRange(service.getAllBranch()
                              .ToList().OrderByDescending(x => x.Id)

                              .Select(x => new SelectListItem
                              {
                                  Selected = x.Id == (selected.HasValue ? selected.Value : -1),
                                  Text = x.branchArabicName,
                                  Value = x.Id.ToString()
                              })
                              .ToList());

            return list;
        }
        //public static IList<SelectListItem> SubCategoryByMainCategory(int? selected, int mid)
        //{
        //    var service = DependencyResolver.Current.GetService<IMainService>();

        //    var list = new List<SelectListItem>
        //                   {
        //                       new SelectListItem
        //                           {
        //                               Selected = !selected.HasValue,
        //                               Text = String.Empty,
        //                               Value=""
        //                           }
        //                   };

        //    list.AddRange(service.getAllSubCategoriesByMainCatrgory(mid)
        //                      .ToList().OrderByDescending(x => x.Id)

        //                      .Select(x => new SelectListItem
        //                      {
        //                          Selected = x.Id == (selected.HasValue ? selected.Value : -1),
        //                          Text = x.name,
        //                          Value = x.Id.ToString()
        //                      })
        //                      .ToList());

        //    return list;
        //}

        //public static IList<SelectListItem> Users(int? selected)
        //{
        //    var service = DependencyResolver.Current.GetService<IUserService>();

        //    var list = new List<SelectListItem>
        //                   {
        //                       new SelectListItem
        //                           {
        //                               Selected = !selected.HasValue,
        //                               Text = String.Empty,
        //                               Value=""
        //                           }
        //                   };

        //    list.AddRange(service.GetAll().Where(x => !service.HasRole(x.UserId, "Admin"))
        //                      .ToList()

        //                      .Select(x => new SelectListItem
        //                      {

        //                          Text = x.FullName,
        //                          Value = x.UserName
        //                      })
        //                      .ToList());

        //    return list;
        //}
    }
}