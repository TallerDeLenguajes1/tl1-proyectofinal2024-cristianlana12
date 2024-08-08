namespace api
{
    public class OriginPlanet
    {
        private int id;
        private string? name;
        private bool isDestroyed;
        private string? description;

        public int Id { get => id; set => id = value; }
        public string? Name { get => name; set => name = value; }
        public bool IsDestroyed { get => isDestroyed; set => isDestroyed = value; }
        public string? Description { get => description; set => description = value; }
    }
}