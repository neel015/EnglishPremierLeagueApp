namespace EnglishPremierLeague.Domain.Entities
{
    public class Person
    {
        public int Age { get; set; }
        public string Name { get; set; }
        public int CountryId { get; set; }
        public Country Origin { get; set; }

    }
}
