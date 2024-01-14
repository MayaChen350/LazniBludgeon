namespace LazniCardGame
{
    /// THIS IS FOR DEBUG AND TESTING PURPOSES ONLY!
    /// Please set the cheats button to FALSE when doing a release (since visual studio somehow doesn't want to allow it to only appear when it's in 

    public partial class Game
    {
        public void TheKiller()
        {
#if DEBUG
            if (viewedCardPlayer == null)
            {
                viewedCardSoldier.Hp = 0;
            }
            else
            {
                viewedCardPlayer.Hp = 0;
            }
            UpdateCards();
#else
            // CHEATS SHOULD NEVER BE AVAILABLE IN A RELEASE
            throw new System.Exception("Cheats are only available in DEBUG mode.");
            // If this error happens, please set the property Visible of cheatsToolStripMenuItem1 in Game.cs [Design] or set cheatsToolStripMenuItem1.Visible to Game.Designer.cs to FALSE
            // It is generated code, and for some reasons it cannot be changed while running the program, so it's safer to change it the first way
#endif
        }
    }
}
