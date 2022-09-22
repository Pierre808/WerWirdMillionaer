using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WerWirdMillionaer
{
    public class Frage
    {
        public string frage;
        public string[] antworten;
        public int richtigeAntwort;

        public Frage(string Frage, string[] Antworten, int RichtigeAntwort)
        {
            this.frage = Frage;
            this.antworten = Antworten;
            this.richtigeAntwort = RichtigeAntwort;
        }
    }
}
