using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CERPAlsaceTandem.Helpers
{
    public class FileTmpDebuger
    {
        public static void CheckFile(string path, string id)
        {
            var file = new FileInfo(path);
            FileStream stream = null;
            var inUse = false;

            try
            {
                stream = file.Open(FileMode.Open, FileAccess.Read, FileShare.None);
            }
            catch (IOException)
            {
                inUse = true;               
            }
            finally
            {
                stream?.Close();
            }

            if (inUse)
                Debug.WriteLine(id + " File is in use");
            else
                Debug.WriteLine(id + " File is not in use");

        }
    }
}
