using System.ComponentModel;
using System.Windows.Forms;

namespace LazniBludgeon.Components
{
    public partial class LazniCard : PictureBox
    {
        public LazniCard()
        {
            InitializeComponent();
        }

        public LazniCard(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }
    }
}
