using System;
using System.Windows.Forms;
using LazniBludgeon.CardGame;

namespace LazniBludgeon
{

    internal static class Program
    {
        /// <summary>
        /// Point d'entrée principal de l'application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Console.WriteLine("Debug Console");
            Application.Run(new Game());
        }
    }

}
