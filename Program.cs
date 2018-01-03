using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using CastleGrimtol.Project;

namespace CastleGrimtol
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.SetWindowPosition(0, 0);
            Console.SetBufferSize(400, 600);
            Console.SetWindowSize(80, 40);
            var game = new Game();
            game.Setup();
            Console.Clear();
            Console.ResetColor();

            game.WordWrap("You are the last rover remaining on mars in the year 2049. You have been deemed non-essential by the commision associated with interplanetary automation expenses also known as the C.A.W.I.A.E. The C.A.W.I.A.E. has alloted 15 sols for the recovery of precious data from your time on Mars. Failure to comply with the C.A.W.I.A.E. and arrive at the rendevous point within 15 sols will result in your decommision.");
            var playing = true;

            while (playing)
            {
                game.WordWrap("\n" + game.CurrentRoom.Description);
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
