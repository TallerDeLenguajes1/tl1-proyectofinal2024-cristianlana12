namespace api
{
    public class CharactersPersonaje
    {
        private int id ;
        private string? name;
        private string? ki;
        private string? maxKi;
        private string? race;
        private string? gender;
        private string? description;
        private string? image;
        private string? affiliation;
        private object? deletedAt;
        private OriginPlanet? originPlanet;
        private List<TransformationPersonaje>? transformations;

        public int Id { get => id; set => id = value; }
        public string? Name { get => name; set => name = value; }
        public string? Ki { get => ki; set => ki = value; }
        public string? MaxKi { get => maxKi; set => maxKi = value; }
        public string? Race { get => race; set => race = value; }
        public string? Gender { get => gender; set => gender = value; }
        public string? Description { get => description; set => description = value; }
        public string? Image { get => image; set => image = value; }
        public string? Affiliation { get => affiliation; set => affiliation = value; }
        public object? DeletedAt { get => deletedAt; set => deletedAt = value; }
        public OriginPlanet? OriginPlanet { get => originPlanet; set => originPlanet = value; }
        public List<TransformationPersonaje>? Transformations { get => transformations; set => transformations = value; }
    }
}