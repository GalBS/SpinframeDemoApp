using Common.Models;

namespace DAL.Repositories
{
    public interface ICarRepository : IRepository<Car>
    {
        Car GetCarByLicensePlate(string licencePlate);
    }
}
