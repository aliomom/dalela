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

/// <summary>
/// / int Add(LanguageHelper Language, InputCityDto dto);
////bool Edit(LanguageHelper Language, InputCityDto dto);
////bool Delete(int Id);
/// </summary>
namespace NawafizApp.Services.Services
{
    public class GuideCityService : IGuideCityService
    {
        private readonly IUnitOfWork _unitOfWork;
        public GuideCityService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }
        #region InputGuideCityDto
        public int Add(LanguageHelper Language, InputGuideCityDto dto)
        {
            var model = Mapper.Map<InputGuideCityDto, GuideCity>(dto);
            model.GuideCityDescriptions = new List<GuideCityDescription>();
            GuideCityDescription ACdes = new GuideCityDescription();
            ACdes.CityId = model.Id;
            ACdes.LanguageId = (int)LanguageHelper.ARABIC;
            ACdes.Name = dto.ArabicCityName;
            model.GuideCityDescriptions.Add(ACdes);

            GuideCityDescription ECdes = new GuideCityDescription();
            ECdes.LanguageId = (int)LanguageHelper.ENGLISH;
            ECdes.Name = dto.EnglishCityName;
            model.GuideCityDescriptions.Add(ECdes);

            _unitOfWork.GuideCityRepository.Add(model);
            _unitOfWork.SaveChanges();

            return model.Id;
        }

        public bool Edit(LanguageHelper Language, InputGuideCityDto dto)
        {
            GuideCity c = _unitOfWork.GuideCityRepository.FindById(dto.Id);
            c.GuideCityDescriptions = new List<GuideCityDescription>();

            foreach(var Cdes in c.GuideCityDescriptions)
            {
                if(Cdes.LanguageId==(int)LanguageHelper.ARABIC)
                {
                    Cdes.Name = dto.ArabicCityName;
                }
                else if(Cdes.LanguageId == (int)LanguageHelper.ENGLISH)
                {
                    Cdes.Name = dto.EnglishCityName;
                }
            }

            _unitOfWork.GuideCityRepository.Update(c);
            _unitOfWork.SaveChanges();

            return true;
        }

        public bool? Delete(int Id)
        {
            var c1 = _unitOfWork.GuideCityRepository.FindBy(m=>m.Id==Id);
            if(!c1.Any())
            {
                return null;
            }
            else
            {
                _unitOfWork.GuideCityRepository.Remove(c1.Single());
                _unitOfWork.SaveChanges();
                return true;
            }
        }

        #endregion

        #region CityDto
        public List<GuideCityDto> GetAllGuideCities(LanguageHelper language)
        {
            var model = _unitOfWork.GuideCityRepository.GetAll().OrderBy(m => m.Sort).ToList();

            var modelDto = Mapper.Map<List<GuideCity>, List<GuideCityDto>>(model);
            int index_m = 0;
            foreach (var city in model)
            {
                modelDto[index_m].TownsDto = new List<GuideTownDto>();
                foreach (var CDes in city.GuideCityDescriptions)
                {
                    if (CDes.LanguageId == (int)language)
                    {
                        modelDto[index_m].Name = CDes.Name;
                    }

                }
                int index_m2 = 0;
                foreach (var Towns in city.GuideTowns)
                {
                    GuideTownDto towndto = new GuideTownDto();
                    towndto.CityId = Towns.CityId;
                    towndto.Id = Towns.Id;
                    foreach (var TownDes in Towns.GuideTownDescriptions)
                    {
                        if (TownDes.LanguageId == (int)language)
                        {

                            towndto.Gps_Latitude = Towns.Gps_Latitude;
                            towndto.Gps_Longitude = Towns.Gps_Longitude;
                            towndto.Name = TownDes.Name;
                            modelDto[index_m].TownsDto.Add(towndto);

                            // modelDto[index_m].TownsDto[index_m2].TownName = TownDes.TownName;
                        }

                    }
                    index_m2++;
                }
                index_m++;
            }
            return modelDto;
        }

        public GuideCityDto GetGuideCityById(LanguageHelper language, int id)
        {
            var model1 = _unitOfWork.GuideCityRepository.FindBy(m => m.Id == id);

            if (model1.Any())
            {
                var model = model1[0];
                var modelDto = Mapper.Map<GuideCity, GuideCityDto>(model);
                if (modelDto != null)
                {
                    foreach (var CDes in model.GuideCityDescriptions)
                    {
                        if (CDes.LanguageId == (int)language)
                        {
                            modelDto.Name = CDes.Name;
                        }

                    }
                    modelDto.TownsDto = new List<GuideTownDto>();

                    foreach (var Towns in model.GuideTowns)
                    {
                        GuideTownDto towndto = new GuideTownDto();
                        towndto.CityId = Towns.CityId;
                        towndto.Id = Towns.Id;
                        foreach (var TownDes in Towns.GuideTownDescriptions)
                        {
                            if (TownDes.LanguageId == (int)language)
                            {
                                towndto.Name = TownDes.Name;
                                modelDto.TownsDto.Add(towndto);

                                // modelDto[index_m].TownsDto[index_m2].TownName = TownDes.TownName;
                            }

                        }

                    }
                }

                return modelDto;
            }
            else
                return null;

        }
        #endregion

        #region Validator

        public bool IsNameUnique(string name, int? id)
        {
            if (name == null)
                return true;
            else
            {
                List<GuideCityDescription> model;

                if (id.HasValue)
                    model = _unitOfWork.GuideCityDescriptionRepository.FindBy(m => m.CityId != id);
                else
                    model = _unitOfWork.GuideCityDescriptionRepository.GetAll();
                return !model.Where(s => s.Name.ToLower() == name.ToLower()).Any();

            }
        }

        public bool IsExistId(int id)
        {
            return _unitOfWork.GuideCityRepository.FindBy(m => m.Id == id).Any();
        }

        #endregion


    }
}

