using System.Collections.Generic;

namespace CastleGrimtol.Project
{
    public class Item : IItem
    {
        string IItem.Name { get; set; }
        string IItem.Description { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }    
    }
}