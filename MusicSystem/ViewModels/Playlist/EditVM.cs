using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace MusicSystem.ViewModels.Playlist
{
    public class EditVM
    {
        [DisplayName("Name: ")]
        [Required(ErrorMessage = "This field is Required!")]
        public string Name { get; set; }
    }
}
