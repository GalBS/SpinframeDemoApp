using System.ComponentModel.DataAnnotations;

namespace Common.Models
{
    public class Car
    {
        public int Id { get; set; }

        [Display(Name = "License Plate")]
        [Required(ErrorMessage = "This field is required.")]
        [RegularExpression("^[a-zA-Z0-9]+$", ErrorMessage = "Only numbers and letters are allowed.")]
        public string LicensePlate { get; set; }

        public Color Color { get; set; }

        public Manufacturer Manufacturer { get; set; }

        public int Year { get; set; }
    }
}
