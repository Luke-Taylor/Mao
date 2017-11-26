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

            while (true)
            {

                Console.WriteLine($"The starting card is {game.ActiveCard}");

                Console.WriteLine("Which card would you like to play?");

                for (int i = 0; i < game.Players[0].Hand.Count; i++)
                {
                    Console.WriteLine($"[{i}]: {game.Players[0].Hand[i]}");
                }

                int card = int.Parse(Console.ReadLine());

                Card c = game.Players[0].Hand[card];
                game.Players[0].Hand.RemoveAt(card);
                game.Players[0].Hand.AddRange(game.PlayCard(c));

            }
            
        }
    }
}
