﻿namespace API.Models
{
    public class Character
    {
        public int Id { get; set; } = 1;
        public string Name { get; set; } = "Peter";
        public int HitPoints { get; set; } = 100;
        public int Strengh { get; set; } = 10;
        public int Defense { get; set; } = 10;
        public int Intelligence { get; set; } = 10;
        public RpgClass Class { get; set; } = RpgClass.knight;

    }
}
