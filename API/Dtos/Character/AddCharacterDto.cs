using API.Models;

namespace API.Dtos.Character
{
    public class AddCharacterDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = "Peter";
        public int HitPoints { get; set; } = 100;
        public int Strengh { get; set; } = 10;
        public int Defense { get; set; } = 10;
        public int Intelligence { get; set; } = 10;
        public RpgClass Class { get; set; } = RpgClass.knight;
    }
}
