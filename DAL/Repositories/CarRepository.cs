using Common.Models;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    public class CarRepository : Repository<Car>, ICarRepository
    {
        public CarRepository(DbContext context) : base(context)
        {
        }

        public ApplicationDbContext ApplicationDbContext => Context as ApplicationDbContext;

        public Car GetCarByLicensePlate(string licencePlate)
        {
            return SingleOrDefault(c => c.LicensePlate == licencePlate);
        }
    }
}
