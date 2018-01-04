using System.Collections.Generic;

namespace CastleGrimtol.Project
{
    public class Player : IPlayer
    {
        public int Score { get; set; }
        public int Time { get; set; }
        public List<Item> Inventory { get; set; }
        public Player()
        {
            Time = 0;
            Inventory = new List<Item>();
        }
    }
}