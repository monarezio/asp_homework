using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace reservations_data
{
    public class ReservationDbContextFactory : IDesignTimeDbContextFactory<ReservationDbContext>
    {
        public ReservationDbContext CreateDbContext(string[] args)
        {
            DbContextOptionsBuilder optionsBuilder = new DbContextOptionsBuilder<ReservationDbContext>()
                .UseMySql("Server=localhost;Database=asp_reservations;User=root;Password=;");

            return new ReservationDbContext(optionsBuilder.Options);
        }
    }
}