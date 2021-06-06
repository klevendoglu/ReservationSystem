using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace ReservationSystem.Resources.Dtos
{
    public class GetResourcesInput : PagedAndSortedResultRequestDto
    {
        public Guid? ManagerId { get; set; }

        public Guid? ResourceId { get; set; }

        public string Filter { get; set; }

        public Guid? ParentId { get; set; }

        public Enum.ResourceCategory? Category { get; set; }

        public bool OnlyChildren { get; set; }

        public bool OnlyParents { get; set; }

        public void Normalize()
        {
            if (string.IsNullOrWhiteSpace(Sorting))
            {
                Sorting = "Name ASC";
            }
        }

        public GetResourcesInput()
        {
            Sorting = "Name ASC";
        }
    }
}
