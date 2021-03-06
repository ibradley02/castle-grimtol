﻿using System;
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
            game.Playing = true;
            game.Setup();
            game.FirstTime = true;

            while (game.Playing == true)
            {
                if (game.FirstTime)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("<-------------------------------Rover Rush: 2049------------------------------->");
                    Console.ResetColor();
                    game.WordWrap("You are the last rover remaining on mars in the year 2049. You have been deemed non-essential by the commision associated with interplanetary automation expenses also known as the C.A.W.I.A.E. The C.A.W.I.A.E. has alloted 6 sols for the recovery of precious data from your time on Mars. Failure to comply with the C.A.W.I.A.E. and arrive at the rendevous point somewhere north of here within 15 sols will result in your decommision.");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("\nType \"Help\" to see a list of commands.");
                    Console.ResetColor();
                    game.FirstTime = false;
                }
                game.WordWrap("\n" + game.CurrentRoom.Description);
                var Input = game.GetUserInput().ToLower();
                if (Input == "reset")
                {
                    Console.Clear();
                    game.Playing = true;
                    game.FirstTime = true;
                    game.Setup();
                    continue;
                }
                else if (Input == "q" || Input == "quit")
                {
                    game.Playing = false;
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

