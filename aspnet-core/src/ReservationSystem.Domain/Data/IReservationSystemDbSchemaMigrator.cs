using System.Threading.Tasks;

namespace ReservationSystem.Data
{
    public interface IReservationSystemDbSchemaMigrator
    {
        Task MigrateAsync();
    }
}
