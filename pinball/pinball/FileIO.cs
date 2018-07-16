using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pinball
{
    public class FileIO
    {
        string fullPath = AppDomain.CurrentDomain.BaseDirectory + "\\GameState.txt";
        public FileIO()
        {
            InitState();
        }
        public void InitState()
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < 5; i++)
            {
                sb.AppendLine("Game["+i+"]:"+false.ToString());
            }
            try
            {
                File.WriteAllText(fullPath, sb.ToString());
            }
            catch (Exception)
            {

                throw ;
            }
           
        }
        public void WriteGameState(int gameIndex,bool isFailed)
        {
            try
            {
                var fileContent = File.ReadLines(fullPath).ToList();
                var index = fileContent.IndexOf(fileContent.Where(x => x.Contains("Game[" + gameIndex + "]:")).FirstOrDefault());
                fileContent[index] = "Game[" + gameIndex + "]:" + isFailed.ToString();
                File.WriteAllLines(fullPath, fileContent);
            }
            catch (IOException)
            {

                throw;
            }
        }
        public bool IsAllGameFailed()
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
