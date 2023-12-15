using System;
using System.Windows.Forms;

namespace LazniCardGame
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
