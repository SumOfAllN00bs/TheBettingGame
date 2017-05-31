using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace TheBettingGame
{
    class Log
    {
        //Default log file
        public static string LogFileName = "TheBettingGame.Log";

        public static void LogWrite(string text)
        {
            try
            {
                using (StreamWriter sw = File.AppendText(LogFileName)) //create log if it doesn't exist and append to it once opened
                {
                    sw.Write(text);
                    sw.WriteLine();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

    }
}
