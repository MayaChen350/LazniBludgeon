using System.ComponentModel;
using System.Windows.Forms;

namespace WinformCardGame.Components
{
    public partial class Card : PictureBox
    {
        public Card()
        {
            InitializeComponent();
        }

        public Card(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }
    }
}
