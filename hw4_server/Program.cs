﻿using System;

namespace hw4_server
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Game Server";

            Server.Start(50, 26950);

            Console.ReadKey();
        }
    }
}
