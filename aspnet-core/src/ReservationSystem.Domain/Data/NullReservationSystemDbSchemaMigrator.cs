using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace ReservationSystem.Data
{
    /* This is used if database provider does't define
     * IReservationSystemDbSchemaMigrator implementation.
     */
    public class NullReservationSystemDbSchemaMigrator : IReservationSystemDbSchemaMigrator, ITransientDependency
    {
        public Task MigrateAsync()
        {
            return Task.CompletedTask;
        }
    }
}