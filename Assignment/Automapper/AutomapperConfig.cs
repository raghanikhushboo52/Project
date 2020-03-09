using Assignment.Models;
using Assignment.ViewModel;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Assignment.Automapper
{
    public class AutomapperConfig
    {
        public static void RegisterMappings()
        {
            Mapper.CreateMap<Customer, CustomerViewModel>();
            Mapper.CreateMap<CustomerViewModel, Customer>();
            Mapper.CreateMap<City, CityViewModel>();
            Mapper.CreateMap<CityViewModel, City>();

        }
    }
}