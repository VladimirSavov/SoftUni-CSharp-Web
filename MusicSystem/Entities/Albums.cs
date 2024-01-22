using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MusicSystem.Entities
{
    public class Albums
    {
        [Key]
        public int Id { get; set; }
        public int OwnerId { get; set; }
        public string Title { get; set; }
        [ForeignKey("OwnerId")]
        public Users Owner { get; set; }
        public Albums() { }

        public Albums(string title)
        {
            Title = title;
        }
        
    }
}
