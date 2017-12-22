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
                var Input = game.GetUserInput();
                if (Input.Contains(" "))
                {
                    var choice = Input.Split(' ');
                    var command = choice[0];
                    var option = choice[1];
                    if (option == "n")
                    {
                        game.Move("north");
                    }
                    if (option == "s")
                    {
                        game.Move("south");
                    }
                }
                else if (Input == "q" || Input == "quit")
                {
                    playing = false;
                    continue;
                }
                else
                {
                    Console.WriteLine("I don't know what you want from me. Type \"Help\" to see a list of commands.");
                }
            }
        }
    }
}
