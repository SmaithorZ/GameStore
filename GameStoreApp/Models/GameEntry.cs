using System.ComponentModel.DataAnnotations;

namespace GameStoreApp.Models
{
    public class GameEntry
    {

       public int Id { get; set; }

        [Required(ErrorMessage = "Please enter a Game Title!")]
        [StringLength(100, MinimumLength =3, 
            ErrorMessage = "Game Title must be between 3 to 100 characters" )]
        public string Title { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please Enter a Description")]
        public string Description { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please Enter a Date")]
        public DateTime Created { get; set; } = DateTime.Now;



    }
}
