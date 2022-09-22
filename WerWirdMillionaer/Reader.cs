using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WerWirdMillionaer
{
    class Reader
    {
        string[] lines;


        public Reader()
        {

        }

        public bool openFile(string fileLocation)
        {
            try
            {
                this.lines = System.IO.File.ReadAllLines(fileLocation);
                return true;
            }
            catch
            {
                //File not found
                return false;
            }
        }

        public string readLine(int index)
        {
            return this.lines[index];
        }

        public int getLinesCount()
        {
            return this.lines.Length;
        }
    }
}
