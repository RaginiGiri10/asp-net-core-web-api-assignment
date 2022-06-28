using CarsAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CarsAPI.DBContext
{
    public class CarDbContext: DbContext
    {
        public CarDbContext(DbContextOptions<CarDbContext> options) : base(options)
        {

        }
        public virtual DbSet<Car> Cars { get; set; }

    }
}
