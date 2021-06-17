using ReservationSystem.Reservations.Dtos.Reservation;
using ReservationSystem.Resources;
using ReservationSystem.Resources.Dtos;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace ReservationSystem.Reservations
{
    public class ReservationSystemAppServiceTests : ReservationSystemApplicationTestBase
    {
        private readonly IReservationSystemAppService _reservationSystemAppService;
        private readonly IResourceAppService _resourceAppService;

        public ReservationSystemAppServiceTests()
        {
            _reservationSystemAppService = GetRequiredService<IReservationSystemAppService>();
            _resourceAppService = GetRequiredService<IResourceAppService>();
        }

        [Fact]
        public async Task Should_Create_Reservation()
        {
            //Arrange

            var resources = await _resourceAppService.GetListAsync(new GetResourcesInput());
            var firstResource = resources.Items.First();

            CreateReservationInputDto input = new CreateReservationInputDto
            {
                IsReservationApprovalRequired = false,
                ReserverNotes = "Should reserve this item.",
                Status = Enum.Status.Pending,
                RequestedItems = new List<CreateReservationItemInputDto>()
                    {
                        new CreateReservationItemInputDto()
                        {
                            RequestedHours = 1,
                            StartTime = DateTime.Now.AddHours(-10),
                            EndTime = DateTime.Now.AddHours(-8),
                            Status = Enum.Status.Pending,
                            ResourceId = firstResource.Id
                        }
                    }
            };

            //Act
            var result = await _reservationSystemAppService.CreateAsync(input);

            //Assert
            Assert.NotNull(result);
            result.Id.ShouldNotBe(Guid.Empty);
            result.ReservationItems.Count.ShouldBeGreaterThan(0);
            result.ReservationItems.ShouldContain(u => u.Status == Enum.Status.Pending);
        }

    }
}
