using System;
using System.Collections.Generic;
using System.Text;

namespace CastleGrimtol.Project
{
    public class Game : IGame
    {
        public string Response;
        public bool Playing { get; set; }
        public Room CurrentRoom { get; set; }
        public Player CurrentPlayer { get; set; }
        public List<Room> Rooms { get; set; }

        public void Reset()
        {
            Playing = true;
        }
        public void Setup()
        {
            Rooms = new List<Room>();

            Room room1 = new Room()
            {
                Description = "You find yourself in a canyon that exits ahead of you to the North and comes to a dead end farther south. The canyon is very orange. The ground is very orange. The dust is very orange. You would be blinded by the sheer vastness of orange if not for your highly calibrated and expensive orange sensors fitted to you by the C.A.W.I.A.E., but somehow sorrounded by all this orange you find yourself feeling blue. You do not have a blue sensor so you disregard this feeling. ",
                Name = "The Orange Canyon",
                Exits = new Dictionary<string, Room>()
            };
            Room room2 = new Room()
            {
                Description = "The orange canyon slowly drops off in elevation until you find yourself at the beginning of a vast orange plane extending ahead of you to the North, East, and West. Crossing would be quite difficult if you were not designed specifically to cross martian planes. It will be quite easy for you. Of this you are nearly robot certain.",
                Name = "The Orange Desert",
                Exits = new Dictionary<string, Room>()
            };

            Room room3 = new Room()
            {
                Description = "The desert seems to end in front of you. Split down the center with a long deep trench. The orange trench in front of you is quite deep and quite orange. It may be possible for you to jump across although the C.A.W.I.A.E. did not fit you with the necessary instruments to determine your success.",
                Name = "The Orange Trench",
                Exits = new Dictionary<string, Room>()
            };

            Room room4 = new Room()
            {
                Description = "You travel into a basin with orange Mountains to your East and West. The orange here has a faint musty smell of orange. You notice the orange sand of the desert has become a chalky orange salt. This indicates there was likely water here at some point. Collecting a sample may prove valuable to the C.A.W.I.A.E. To the North is an outcropping of rocks which your sensors indicate may contain a cave. Your sensors also indicate this cave is orange.",
                Name = "The Orange Lake",
                Items = new List<Item>(),
                Exits = new Dictionary<string, Room>()
            };

            Room room5 = new Room()
            {
                Description = "After many unremarkable hours crossing the desert the orange around you starts to break, lifting itself to the heavens, forming into a grand orange Mountain. Traversing this mountain will likely take several sols and has no guarantee of success.",
                Name = "The Orange Mountain",
                Exits = new Dictionary<string, Room>()
            };

            Room room6 = new Room()
            {
                Description = "Your sensors indicate the tempature to have dropped significantly upon entry into the orange cavern. Even the cold here has an orange sensation to it. As you continue you come across large orange shapes. On closer inspection the shapes form into orange beings of light, positivity, and goodness. The orange martians emit such a powerful force of altruistic wellness that it can be felt even without the requisite sensors from the C.A.W.I.A.E. The C.A.W.I.A.E. has strict protocols for encountering martian life. Would you like to initiate the protocol? (Y/N)",
                Name = "The Orange Cave",
                Exits = new Dictionary<string, Room>()
            };

            Room room7 = new Room()
            {
                Description = "In a feat of pure robotic athletics your rover careens over the trench and lands smoothly on the other side. Your rover skids to a stop facing west in front of a large and ominous orange door. ",
                Name = "The Orange Trench pt. 2",
                Exits = new Dictionary<string, Room>()
            };

            Room room8 = new Room()
            {
                Description = "As the grand orange door swings open on its hinges you are basked in the glow of robotic reverance for your heroic actions traveling mars. Okay, well not really, however you do find the rendevous point behind the doors and the C.A.W.I.A.E. rates your mission effectiveness at 97% which is actually quite bad for a robot, but hey at least you won't be decommisioned today. Would you like to play again? (Y/N)",
                Name = "The Orange Door",
                Exits = new Dictionary<string, Room>()
            };

            Item Salt = new Item()
            {
                Name = "Orange Salt",
                Description = "Like salt, but more orange",
            };

            //ITEMS
            room4.Items.Add(Salt);
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
            throw new System.NotImplementedException();
        }
        public string GetUserInput()
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.Write("\nWhat is your directive:");
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
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine("\nPrint Inventory here");
                Console.ResetColor();
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
    }
}