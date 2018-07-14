using NeuronDotNet.Core.Backpropagation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pinball
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            for (int i = 0; i < 5; i++)
            {
                var thread= new Thread(App);
                thread.Start();
            }
            Application.Run(new Form1());
        }
        static void App()
        {
            Application.Run(new Form1());
        }
    }
}
