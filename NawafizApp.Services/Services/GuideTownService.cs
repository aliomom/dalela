using AutoMapper;
using NawafizApp.Domain;
using NawafizApp.Common;
using NawafizApp.Domain.Entities;
using NawafizApp.Services.Dtos;
using NawafizApp.Services.Interfaces;
using NawafizApp.Services.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.IO;


namespace NawafizApp.Services.Services
{
    public class GuideTownService : IGuideTownService
    {
        private readonly IUnitOfWork _unitOfWork;
        public GuideTownService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }

        #region InputGuideTownDto
        public int? Add(LanguageHelper Language, InputGuideTownDto dto)
        {
            var model = Mapper.Map<InputGuideTownDto, GuideTown>(dto);
            model.GuideTownDescriptions = new List<GuideTownDescription>();
            GuideTownDescription ATdes = new GuideTownDescription();
            ATdes.TownId = model.Id;
            ATdes.LanguageId = (int)LanguageHelper.ARABIC;
            ATdes.Name = dto.ArabicTownName;
            model.GuideTownDescriptions.Add(ATdes);

            GuideTownDescription ETdes = new GuideTownDescription();
            ETdes.LanguageId = (int)LanguageHelper.ENGLISH;
            ETdes.Name = dto.EnglishTownName;
            
            var cityName = _unitOfWork.GuideCityDescriptionRepository.FindBy(m => m.CityId == model.CityId).Where(v => v.LanguageId == (int)LanguageHelper.ARABIC).ToList()[0].Name;
            GPS.GetGps townGps = new GPS.GetGps(cityName, dto.ArabicTownName);
            if(townGps.latitude==0|| townGps.longitude==0)
            { return null; }
            try
            {
                model.Gps_Latitude = townGps.latitude.ToString();
                model.Gps_Longitude = townGps.longitude.ToString();
               // model.Place_Id = GPS.GetGps.Get_PlaceId_And_Town(model.Gps_Latitude.ToString() + "," + model.Gps_Longitude.ToString()).ToList()[0];
                model.GuideTownDescriptions.Add(ETdes);

                _unitOfWork.GuideTownRepository.Add(model);
                _unitOfWork.SaveChanges();

                return model.Id;
            }
            catch
            {
                return null;
            }
        }

        public bool? Edit(LanguageHelper Language, InputGuideTownDto dto)
        {
            GuideTown T = _unitOfWork.GuideTownRepository.FindById(dto.Id);
            T.GuideTownDescriptions = new List<GuideTownDescription>();
            T.CityId = dto.CityId;
            foreach (var Tdes in T.GuideTownDescriptions)
            {
                if (Tdes.LanguageId == (int)LanguageHelper.ARABIC)
                {
                    Tdes.Name = dto.ArabicTownName;
                }
                else if (Tdes.LanguageId == (int)LanguageHelper.ENGLISH)
                {
                    Tdes.Name = dto.EnglishTownName;
                }
            }
            var cityName = _unitOfWork.GuideCityDescriptionRepository.FindBy(m => m.CityId == T.CityId).Where(v => v.LanguageId == (int)LanguageHelper.ARABIC).ToList()[0].Name;
            GPS.GetGps townGps = new GPS.GetGps(cityName, dto.ArabicTownName);
            if (townGps.latitude == 0 || townGps.longitude == 0)
            { return null; }
            try
            {
                T.Gps_Latitude = townGps.latitude.ToString();
                T.Gps_Longitude = townGps.longitude.ToString();
               // T.Place_Id = GPS.GetGps.Get_PlaceId_And_Town(T.Gps_Latitude.ToString() + "," + T.Gps_Longitude.ToString()).ToList()[0];
                //  T.TownDescriptions.Add(ETdes);

                _unitOfWork.GuideTownRepository.Update(T);
                _unitOfWork.SaveChanges();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool? Delete(int Id)
        {
            var T = _unitOfWork.GuideTownRepository.FindBy(m=>m.Id==Id);
            if (!T.Any())
            {
                return null;
            }
            else
            {
                _unitOfWork.GuideTownRepository.Remove(T[0]);
                _unitOfWork.SaveChanges();
                return true;
            }
        }

        #endregion

        #region TownDto
        public List<GuideTownDto> GetAllGuideTowns(LanguageHelper language)
        {
            var model = _unitOfWork.GuideTownRepository.GetAll();
            var modelDto = Mapper.Map<List<GuideTown>, List<GuideTownDto>>(model);
            int index_m = 0;
            foreach (var k in model)
            {

                foreach (var TDes in k.GuideTownDescriptions)
                {
                    if (TDes.LanguageId == (int)language)
                    {
                        modelDto[index_m].Name = TDes.Name;
                    }

                }
                index_m++;
            }
            return modelDto;
        }




        public GuideTownDto GetGuideTownById(LanguageHelper language, int id)
        {
            var model = _unitOfWork.GuideTownRepository.FindById(id);

            var modelDto = Mapper.Map<GuideTown, GuideTownDto>(model);
            if (modelDto != null)
            {
                foreach (var TDes in model.GuideTownDescriptions)
                {
                    if (TDes.LanguageId == (int)language)
                    {
                        modelDto.Name = TDes.Name;
                    }

                }
            }
            return modelDto;
        }

        public GuideCityDto GetGuideCityByTownId(LanguageHelper language,int id)
        {
            var model1 = _unitOfWork.GuideTownRepository.GetAll().Where(m => m.Id == id);
            if (model1.Any())
            {
                var modelCity = model1.Single().GuideCity.GuideCityDescriptions.Where(m => m.LanguageId == (int)language).Single();
                GuideCityDto c = new GuideCityDto();
                c.Id = modelCity.CityId;
                c.Name = modelCity.Name;
                return c;
            }
            else
              return null;

        }
        #endregion

        #region Validator

        public bool IsIdExist(int id)
        {
            return _unitOfWork.GuideTownRepository.FindBy(m => m.Id == id).Any();
        }
        public bool IsCityIdExist(int Cityid)
        {
            return _unitOfWork.GuideCityRepository.FindBy(m => m.Id == Cityid).Any();
        }

        //public bool ISPlaceIdUnique(string ArabicTownName, int CityId, int? editedId)
        //{
        //    List<GuideTown> towns;
        //  //  string Place_Id;
        //    if (editedId.HasValue)
        //        towns = _unitOfWork.GuideTownRepository.FindBy(m => m.Id != editedId);
        //    else
        //        towns = _unitOfWork.GuideTownRepository.GetAll();
        //    try
        //    {
        //        var cities = _unitOfWork.CityRepository.FindBy(m => m.Id == CityId);
        //        if (cities.Any())
        //        {

        //            GPS.GetGps townGps = new GPS.GetGps(ArabicTownName, cities[0].CityDescription.Where(m => m.LanguageId == (int)LanguageHelper.ARABIC).ToList()[0].CityName);

        //           Place_Id = GPS.GetGps.Get_PlaceId_And_Town(townGps.latitude.ToString() + "," + townGps.longitude.ToString()).ToList()[0];

        //        }
        //        else
        //            return true;
        //    }
        //    catch
        //    {
        //        return false;
        //    }


        //    return !towns.Where(m => m.Place_Id.ToLower() == Place_Id.ToLower()).Any();
        //}


        #endregion

    }
}

