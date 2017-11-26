using System;

namespace Mao.Text
{
    class Program
    {
        static Mao game;

        static void GetPlayers()
        {
            Console.WriteLine("How many players?");
            int players = int.Parse(Console.ReadLine());
            for (int i = 0; i < players; i++)
            {
                Console.WriteLine("Please enter the next player's name");
                string name = Console.ReadLine();
                game.AddPlayer(name);
            }
        }

        static void Main(string[] args)
        {
            game = new Mao();

            Console.WriteLine("Welcome to Mao");
            GetPlayers();

            game.Deal();

            foreach(Player p in game.Players)
            {
                Console.WriteLine($"{p.Name}'s hand:");
                foreach(Card c in p.Hand)
                {
                    Console.WriteLine(c);
                }
            }

            while (true) ;
            
        }
    }
}
