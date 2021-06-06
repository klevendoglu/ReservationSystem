using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;

namespace ReservationSystem.Reservations
{
    public class ReservationSystemManager : DomainService
    {
        private readonly IRepository<Reservation, Guid> _reservationRepository;

        public ReservationSystemManager(IRepository<Reservation, Guid> reservationRepository)
        {
            _reservationRepository = reservationRepository;
        }

        //public async Task<Reservation> CreateAsync(
        //    string reserverNote,
        //    Enum.Status status,
        //    string title,
        //    string text = null)
        //{
        //    if (await _reservationRepository.AnyAsync(i => i.Title == title))
        //    {
        //        throw new BusinessException("IssueTracking:IssueWithSameTitleExists");
        //    }

        //    return new Reservation(
        //        GuidGenerator.Create(),
        //        status,
        //        reserverNote,
        //        title,
        //        text
        //    );
        //}
    }
}
