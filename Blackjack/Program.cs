using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Blackjack
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("Blackjack");
            var money = 100;

            string response;
            do
            {
                Console.WriteLine($"Money: ${money}\n------------------");
                money = await PlayRound(money);
                Console.WriteLine("\nWould you like to play again? Type 'exit' to end game");
                response = Console.ReadLine().Trim().ToLower();
            } while (response != "exit" && money > 0);
            
            if (money <= 0)
            {
                Console.WriteLine("You're out of money");
            }

            Console.WriteLine("Goodbye");

        }

        static async Task<int> PlayRound(int money)
        {
            Deck deck = new Deck();
            var player = new Player(deck);
            var dealer = new Player(deck);

            Console.Write("\nPlayer's Hand:  ");
            player.DisplayHand();
            Console.Write("\nDealer's Hand:  ");
            dealer.DealerDisplay();

            if (player.Total == 21)
            {
                player.DisplayHand();
                dealer.DealerDisplay();
                Console.WriteLine("\nBlackjack!");
                return money + 5;
            }

            bool playerBust = PlayerTurn(deck, player, dealer);
            bool dealerBust;
            if (playerBust)
            {
                Console.WriteLine("\nBust.");
                return money - 5;
            } 
            else
            {
                dealerBust = await DealerTurn(deck, player, dealer);
            }

            Console.WriteLine("\nFinal hands: ");

            Console.Write("\nPlayer's Hand:  ");
            player.DisplayHand();
            Console.Write("\nDealer's Hand:  ");
            dealer.DisplayHand();

            await Task.Delay(3000);

            if (player.Total > dealer.Total || dealerBust)
            {
                Console.WriteLine("\nYou win!");
                return money + 5;
            } 
            else
            {
                Console.WriteLine("\nYou lose.");
                return money - 5;
            }

        }

        static bool PlayerTurn(Deck deck, Player player, Player dealer)
        {
            Console.WriteLine("\nPlayer's turn: ");
            string response;
            do
            {
                Console.Write("\nWhat would you like to do? ");
                response = Console.ReadLine().ToLower().Trim();

                if (response != "hit" && response != "stand")
                {
                    Console.WriteLine("Invalid response. Please type 'hit' to get another card or 'stand' to stay at current total.");
                    Console.ReadLine();
                }

                if (response == "hit")
                {
                    player.Hit(deck);

                    Console.Write("\nPlayer's Hand:  ");
                    player.DisplayHand();
                    Console.Write("\nDealer's Hand:  ");
                    dealer.DealerDisplay();

                    if (player.Total > 21)
                    {
                        return true;
                    }
                }
                
            } while (response != "stand");
            return false;
        }

        static async Task<bool> DealerTurn(Deck deck, Player player, Player dealer)
        {
            Console.WriteLine("\nDealer's Turn: ");
            Console.Write("\nPlayer's Hand:  ");
            player.DisplayHand();
            Console.Write("\nDealer's Hand:  ");
            dealer.DisplayHand();
            bool keepPlaying = true;
            do
            {
                if (dealer.Total < 17)
                {
                    Console.WriteLine("\n\nDealer hits");
                    dealer.Hit(deck);
                    Console.Write("\nPlayer's Hand:  ");
                    player.DisplayHand();
                    Console.Write("\nDealer's Hand:  ");
                    dealer.DisplayHand();
                } 
                else if (dealer.Total > 21)
                {
                    Console.WriteLine("\n\nDealer busts");
                    return true;
                }
                else
                {
                    Console.WriteLine("\n\nDealer stands");
                    keepPlaying = false;
                }

                await Task.Delay(3000);
            } while (keepPlaying);
            return false;
        }
    }
}
