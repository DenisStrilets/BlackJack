
using BlackJack3.Logics;
using System;
using System.Collections.Generic;
using System.Text;
using BlackJack3.Models.Enums;
 

namespace BlackJack3
{
    class GameLogic
    {
        private DeckLogic playerDeck;

        private DeckLogic dealerDeck;

        private DeckLogic playingDeck;

        private double playerMoney;
        private double playerBet;
        private bool endRound;
        private int response;

        public void InitGame()
        {

            var rnd = new Random();
            Console.WriteLine("Welcome to BlackJack!");
            playingDeck = new DeckLogic(new Deck());

            playingDeck.CreateFullDeck();
            playingDeck.Shuffle();

            playerDeck = new DeckLogic(new Deck());

            dealerDeck = new DeckLogic(new Deck());

            playerMoney = 100.00;
            playerBet = 0;
            endRound = false;

            response = 0;
        }

        public void StartGame()
        {
            var consoleLogic = new ConsoleViewLogic();

            var gameLogic = new GameLogic();

            InitGame();

            while (playerMoney > 0)
            {
                playerBet = consoleLogic.SetBet(playerMoney, playerBet);

                playerDeck.Draw(playingDeck.deck);
                playerDeck.Draw(playingDeck.deck);

                dealerDeck.Draw(playingDeck.deck);
                dealerDeck.Draw(playingDeck.deck);

                while (true)
                {
                    consoleLogic.ShowStartingStatus(playerDeck, dealerDeck);

                    response = consoleLogic.AskHitOrStand();

                    consoleLogic.PlayerHitOrStand(dealerDeck, playingDeck, playerDeck, playerMoney, playerBet, endRound, response);

                    if (response == 2 | playerDeck.CardsValue() > 21)
                    {
                        break;
                    }
                }

                consoleLogic.ShowProcessStatus(playerDeck, dealerDeck);

                playerMoney = consoleLogic.ChoseWinner(playerDeck, dealerDeck, playingDeck, playerMoney, playerBet, endRound);

                playerDeck.MoveAllToDeck(playingDeck.deck);
                dealerDeck.MoveAllToDeck(playingDeck.deck);

                consoleLogic.FinishedLine();

                response = consoleLogic.ContinueGame(playerMoney);
                if (response == 1)
                {
                    continue;
                }
                break;
            }
            if (playerMoney <= 0)
            {
                Console.WriteLine("Goodbuy player! You out of money!");
            }

            consoleLogic.FinishedLine();
            Console.ReadKey();
        }
           
    }
        
            
}
