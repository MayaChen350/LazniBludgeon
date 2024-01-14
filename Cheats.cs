using System;
using System.Windows.Forms;

namespace LazniCardGame
{
    /// <summary>
    /// THIS IS FOR DEBUG AND TESTING PURPOSES ONLY!
    /// Please set the cheats button to FALSE when doing a release (since visual studio somehow doesn't want to allow it to only appear when it's in 
    /// </summary>
    public partial class Game
    {
        public void TheKiller()
        {
            if (viewedCardPlayer == null)
            {
                viewedCardSoldier.Hp = 0;
            }
            else
            {
                viewedCardPlayer.Hp = 0;
            }
            UpdateCards();
        }
    }
}
