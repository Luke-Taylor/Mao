using System;
using System.Collections.Generic;
using System.Net;

namespace Mao.Text
{
    internal class Program
    {
        private static Mao game;

        private static void GetPlayers()
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

        private static int GetCard(int currentPlayer)
        {
            Console.WriteLine("Which card would you like to play?");

            for (int i = 0; i < game.Players[currentPlayer].Hand.Count; i++)
            {
                Console.WriteLine($"[{i}]: {game.Players[currentPlayer].Hand[i]}");
            }

            return int.Parse(Console.ReadLine());
        }

        private static List<PenaltyItem> PlayCard(int currentPlayer, int card)
        {
            Card c = game.Players[currentPlayer].Hand[card];
            game.Players[currentPlayer].Hand.RemoveAt(card);

            return game.PlayCard(c);
        }

        private static void Main(string[] args)
        {
            int currentPlayer = 0;
            bool reverse = false;
            game = new Mao();

            game.AddRule(new CustomRule("", RuleResponse.ResponseType.Reverse, RuleResponse.ResponseType.Legal, CustomRule.MatchType.Card, new Card(Suit.Clubs, CardValue.Eight)));

            Console.WriteLine("Welcome to Mao");
            GetPlayers();

            game.Deal();

            while (true)
            {
                Console.WriteLine($"{game.Players[currentPlayer].Name}'s turn:");
                Console.WriteLine($"The active card is {game.ActiveCard}");

                var card = GetCard(currentPlayer);

                var outcome = PlayCard(currentPlayer, card);

                foreach (var response in outcome)
                {
                    Console.WriteLine(response.Reason);
                    if (response.Response == RuleResponse.ResponseType.Reverse)
                    {
                        reverse = !reverse;
                    }
                    if (response.Penalty != null)
                    {
                        game.Players[currentPlayer].Hand.Add(response.Penalty);
                    }
                }

                if (reverse)
                {
                    currentPlayer--;
                    if (currentPlayer < 0)
                    {
                        currentPlayer = game.Players.Count - 1;
                    }
                }
                else
                {
                    currentPlayer++;
                    if (currentPlayer == game.Players.Count)
                    {
                        currentPlayer = 0;
                    }
                }
            }
        }
    }
}