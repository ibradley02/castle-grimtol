using System.Collections.Generic;

namespace CastleGrimtol.Project
{
    public class Room : IRoom
    {
        string IRoom.Name { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        string IRoom.Description { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        List<Item> IRoom.Items { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        public string Name { get; set; }
        public string Description { get; set; }    

        public Dictionary<string, Room> Exits { get; set; }    

        void IRoom.UseItem(Item item)
        {
            throw new System.NotImplementedException();
        }
    }
}