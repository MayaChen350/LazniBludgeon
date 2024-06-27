using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace WinformCardGame.Card
{
    /// <summary>
    /// Secondary card original data
    /// </summary>
    public class SoldierCard
    {
        readonly public string Name;
        readonly public int Hp;
        readonly public int Atk;
        public Bitmap ImageLocation
        {
            get
            {
                return new Bitmap(Path.Combine(Application.StartupPath, $"Resources\\Images\\Cards\\Soldier\\{Name}.png"));
            }
        }
        // ability1

        public SoldierCard(string name, int hp, int atk)
        {
            Name = name;
            Hp = hp;
            Atk = atk;
        }
    }
}
