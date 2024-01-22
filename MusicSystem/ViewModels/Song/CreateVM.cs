using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace MusicSystem.ViewModels.Song
{
    public class CreateVM 
    {
        [DisplayName("Title: ")]
        [Required(ErrorMessage = "This field is Required!")]
        public string Title { get; set; }
        [DisplayName("Duration(in seconds): ")]
        [Required(ErrorMessage = "This field is Required!")]
        public int Duration { get; set; }
    }
}
