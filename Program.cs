using System;
using CastleGrimtol.Project;

namespace CastleGrimtol
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var game = new Game();
            game.Setup();
            var playing = true;

            while (playing)
            {
                Console.WriteLine(game.CurrentRoom.Description);
                if (game.GetUserInput().Contains(" "))
                {
                    var choice = game.GetUserInput().Split(' ');
                    var command = choice[0];
                    var option = choice[1];
                    if (command == "q" || command == "quit")
                    {
                        playing = false;
                        continue;
                    }
                    if (option == "n")
                    {
                        game.Move("north");
                    }
                    if (option == "s")
                    {
                        game.Move("south");
                    }
                }
                else
                {
                    Console.WriteLine("I don't know what you want from me. Type \"Help\" to see a list of commands.");
                }
            }
        }
    }
}
