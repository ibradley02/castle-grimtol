using System;
using System.Collections.Generic;

namespace CastleGrimtol.Project
{
    public class Game : IGame
    {
        public bool Playing;
        public string Response;
        public Room CurrentRoom { get; set; }
        public Player CurrentPlayer { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        public List<Room> Rooms { get; set; }

        public void Reset()
        {

        }

        public void Setup()
        {
            Rooms = new List<Room>();

            Room room1 = new Room()
            {
                Description = "This is room 1",
                Name = "Room 1",
                // Items = new List<Item>(),
                Exits = new Dictionary<string, Room>()
            };
            Room room2 = new Room()
            {
                Description = "This is room 2",
                Name = "Room 2",
                // Items = new List<Item>(),
                Exits = new Dictionary<string, Room>()

            };

            room1.Exits.Add("north", room2);
            room2.Exits.Add("south", room1);


            CurrentRoom = room1;
        }

        public void Move(string direction)
        {
            if (CurrentRoom.Exits.ContainsKey(direction))
            {
                CurrentRoom = CurrentRoom.Exits[direction];
            }
            else
            {
                Console.WriteLine("You can't do that.");
            }
        }

        public void UseItem(string itemName)
        {
            throw new System.NotImplementedException();
        }
        public string GetUserInput()
        {
            Console.WriteLine("What would you like to do: ");
            return Console.ReadLine();
        }
        public void HandleUserInput(string Input)
        {
            if (Input.Contains(" "))
            {
                var choice = Input.Split(' ');
                var command = choice[0];
                var option = choice[1];
                if (option == "n")
                {
                    Move("north");
                }
                if (option == "s")
                {
                    Move("south");
                }
            }else
            {
               Console.WriteLine("I don't know what you want from me. Type \"Help\" to see a list of commands.");
            }
        }
    }
}