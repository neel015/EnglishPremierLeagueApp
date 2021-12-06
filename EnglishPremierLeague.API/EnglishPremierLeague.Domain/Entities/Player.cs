namespace EnglishPremierLeague.Domain.Entities
{
    public class Player : Person
    {
        public int PlayerId { get; set; }
        public int GoalsInCareer { get; set; }
        public int? TeamId { get; set; }
        public Team Team { get; set; }

    }
}
