using AutoMapper;
using ReservationSystem.Reservations;
using ReservationSystem.Reservations.Dtos.Reservation;
using ReservationSystem.Resources;
using ReservationSystem.Resources.Dtos;
using ReservationSystem.Resources.Dtos.Resource;

namespace ReservationSystem
{
    public class ReservationSystemApplicationAutoMapperProfile : Profile
    {
        public ReservationSystemApplicationAutoMapperProfile()
        {
            /* You can configure your AutoMapper mapping configuration here.
             * Alternatively, you can split your mapping configurations
             * into multiple profile classes for a better organization. */
            CreateMap<Reservation, ReservationDto>();
            CreateMap<ReservationItem, ReservationItemDto>();
            CreateMap<Resource, ResourceDto>();
            CreateMap<CreateResourceInputDto, Resource>();
            CreateMap<UpdateResourceInputDto, Resource>();
        }
    }
}
