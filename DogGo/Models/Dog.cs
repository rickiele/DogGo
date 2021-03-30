using System.ComponentModel.DataAnnotations;

namespace DogGo.Models
{
    public class Dog
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int OwnerId { get; set; }
        public Owner Owner { get; set; }
        public string Breed { get; set; }
        public string Notes { get; set; }

        [Display(Name = "Photo")]
        public string ImageUrl { get; set; }
    }
}