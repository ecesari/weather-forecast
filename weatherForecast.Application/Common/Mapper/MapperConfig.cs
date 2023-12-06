using AutoMapper;

namespace weatherForecast.Application.Common.Mapper
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {
            //CreateMap<Client, ClientResponse>();
            //CreateMap<(Psychologist psychologist, TimeSlot availability), PsychologistAvailabilityResponse>()
            //    .ForMember(response => response.PsychologistId, opt => opt.MapFrom(src => src.psychologist.Id))
            //    .ForMember(response => response.TimeSlotId, opt => opt.MapFrom(src => src.availability.Id))
            //    .ForMember(response => response.TimeFrom, opt => opt.MapFrom(src => src.availability.TimeFrom))
            //    .ForMember(response => response.TimeTo, opt => opt.MapFrom(src => src.availability.TimeTo));
        }
    }
}
