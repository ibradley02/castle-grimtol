using System;
using System.Collections.Generic;

namespace CastleGrimtol.Project
{
    public class Game : IGame
    {
        public bool Playing;
        public string Response;
        public Room CurrentRoom { get; set; }
        public Player CurrentPlayer { get; set; }
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
                if (command == "go")
                {
                    if (option == "n" || option == "north")
                    {
                        Move("north");
                    }
                    else if (option == "s" || option == "south")
                    {
                        Move("south");
                    }
                    else if (option == "w" || option == "west")
                    {
                        Move("west");
                    }
                    else
                    {
                        Move("east");
                    }
                }
            }
            else if (Input == "look")
            {
                Console.WriteLine(CurrentRoom.Description);
            }
            else if (Input == "help")
            {
                Console.Clear();
                Console.WriteLine(@"Here is a list of Commands:
                Help,
                Look,
                Use <item>,
                Go <direction>,
                Inspect <item>,
                Take <item>,
                Quit
                ");
            }
            else
            {
                Console.WriteLine("Command not recognized. Type \"Help\" to see a list of commands.");
            }
        }
    }
}