using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WerWirdMillionaer
{
    class Game
    {
        //Liste mit allen Fragen
        List<Frage> fragen;

        //anzahl bereits gestellter Fragen
        public int gestellteFragen;

        //Liste gestellter Fragen
        List<int> bereitsGestellteFragen;

        //Random
        Random random;


        public Game(List<Frage> Fragen)
        {
            this.fragen = Fragen;
            gestellteFragen = 0;
            bereitsGestellteFragen = new List<int>();

            random = new Random();

        }

        public void StartGame()
        {
            Console.WriteLine("--- WER WIRD MILLIONAER ---");
            
            // optionaler Begrüßungstext + Erklärung
            Console.WriteLine("");
        }

        /*
         * Gibt einen random index einer Frage aus der Liste zurück, die noch nicht gestellt wurde
         */
        public int RandomFragenIndex()
        {
            int index = random.Next(fragen.Count);

            //solange neuen Index auswählen, bis dieser noch nicht verwendet wurde
            while(bereitsGestellteFragen.Contains(index))
            {
                index = random.Next(fragen.Count);
            }

            return index;
        }

        /*
         * Stellt eine Frage anhand des Indexes in der Liste
         * Fügt die Frage zu der Liste der bereits gestellten Fragen hinzu
         */
        public void FrageStellen(int index)
        {
            Frage frage = fragen[index];

            gestellteFragen++;
            bereitsGestellteFragen.Add(index);

            Console.WriteLine(frage.frage);

            Console.Write(System.Environment.NewLine);

            Console.WriteLine("1: " + frage.antworten[0] + " 2: " + frage.antworten[1]);
            Console.WriteLine("3: " + frage.antworten[2] + " 4: " + frage.antworten[3]);
        }

        /*
         * Überprüft, ob eine Antwort richtig ist und gibt true zurück, wenn ja
         */
        public bool AntwortPruefen(int fragenIndex, int antwort)
        {
            Frage frage = fragen[fragenIndex];

            if(frage.richtigeAntwort == antwort)
            {
                return true;
            }

            return false;
        }

        /*
         * Beendet das Spiel
         */
        public void gameOver()
        {
            Console.WriteLine("Leider Verloren.");

            Console.WriteLine();

            Environment.Exit(0);
            return;
        }
    }
}
