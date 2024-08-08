namespace api{
    public class TransformationPersonaje{
        private int id;
        private string? name;
        private string? image;
        private string? ki;
        private object deletedAt;

        public int Id { get => id; set => id = value; }
        public string? Name { get => name; set => name = value; }
        public string? Image { get => image; set => image = value; }
        public string? Ki { get => ki; set => ki = value; }
        public object DeletedAt { get => deletedAt; set => deletedAt = value; }
    }
    
    
}