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

        public async Task ChangeNameAsync(Resource resource, string name)
        {
            if (resource.Name == name)
            {
                return;
            }

            if (await _resourceRepository.AnyAsync(i => i.Name == name))
            {
                throw new BusinessException("Resource:ResourceWithSameNameExists");
            }

            resource.SetName(name);
        }

        public async Task AssignManager(Resource resource, AppUser user)
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

        public async Task AssignParent(Resource resource, Resource parent)
        {
            if (resource.Id == parent.Id)
            {
                return;
            }
            resource.SetParent(parent.Id);
        }
    }
}
