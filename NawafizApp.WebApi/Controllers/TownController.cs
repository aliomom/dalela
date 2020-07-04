using GoogleMaps.LocationServices;
using NawafizApp.Common;
using NawafizApp.Common.Resources;
using NawafizApp.Services.Dtos;
using NawafizApp.Services.Interfaces;
using NawafizApp.WebApi.ActionFilters;
using NawafizApp.WebApi.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace NawafizApp.WebApi.Controllers
{
    public class TownController : ApiBaseController
    {
        private readonly ITownService _lTownService;

        public TownController(ITownService ITownService)
        {
            _lTownService = ITownService;
            
        }


        //[HttpGet]
        //[Route("~/api/Town/GetGps")]
        //public string  GetGps()
        //{
        //    var address = "Latakia,Jablah";

        //    var locationService = new GoogleLocationService();
        //    var point = locationService.GetLatLongFromAddress(address);

        //    var latitude = point.Latitude;
        //    var longitude = point.Longitude;

        //    return latitude.ToString()+"  ,  " + longitude;

        //}

        //[HttpGet]
        //[Route("~/api/Town/distance")]
        //public string distance(double lat1, double lon1, double lat2, double lon2, char unit)
        //{
        //    double theta = lon1 - lon2;
        //    double dist = Math.Sin(deg2rad(lat1)) * Math.Sin(deg2rad(lat2)) + Math.Cos(deg2rad(lat1)) * Math.Cos(deg2rad(lat2)) * Math.Cos(deg2rad(theta));
        //    dist = Math.Acos(dist);
        //    dist = rad2deg(dist);
        //    dist = dist * 60 * 1.1515;

        //    if (unit == 'K')
        //    {
        //        dist = dist * 1.609344;
        //    }
        //    else if (unit == 'N')
        //    {
        //        dist = dist * 0.8684;
        //    }

        //    return (dist.ToString());

        //}
        //private double deg2rad(double deg)
        //{

        //    return (deg * Math.PI / 180.0);

        //}



        ////:::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::

        ////::  This function converts radians to decimal degrees             :::

        ////:::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
        //private double rad2deg(double rad)
        //{

        //    return (rad / Math.PI * 180.0);
        //}



        [HttpGet]
        [Route("~/api/Town/GetTownById")]
        public TownDto GetTownById(int id)
        {
            var model = _lTownService.GetTownById(CurrentLanguage, id);
            if (model != null)
                return model;
            throw new HttpResponseException(NotFoundMessage(CityAndTown.TownNotExist));

        }
        
    }
}
 