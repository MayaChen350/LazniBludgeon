using LazniBludgeon.CardGame;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LazniBludgeon.Card
{
    /// <summary>
    /// Instance of a player card in game
    /// </summary>
    public class MainCard
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
    }
}
