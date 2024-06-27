using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace WinformCardGame.Card
{
    /// <summary>
    /// Player card original data
    /// </summary>
    public class PlayerCard
    {
        readonly public string Name;
        readonly public int Hp;
        readonly public int Atk;
        public Bitmap ImageLocation
        {
            get
            {
                return new Bitmap(Path.Combine(Application.StartupPath, $"Resources\\Images\\Cards\\Player\\{Name}.png"));
            }
        }
        // ability1
        // ability2

        public PlayerCard(string name, int hp, int atk)
        {
            Name = name;
            Hp = hp;
            Atk = atk;
        }
    }

}
