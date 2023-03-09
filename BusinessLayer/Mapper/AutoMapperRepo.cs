using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DataAccessLayer;
using Entities;
using Models;

namespace BusinessLayer
{
    public class AutoMapperRepo : Profile
    {
        public AutoMapperRepo()
        {
            CreateMap<RequiredModel, OfferRide>()
                .ForMember(dest => dest.Stops, src => src.MapFrom(new OfferRideResolver()))
                .ForMember(dest => dest.From, src => src.MapFrom(act => act.OfferingRide.From))
                .ForMember(dest => dest.To, src => src.MapFrom(act => act.OfferingRide.To))
                .ForMember(dest => dest.Price, src => src.MapFrom(act => act.OfferingRide.Price))
                .ForMember(dest => dest.OfferingId, src => src.MapFrom(act => act.OfferingRide.OfferingId))
                .ForMember(dest => dest.TotalSeats, src => src.MapFrom(act => act.OfferingRide.TotalSeats))
                .ForMember(dest => dest.AvailableSeats, src => src.MapFrom(act => act.OfferingRide.AvailableSeats))
                .ForMember(dest => dest.OfferTiming, src => src.MapFrom(act => act.OfferingRide.OfferTiming))
                .ForMember(dest => dest.OfferDate, src => src.MapFrom(act => act.OfferingRide.OfferDate))
                .ForMember(dest => dest.AccountId, src => src.MapFrom(act => act.OfferingRide.AccountId));
        }
        //public static Mapper IntializeAutoMapper()
        //{
        //    var config = new MapperConfiguration(cfg =>
        //    {
        //        cfg.CreateMap<RequiredModel, OfferRide>()
        //        .ForMember(dest => dest.Stops, src => src.MapFrom(new OfferRideResolver()))
        //        .ForMember(dest => dest.From, src => src.MapFrom(act => act.OfferingRide.From))
        //        .ForMember(dest => dest.To, src => src.MapFrom(act => act.OfferingRide.To))
        //        .ForMember(dest => dest.Price, src => src.MapFrom(act => act.OfferingRide.Price))
        //        .ForMember(dest => dest.OfferingId, src => src.MapFrom(act => act.OfferingRide.OfferingId))
        //        .ForMember(dest => dest.TotalSeats, src => src.MapFrom(act => act.OfferingRide.TotalSeats))
        //        .ForMember(dest => dest.AvailableSeats, src => src.MapFrom(act => act.OfferingRide.AvailableSeats))
        //        .ForMember(dest => dest.OfferTiming, src => src.MapFrom(act => act.OfferingRide.OfferTiming))
        //        .ForMember(dest => dest.OfferDate, src => src.MapFrom(act => act.OfferingRide.OfferDate))
        //        .ForMember(dest => dest.AccountId, src => src.MapFrom(act => act.OfferingRide.AccountId));
        //    });
        //    var mapper = new Mapper(config);
        //    return mapper;
        //}
    }
}
