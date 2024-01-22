using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace MusicSystem.ViewModels.Album
{
    public class CreateVM
    {

        [DisplayName("Title: ")]
        [Required(ErrorMessage = "This field is Required!")]
        public string Title { get; set; }
    }
}
