using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Runtime.InteropServices;

namespace MusicSystem.ViewModels.User
{
    public class CreateVM
    {
        [DisplayName("Username: ")]
        [Required(ErrorMessage = "This field is Required!")]
        public string Username { get; set; }

        [DisplayName("Password: ")]
        [Required(ErrorMessage = "This field is Required!")]
        public string Password { get; set; }
        [DisplayName("Confirm Password: ")]
        [Required(ErrorMessage = "This field is Required!")]
        public string ConfirmPassword { get; set; }
    }
}
