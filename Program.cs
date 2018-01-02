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
            Console.Clear();
            Console.WriteLine(@"You are the last rover remaining on mars in the year 2049. You have been deemed non-essential by the commision associated with interplanetary automation expenses also known as the C.A.W.I.A.E. The C.A.W.I.A.E. has alloted 15 sols for the recovery of precious data from your time on Mars. Failure to comply with the C.A.W.I.A.E. and arrive at the rendevous point within 15 sols will result in your decommision.
            
            ");
            var playing = true;

            while (playing)
            {
                Console.WriteLine(game.CurrentRoom.Description);
                var Input = game.GetUserInput().ToLower();
                if (Input == "q" || Input == "quit")
                {
                    playing = false;
                    continue;
                }
                else
                {
                    game.HandleUserInput(Input);
                }
            }
        }
    }
}
