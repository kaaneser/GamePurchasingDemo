using System;
using System.Collections.Generic;
using System.Text;

namespace GamePurchasingDemo.Entities
{
    public class Game
    {
        public int Id { get; set; }
        public string gameName { get; set; }
        public int releaseYear { get; set; }
        public double price { get; set; }
    }
}
