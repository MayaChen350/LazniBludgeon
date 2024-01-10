using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Microsoft.CodeAnalysis.Sarif.Driver;

namespace LazniCardGame
{
    public partial class Game : Form
    {
        // # of pattern the opponent will use when using its secondary card during the game
        public int noOpponentPlay;

        private void OpponentTurn()
        {
#if DEBUG 
            Console.WriteLine("Opponent turn started.");
            Console.WriteLine("-------------------------------");
#endif
            // Which cards each opponent cards will attack
            IList<SecondaryCard> cardChosenByOpponent = p1SecCardsData.Shuffle();


            // Player card
            AttackCardCalculation(p2PlayerCardData, p1PlayerCardData);

            // Secondary cards (depends of which attack pattern the opponent uses)
            switch (noOpponentPlay)
            {
                case 0:
                    AttackEachCardSeperately(cardChosenByOpponent);
                    break;
                case 1:
                    AttachEachCardAtATime(cardChosenByOpponent);
                    break;
                case 2:
                    AlternateBetweenEach(cardChosenByOpponent);
                    break;
            }
            UpdateCards();
        }

        private int HowManyp2CardLeft()
        {
            int count = 0;
            for (int i = 0; i < 3; i++)
                count += p2SecCardsData[i].Hp > 0 ? 1 : 0;
            return count;
        }

        private void AttackEachCardSeperately(IList<SecondaryCard> p1Cards)
        {
            // Secondary Cards
            int numberOfCards = HowManyp2CardLeft();
            for (int i = 0; i < numberOfCards; i++)
                AttackCardCalculation(p2SecCardsData[i], p1Cards[i]);
        }

        private void AttachEachCardAtATime(IList<SecondaryCard> p1Cards)
        {

        }

        private void AlternateBetweenEach(IList<SecondaryCard> p1Cards) { }
    }
}
