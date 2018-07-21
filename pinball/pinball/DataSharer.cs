using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.IO.MemoryMappedFiles;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace pinball
{
    class DataSharer
    {
        MemoryMappedFile mmf = null;

        public void writeToMemoryMap(pinball.ANN.WeightsInfo weightsInfo)
        {
            const int MMF_MAX_SIZE = 1024*5;
            const int MMF_VIEW_SIZE = 1024*5;

            if (mmf == null)
                mmf = MemoryMappedFile.CreateOrOpen("mmf1", MMF_MAX_SIZE, MemoryMappedFileAccess.ReadWrite);

            MemoryMappedViewStream mmvStream = mmf.CreateViewStream(0, MMF_VIEW_SIZE);

            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(mmvStream, weightsInfo);
            mmvStream.Seek(0, SeekOrigin.Begin);


        }


        public ANN.WeightsInfo getFromMemoryMap()
        {
            const int MMF_VIEW_SIZE = 1024*5;

            ANN.WeightsInfo weightsInfo = null;

            if (mmf == null)
            {
                try
                {
                    mmf = MemoryMappedFile.OpenExisting("mmf1");
                    weightsInfo = new ANN.WeightsInfo();
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.StackTrace);
                    weightsInfo = null;
                    return weightsInfo;
                }
            }

            MemoryMappedViewStream mmvStream = mmf.CreateViewStream(0, MMF_VIEW_SIZE);

            BinaryFormatter formatter = new BinaryFormatter();

            // needed for deserialization
            byte[] buffer = new byte[MMF_VIEW_SIZE];

            if (mmvStream.CanRead)
            {
                mmvStream.Read(buffer, 0, MMF_VIEW_SIZE);

                weightsInfo = (pinball.ANN.WeightsInfo)formatter.Deserialize(new MemoryStream(buffer));
            }
            else
                weightsInfo = null;

            return weightsInfo;
        }
    }
}
