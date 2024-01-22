namespace MusicSystem.Entities
{
    public class Artists
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public HashSet<SongContributor> SongContributors { get; set; } = new HashSet<SongContributor>();

        public Artists() { }

        public Artists(string name)
        {
            Name = name;
        }
    }
}
