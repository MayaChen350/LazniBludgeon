using WinformCardGame.CardGame;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace WinformCardGame.Card
{
    /// <summary>
    /// Instance of a secondary card in game
    /// </summary>
    public class SecondaryCard
    {
        private int hp;

        private int atk;

        public string Name;

        public int Hp
        {
            get { return hp; }
            // Hp can't go below 0
            set
            {
                hp = value < 0 ? 0 : value;
#if DEBUG
                Console.WriteLine($"{Name} has {hp}hp.");
#endif
                // Disable cards when their hp reached 0
                if (Dead)
                {
                    CardInGame.Visible = false;
                    Logger.Log($"> {Name} has fainted\r\n");
#if DEBUG
                    Console.WriteLine("Card visibility set to false.");
#endif
                }

#if DEBUG
                Console.WriteLine("-------------------------------");
#endif
            }
        }
        public int Atk
        {
            // Even if ATK will be displayed as 0 if below it, ATK nerfs can still stack
            get { return atk < 0 ? 0 : atk; }
            set { atk = value; }
        }
        public Bitmap ImageLocation;

        public PictureBox CardInGame;

        public bool Used;

        public bool Dead { get => hp == 0; }

        public int RandomStats(int hpOrAtk)
        {
            double random = new Random().Next(-20, 20) * 0.01;
            return (int)(hpOrAtk * (random));
        }
    }
}
