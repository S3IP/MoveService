namespace MoveService.Models
{
    public class Move
    {
        public int Id { get; set; }
        public int Damage { get; set; }
        public int Speed { get; set; }
        public int Accuracy { get; set; }
        public string Name { get; set; } = string.Empty;
        public string MoveType { get; set; } = string.Empty;
    }
}
