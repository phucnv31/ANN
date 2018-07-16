using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace pinball
{
    public class FileIO
    {
        static string fullPath = AppDomain.CurrentDomain.BaseDirectory + "\\GameState.txt";
        public static void InitState()
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < 5; i++)
            {
                sb.AppendLine("Game[" + i + "]:" + false.ToString());
            }
            try
            {
                File.WriteAllText(fullPath, sb.ToString());
            }
            catch (Exception)
            {

                throw;
            }

        }
        private static bool CanReadFile(string fullPath)
        {
            try
            {
                using (FileStream fileStream = File.Open(fullPath, FileMode.Open, FileAccess.ReadWrite, FileShare.None))
                {
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public static void WriteGameState(int gameIndex, bool isFailed)
        {
            //try
            //{
            //    while (!CanReadFile(fullPath))
            //    {
            //        Thread.Sleep(100);
            //    }
            var fileContent = File.ReadLines(fullPath).ToList();
            var index = fileContent.IndexOf(fileContent.Where(x => x.Contains("Game[" + gameIndex + "]:")).FirstOrDefault());
            fileContent[index] = "Game[" + gameIndex + "]:" + isFailed.ToString();
            File.WriteAllLines(fullPath, fileContent);
            //}
            //catch (IOException)
            //{

            //    throw;
            //}
        }
        public static bool IsAllGameFailed()
        {
            try
            {
                var fileContent = File.ReadLines(fullPath).ToList();
                int failed = 0;
                for (int i = 0; i < fileContent.Count; i++)
                {
                    if (fileContent[i].Split(':')[1] == true.ToString())
                    {
                        failed++;
                    }
                }
                if (failed >= fileContent.Count)
                    return true;
                return false;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
