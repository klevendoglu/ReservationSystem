using JetBrains.Annotations;
using ReservationSystem.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;

namespace ReservationSystem.Resources
{
    public class ResourceManager : DomainService
    {
        private readonly IRepository<Resource, Guid> _resourceRepository;

        public ResourceManager(IRepository<Resource, Guid> resourceRepository)
        {
            _resourceRepository = resourceRepository;
        }

        public async Task<Resource> CreateAsync(
            [NotNull] string name,
            [NotNull] Guid managerId,
            byte category,
            [NotNull] int maxReservationHours,
            [CanBeNull] Guid? parentId = null,
            [CanBeNull] string location = null,
            [CanBeNull] string serial = null,
            [CanBeNull] string image = null,
            [CanBeNull] string description = null
            )
        {

            if (await _resourceRepository.AnyAsync(t => t.Name == name))
            {
                throw new BusinessException("Resource:ResourceWithSameNameExists");
            }

            return new Resource(
                GuidGenerator.Create(),
                name,
                managerId,
                category,
                maxReservationHours,
                parentId,
                location,
                serial,
                image,
                description
            );
        }

        public async Task ChangeNameAsync(Resource resource, string name)
        {
            if (resource.Name == name)
            {
                return;
            }

            if (await _resourceRepository.AnyAsync(t => t.Name == name))
            {
                throw new BusinessException("Resource:ResourceWithSameNameExists");
            }

            resource.ChangeName(name);
        }

        public async Task AssignManagerAsync(Resource resource, AppUser user)
        {
            var managersResourceCount = await _resourceRepository.CountAsync(
                i => i.ManagerId == user.Id
            );

            if (managersResourceCount >= 5)
            {
                throw new BusinessException("Resource:ManagersConcurrentResourceLimit");
            }

            resource.SetManager(user.Id);
        }

        public async Task AssignParentAsync(Resource resource, Resource parent)
        {
            if (resource.Id == parent.Id)
            {
                return;
            }
            resource.SetParent(parent.Id);
        }
    }
}
