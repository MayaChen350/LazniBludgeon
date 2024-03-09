using System.ComponentModel;
using System.IO;
using System.Windows.Forms;

namespace LazniBludgeon.Components
{
    public partial class GameLogs : TextBox
    {

        public GameLogs()
        {
            InitializeComponent();
        }

        public GameLogs(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        private void InitializeComponent()
        {
            SuspendLayout();
            ResumeLayout(false);

        }

        public override string Text
        {
            get => base.Text;
            set
            {
                // Makes sure that the limit of the gameLogs text box is never reached
                if (Lines.Length == 21)
                {
                    StreamWriter save = new StreamWriter("Logs.txt");

                    for (int i = 0; i < Lines.Length; i++)
                        save.WriteLine(Lines[i]);

                    save.Close();

                    Clear();
                }
                    base.Text = value;
            }
        }
    }
}
