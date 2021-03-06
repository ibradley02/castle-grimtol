using System.Collections.Generic;

namespace CastleGrimtol.Project
{
    public class Room : IRoom
    {
        string IRoom.Name { get; set; }
        string IRoom.Description { get; set; }
        List<Item> IRoom.Items { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }    

        public Dictionary<string, Room> Exits { get; set; }
        public List<Item> Items { get; set; }

        public Room()
        {
            Items = new List<Item>();
        }

        void IRoom.UseItem(Item item)
        {
            throw new System.NotImplementedException();
        }
    }
}