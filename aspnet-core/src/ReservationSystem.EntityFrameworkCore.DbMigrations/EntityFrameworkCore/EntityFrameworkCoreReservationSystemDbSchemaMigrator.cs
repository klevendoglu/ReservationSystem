using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ReservationSystem.Data;
using Volo.Abp.DependencyInjection;

namespace ReservationSystem.EntityFrameworkCore
{
    public class EntityFrameworkCoreReservationSystemDbSchemaMigrator
        : IReservationSystemDbSchemaMigrator, ITransientDependency
    {
        private readonly IServiceProvider _serviceProvider;

        public EntityFrameworkCoreReservationSystemDbSchemaMigrator(
            IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task MigrateAsync()
        {
            /* We intentionally resolving the ReservationSystemMigrationsDbContext
             * from IServiceProvider (instead of directly injecting it)
             * to properly get the connection string of the current tenant in the
             * current scope.
             */

            await _serviceProvider
                .GetRequiredService<ReservationSystemMigrationsDbContext>()
                .Database
                .MigrateAsync();
        }
    }
}