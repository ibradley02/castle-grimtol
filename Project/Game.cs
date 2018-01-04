using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CastleGrimtol.Project
{
    public class Game : IGame
    {
        public string Response;
        public bool Playing { get; set; }
        public bool FirstTime { get; set; }
        public Room CurrentRoom { get; set; }
        public Player CurrentPlayer { get; set; }
        public List<Room> Rooms { get; set; }

        public void Reset()
        {
            Console.WriteLine("Would you like to play again? (Y/N)");
            var answer = Console.ReadLine();
            if (answer == "y" || answer == "yes")
            {
                Console.Clear();
                Playing = true;
                FirstTime = true;
                Setup();
            }
            else
            {
                Playing = false;
            }
        }
        public void Setup()
        {
            CurrentPlayer = new Player();
            Console.Clear();
            Console.ResetColor();
            Rooms = new List<Room>();

            Room room1 = new Room()
            {
                Description = "You are located in a canyon that exits ahead of you to the North and comes to a dead end farther south. There is a very large orange tree in front of you. The canyon is very orange. The ground is very orange. The dust is very orange. You would be blinded by the sheer vastness of orange if not for your highly calibrated and expensive orange sensors fitted to you by the M.A.R.S., but somehow surrounded by all this orange you find yourself feeling blue. You do not have a blue sensor so you disregard this feeling. ",
                Name = "The Orange Canyon",
                Items = new List<Item>(),
                Exits = new Dictionary<string, Room>()
            };
            Room room2 = new Room()
            {
                Description = "The canyon slowly drops off on either side until a vast orange desert extends ahead of you to the North, East, and West. Sensors detect significant elevation changes to the North. The rendezvous point was North of here, but the M.A.R.S. did not design your rover for traversing mountains... ",
                Name = "The Orange Desert",
                Exits = new Dictionary<string, Room>()
            };

            Room room3 = new Room()
            {
                Description = "After many miles of travel the Mountain range to the North turns to desert. Sensors indicate passage to the rendezvous may be possible without crossing the Mountain now. However, there is a long deep trench seperating this part of the desert from the rendezvous point. Crossing it doesn't seem likely without some sort of bridge.",
                Name = "The Orange Trench",
                Exits = new Dictionary<string, Room>()
            };

            Room room4 = new Room()
            {
                Description = "You travel into a basin with orange Mountains to your East and West. The orange here has a faint musty smell of orange. You notice the orange sand of the desert has become a chalky orange salt. This indicates there was likely water here at some point. Collecting a sample may prove valuable to the C.A.W.I.A.E. The only route is back the way you came.",
                Name = "The Orange Lake",
                Items = new List<Item>(),
                Exits = new Dictionary<string, Room>()
            };

            Room room5 = new Room()
            {
                Description = "After many unremarkable hours crossing the desert the orange around you starts to break, lifting itself to the heavens, forming into a grand orange Mountain. You notice a nice looking rock. Traversing this mountain will likely take several sols and has no guarantee of success.",
                Name = "The Orange Mountain",
                Items = new List<Item>(),
                Exits = new Dictionary<string, Room>()
            };

            Room room6 = new Room()
            {
                Description = "Sensors indicate the temperature to have dropped significantly upon entry into the orange cavern. Even the cold here has an orange sensation to it. Large orange shapes seem to fill the cavern. On closer inspection the shapes form into orange beings of light, positivity, and martian prosperity. The orange martians emit such a powerful force of altruistic wellness that it can be felt even without the requisite sensors from the M.A.R.S. The M.A.R.S. has strict protocols for encountering martian life. Would you like to initiate the protocol? (Y/N)",
                Name = "The Orange Cave",
                Exits = new Dictionary<string, Room>()
            };

            Room room7 = new Room()
            {
                Description = "In a feat of pure robotic athletics the rover careens over the trench and lands smoothly on the other side. the rover skids to a stop facing west in front of a large and ominous orange door. ",
                Name = "The Orange Trench pt. 2",
                Exits = new Dictionary<string, Room>()
            };

            Room room8 = new Room()
            {
                Description = "As the grand orange door swings open on its hinges you are basked in the glow of robotic reverence for your heroic actions documenting mars. Okay, well not really, however you do find the rendezvous point behind the doors and a small metal box for your mars samples.",
                Name = "The Orange End",
                Exits = new Dictionary<string, Room>()
            };

            //ITEMS

            Item Salt = new Item()
            {
                Name = "Salt",
                Description = "Like salt, but more orange.",
            };
            Item Rock = new Item()
            {
                Name = "Rock",
                Description = "A wonderful geological speciman.",
            };
            Item Tree = new Item()
            {
                Name = "Tree",
                Description = "A gigantic orange tree. On mars?",
            };

            //ITEMS
            room4.Items.Add(Salt);
            room5.Items.Add(Rock);
            room1.Items.Add(Tree);
            //EXITS
            room1.Exits.Add("north", room2);
            room2.Exits.Add("south", room1);
            room2.Exits.Add("east", room3);
            room2.Exits.Add("west", room4);
            room2.Exits.Add("north", room5);
            room3.Exits.Add("west", room2);
            // room3.Exits.Add("north", room7);
            // room4.Exits.Add("north", room6);
            room4.Exits.Add("east", room2);
            room5.Exits.Add("south", room2);
            room5.Exits.Add("north", room8);
            // room6.Exits.Add("south", room4);
            // room6.Exits.Add("east", room8);
            // room7.Exits.Add("south", room3);
            // room7.Exits.Add("west", room8);

            CurrentRoom = room1;
        }

        public void Move(string direction)
        {
            if (CurrentRoom.Exits.ContainsKey(direction))
            {
                CurrentRoom = CurrentRoom.Exits[direction];
                CurrentPlayer.Time--;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nError: Sensors detect no viable route in that direction. Please recalculate.");
                Console.ResetColor();
            }
        }

        public void UseItem(string itemName)
        {
            Item item = CurrentPlayer.Inventory.Find(Item => Item.Name.ToLower() == itemName);
            if (item.Name.ToLower() == "tree" && CurrentRoom.Name == "The Orange End")
            {
                WordWrap("\nThe box fizzes for a second after accepting your input. A small card prints out of the box that reads \"Congratulations! You will not be decommisioned today! Your efficiency has been rated at 99% for this task. That is very slightly above average for a robot.\"");
                Reset();
            }
            else if (item.Name.ToLower() == "salt" && CurrentRoom.Name == "The Orange End")
            {
                WordWrap("\nThe box fizzes for a second after accepting your input. A small card prints out of the box that reads \"Congratulations! You will not be decommisioned today! Your efficiency has been rated at 98% for this task. That is average for a robot.\"");
                Reset();

            }
            else if (item.Name.ToLower() == "rock" && CurrentRoom.Name == "The Orange End")
            {
                WordWrap("\nThe box fizzes for a second after accepting your input. A small card prints out of the box that reads \"Congratulations! You will not be decommisioned today! Your efficiency has been rated at 97% for this task. That is below average for a robot. You should feel bad.\"");
                Reset();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nError: Does Not Compute.");
                Console.ResetColor();
            }
        }
        public void TakeItem(string itemName)
        {
            Item item = CurrentRoom.Items.FirstOrDefault(Item => Item.Name.ToLower() == itemName);

            if (item != null)
            {
                CurrentRoom.Items.Remove(item);
                CurrentPlayer.Inventory.Add(item);
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                Console.WriteLine($"\n{item.Name} is placed into the rover's storage.");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nError: Does Not Compute.");
                Console.ResetColor();
            }
        }
        public void UserInventory()
        {
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine("\nRover Storage:");
            foreach (Item item in CurrentPlayer.Inventory)
            {
                if (CurrentPlayer.Inventory.Count > 0)
                {
                    Console.WriteLine($"{item.Name} - {item.Description}");
                }
                else
                {
                    Console.WriteLine("Rover storage is empty");
                }
            }
            Console.ResetColor();
        }
        public string GetUserInput()
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.Write($"\n({CurrentPlayer.Time} Sols). What is your directive:");
            Console.ResetColor();
            return Console.ReadLine();
        }
        public void WordWrap(string text)
        {
            String[] words = text.Split(' ');
            StringBuilder buffer = new StringBuilder();

            foreach (String word in words)
            {
                buffer.Append(word);

                if (buffer.Length >= 80)
                {
                    String line = buffer.ToString().Substring(0, buffer.Length - word.Length);
                    Console.WriteLine(line);
                    buffer.Clear();
                    buffer.Append(word);
                }

                buffer.Append(" ");

            }

            Console.WriteLine(buffer.ToString());
        }
        public void HandleUserInput(string Input)
        {
            if (CurrentPlayer.Time > 0)
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
                    else if (command == "take")
                    {
                        TakeItem(option);
                    }
                    else if (command == "use")
                    {
                        UseItem(option);
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("\nCommand not recognized. Type \"Help\" to see a list of commands.");
                        Console.ResetColor();
                    }
                }
                else if (Input == "scan")
                {
                }
                else if (Input == "take" && CurrentRoom.Items != null)
                {

                }
                else if (Input == "y" || Input == "yes")
                {
                    Reset();
                }
                else if (Input == "n" || Input == "no")
                {
                    Playing = false;
                }
                else if (Input == "inventory")
                {
                    UserInventory();
                }
                else if (Input == "help")
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    WordWrap(@"
Here is a List of Executable Commands:
Help,
Scan,
Go,
Use,
Take,
Inventory,
Reset,
Quit
");
                    Console.ResetColor();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("\nCommand not recognized. Type \"Help\" to see a list of commands.");
                    Console.ResetColor();
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nYou have run out of time. Type reset to play again. Quit to exit.");
                Console.ResetColor();
            }
        }
    }
}
