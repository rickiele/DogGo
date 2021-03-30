using System.ComponentModel.DataAnnotations;

namespace DogGo.Models
{
    public class Neighborhood
    {
        public int Id { get; set; }

        [Display(Name = "Neighborhood")]
        public string Name { get; set; }
    }
}