using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Microsoft.CodeAnalysis.Sarif.Driver;
using LazniBludgeon.Card;

namespace LazniBludgeon.CardGame
{

    public partial class Game
    {
        int numberOfP2CardsAlive;

        IList<SecondaryCard> cardChosenByOpponent;

        int[] indexesOpponentAttacks;

        // # of pattern the opponent will use when using its secondary card during the game
        public int noOpponentPlay;

        private void OpponentTurn()
        {
            // Fish for new cards if all secondary cards have died
            if (!p2SecondaryCard1.Visible && !p2SecondaryCard2.Visible && !p2SecondaryCard3.Visible)
                RetrieveCards(p2SecCardsData, p2SecCards, false);

#if DEBUG
            Console.WriteLine("Opponent turn started.");
            Console.WriteLine("-------------------------------");
#endif
            // Which cards each opponent cards will attack
            cardChosenByOpponent = p1SecCardsData.Shuffle();

            // Calculate the number of p2 cards
            numberOfP2CardsAlive = HowManyp2CardLeft();

            // List the indexes of the cards which can be attacked
            indexesOpponentAttacks = CardAttackedIndexes();

            // Player card
            AttackCardCalculation(p2PlayerCardData, p1PlayerCardData);

            // Secondary cards (depends of which attack pattern the opponent uses)
            if (p1SecondaryCard1.Visible && p1SecondaryCard2.Visible && p1SecondaryCard3.Visible)
                switch (noOpponentPlay)
                {
                    case 0:
                        AttackEachCardSeperately();
                        break;
                    case 1:
                        AttachEachCardAtATime();
                        break;
                    case 2:
                        AlternateBetweenEach();
                        break;
                }
            else
                AttackPlayerCard();
            DetermineIfWinner();
        }

        private int HowManyp2CardLeft()
        {
            int count = 0;
            foreach (SecondaryCard card in p2SecCardsData)
                count += card.Hp > 0 ? 1 : 0;
            return count;
        }

        /// <summary>
        /// Filter the indexes of the player's cards which have greater than 0hp.
        /// Note that the original indexes are shuffled and then not directly linked to the position of the cards
        /// </summary>
        /// <returns>An array of integers for each card's index</returns>
        private int[] CardAttackedIndexes()
        {
            int[] indexes = new int[3];
            for (int i = 0; i < numberOfP2CardsAlive; i++)
            {
                if (cardChosenByOpponent[i].Hp <= 0)
                {
                    for (int j = 0; j < 3; j++)
                        if (cardChosenByOpponent[j].Hp > 0)
                        {
                            indexes[i] = j;
                            break;
                        }
                }
                else
                    indexes[i] = i;
            }
#if DEBUG
            Console.Write("Opponent cards will attack:");
            for (int i = 0; i < numberOfP2CardsAlive - 1; i++)
                Console.Write($" {indexes[i]}");
            Console.WriteLine($" {indexes[numberOfP2CardsAlive - 1]}");
            Console.WriteLine("-------------------------------");
#endif
            return indexes;
        }

        private void AttackEachCardSeperately()
        {
            int[] indexes = CardAttackedIndexes();
            for (int i = 0; i < indexesOpponentAttacks.Length; i++)
                AttackCardCalculation(p2SecCardsData[i], cardChosenByOpponent[indexesOpponentAttacks[i]]);

        }

        private void AttachEachCardAtATime()
        {
            for (int i = 0; i < indexesOpponentAttacks.Length; i++)
                AttackCardCalculation(p2SecCardsData[i], cardChosenByOpponent[indexesOpponentAttacks[0]]);
        }

        private void AlternateBetweenEach()
        {
            switch (random.Next(2))
            {
                case 0:
                    AttackEachCardSeperately();
                    break;
                case 1:
                    AttachEachCardAtATime();
                    break;
            }
        }

        private void AttackPlayerCard()
        {

        }
    }
}
