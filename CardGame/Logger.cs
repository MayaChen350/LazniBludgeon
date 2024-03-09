using LazniBludgeon.Components;
using System.Windows.Forms;

namespace LazniBludgeon.CardGame
{
    /// <summary>
    /// The logs in game. It is linked to the gameLogs text box.
    /// </summary>
    public class Logger
    {
        /// <summary>
        /// The text box linked to the logger
        /// </summary>
        private static TextBox logTextBox;

        /// <summary>
        /// Set the logger to a text box
        /// </summary>
        /// <param name="textBox"></param>
        public static void SetLogTextBox(GameLogs textBox)
        {
            logTextBox = textBox;
        }

        /// <summary>
        /// Update the log
        /// </summary>
        /// <param name="message"></param>
        public static void Log(string message)
        {
            logTextBox.Text += message + "\r\n";
        }
    }
}
