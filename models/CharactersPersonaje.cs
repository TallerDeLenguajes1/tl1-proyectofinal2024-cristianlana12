using System.Text.Json.Serialization;


namespace api
{
    public class CharactersPersonaje
    {
        private int id;
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

        [JsonPropertyName("id")]
        public int Id { get => id; set => id = value; }

        [JsonPropertyName("name")]
        public string? Name { get => name; set => name = value; }

        [JsonPropertyName("ki")]
        public string? Ki { get => ki; set => ki = value; }

        [JsonPropertyName("maxKi")]
        public string? MaxKi { get => maxKi; set => maxKi = value; }

        [JsonPropertyName("race")]
        public string? Race { get => race; set => race = value; }

        [JsonPropertyName("gender")]
        public string? Gender { get => gender; set => gender = value; }

        [JsonPropertyName("description")]
        public string? Description { get => description; set => description = value; }

        [JsonPropertyName("image")]
        public string? Image { get => image; set => image = value; }

        [JsonPropertyName("affiliation")]
        public string? Affiliation { get => affiliation; set => affiliation = value; }

        [JsonPropertyName("deletedAt")]
        public object? DeletedAt { get => deletedAt; set => deletedAt = value; }

        [JsonPropertyName("originPlanet")]
        public OriginPlanet? OriginPlanet { get => originPlanet; set => originPlanet = value; }

        [JsonPropertyName("transformations")]
        public List<TransformationPersonaje>? Transformations { get => transformations; set => transformations = value; }
    }
}