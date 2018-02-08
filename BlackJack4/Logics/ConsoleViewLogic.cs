using System;
using System.Collections.Generic;
using System.Text;

namespace BlackJack3.Logics
{
    class ConsoleViewLogic
    {
        public void FinishedLine()
        {
            Console.WriteLine("\nEnd of hand!");
            Console.WriteLine("\n---------------------------------------------------------------------------------------------");
        }
        public double SetBet(double playerMoney, double playerBet)
        {          
            Console.WriteLine("\nYou have $" + playerMoney + " , how much would you like to bet?");
            
             playerBet = Double.Parse(Console.ReadLine());

            if (playerBet > playerMoney)
            {
                Console.WriteLine("Sorry! Your current cash: $" + playerMoney + ". You cannot bet more than you have. Please bet leaser.");
                Console.WriteLine("\nYou have $" + playerMoney + " , how much would you like to bet?");

                Double.TryParse(Console.ReadLine(), out playerMoney);
            }

            Console.WriteLine("\nDealing...");
            Console.WriteLine("\n---------------------------------------------------------------------------------------------");
            return playerBet;
        }

        public void ShowStartingStatus(DeckLogic playerDeck, DeckLogic dealerDeck)
        {
            Console.WriteLine("\nYour hand:" + (playerDeck.ToString()));
            Console.WriteLine("Your hand is curently valued at: " + playerDeck.CardsValue());

            Console.WriteLine("\nDealer Hand:" + dealerDeck.GetCard(dealerDeck.deck, 0).ToString() + " and[Hidden]");

            Console.WriteLine("\n---------------------------------------------------------------------------------------------");
        }
        
        public void ShowProcessStatus(DeckLogic playerDeck, DeckLogic dealerDeck)
        {
            Console.WriteLine("\nPlayer Cards: " + playerDeck.ToString());

            Console.WriteLine("\nDealer Cards: " + dealerDeck.ToString());

            Console.WriteLine("\nPlayers's Hand is valued at: " + playerDeck.CardsValue());

            Console.WriteLine("\nDealer's Hand is valued at: " + dealerDeck.CardsValue());
        }

        public double ChoseWinner(DeckLogic playerDeck, DeckLogic dealerDeck,DeckLogic playingDeck ,  double playerMoney,  double playerBet,  bool endRound)
        {
            var rnd = new Random();
            
            if ((dealerDeck.CardsValue() > 21) && endRound == false)
            {
                Console.WriteLine("\nDealer busts! You has won. ");
                playerMoney += playerBet;
                endRound = true;

            }

            if ((playerDeck.CardsValue() > 21) && endRound == false)
            {
                Console.WriteLine("\nYou bust! Dealer has won! ");
                playerMoney -= playerBet;
                endRound = true;

            }

            if (dealerDeck.CardsValue() > playerDeck.CardsValue() && endRound == false)
            {
                Console.WriteLine("\nDealer beats you ");
                playerMoney -= playerBet;
                endRound = true;
            }

            if ((dealerDeck.CardsValue() < playerDeck.CardsValue() && endRound == false))
            {
                Console.WriteLine("\nYou has won the hand!");
                playerMoney += playerBet;
                endRound = true;
            }
            else if (endRound == false)
            {
                Console.WriteLine("\nYou has loose the hand!");
                playerMoney -= playerBet;
                endRound = true;
            }

            if ((dealerDeck.CardsValue() == playerDeck.CardsValue()))
            {
                Console.WriteLine("\nPush!");
                endRound = true;
                playerMoney += 0;
            }
            return playerMoney;
        }

        public void DealerHitOrStand(DeckLogic dealerDeck, DeckLogic playingDeck,  double playerMoney, double playerBet ,  bool endRound)
        {
            int response = 0;
            var rnd = new Random();

            while ((dealerDeck.CardsValue() < 17) && endRound == false && response != 2)
            {
                int response_dealer = rnd.Next(1, 3);

                if (dealerDeck.CardsValue() > 21)
                {
                    Console.WriteLine("\nDealer has Bust. Currently valued at: " + dealerDeck.CardsValue() + " You has won");
                    playerMoney += playerBet;
                    endRound = true;
                    break;
                }
       
                if (response_dealer == 1)
                {
                    dealerDeck.Draw(playingDeck.deck);
                    Console.WriteLine("\nDealer was making Hit!");
                    continue;
                }
                if (response_dealer == 2)
                {
                    Console.WriteLine("Dealer was making Stand!");
                    response = response_dealer;
                    break;
                }
            } 
        }

        public int AskHitOrStand()
        {
            Console.WriteLine("\nWould you like to Hit(1) or Stand(2)");
            var result = 0;
            var responsePlayer = Int32.TryParse(Console.ReadLine(), out result);
            Console.WriteLine("\n---------------------------------------------------------------------------------------------");
            return result;
        }

        public void PlayerHitOrStand(DeckLogic dealerDeck, DeckLogic playingDeck, DeckLogic playerDeck,  double playerMoney, double playerBet,  bool endRound ,int response)
        {          
            if (response == 1)
            {
                DealerHitOrStand(dealerDeck, playingDeck,  playerMoney, playerBet,  endRound);
                playerDeck.Draw(playingDeck.deck);
                Console.WriteLine("\nYou draw:" + playerDeck.GetCard(playerDeck.deck, playerDeck.DeckSize() - 1).ToString());               
            }
            if (playerDeck.CardsValue() > 21)
            {
                Console.WriteLine("\nYou has Bust. Currently valued at: " + playerDeck.CardsValue() + " The Dealer has won");
                playerMoney -= playerBet;
                endRound = true;
                
            }

            if (response == 2)
            {
                DealerHitOrStand(dealerDeck, playingDeck,  playerMoney,  playerBet,  endRound);
                Console.Write("\nPlayer has Stand!");
                Console.WriteLine(" ");
               
            }          
        }
       
         public int ContinueGame(double playerMoney)
        {
            Console.WriteLine("\nDo you want to continue Game: Yes(1) or No(2) ?");
            var game = 0;
            var continueGame = Int32.TryParse(Console.ReadLine(), out game);

            //var responsePlayer = Int32.TryParse(Console.ReadLine(), out result);
            if (game == 1)
            {
                Console.Clear();          
            }
            if (game == 2)
            {
                Console.WriteLine("\n---------------------------------------------------------------------------------------------");
                Console.WriteLine("GoodBuy Player! Your total cash is: " + playerMoney);
               
            }
            return game;
        }
    }

    }




        



