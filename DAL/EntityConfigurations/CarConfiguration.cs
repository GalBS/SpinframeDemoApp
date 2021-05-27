using Common.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.EntityConfigurations
{
    public class CarConfiguration : IEntityTypeConfiguration<Car>
    {
        public void Configure(EntityTypeBuilder<Car> builder)
        {
            builder.HasIndex(c => c.LicensePlate).IsUnique();

            builder.HasData(new Car
            {
                Id = 1,
                LicensePlate = "11122333",
                Color = Color.White,
                Manufacturer = Manufacturer.Volkswagen,
                Year = 2010
            });

            builder.HasData(new Car
            {
                Id = 2,
                LicensePlate = "22233444",
                Color = Color.Black,
                Manufacturer = Manufacturer.BMW,
                Year = 2011
            });

            builder.HasData(new Car
            {
                Id = 3,
                LicensePlate = "33344555",
                Color = Color.Silver,
                Manufacturer = Manufacturer.Audi,
                Year = 2012
            });

            builder.HasData(new Car
            {
                Id = 4,
                LicensePlate = "44455666",
                Color = Color.White,
                Manufacturer = Manufacturer.Dodge,
                Year = 2013
            });
        }
    }
}
