using System;
using System.Collections.Generic;

namespace WerWirdMillionaer
{
    class Program
    {
        static void Main(string[] args)
        {
            Reader reader = new Reader();

            //Location angeben
            Console.WriteLine("Dateipfad zu der CSV Datei angeben: ");

            var fileLocation = Console.ReadLine();

            //Überprüfen, ob die Datei vorhanden ist.
            //Solange ein falscher Dateipfad angegeben wird, wird eine Fehlermeldung ausgegeben und der Nutzer kann die file location neu angeben
            while(!reader.openFile(fileLocation))
            {
                Console.WriteLine("Datei nicht gefunden. Bitte erneut den Dateipfad angeben: ");

                fileLocation = Console.ReadLine();
            }

            //Auswählen, ob Spiel starten (1), oder Bearbeitungsmodus, um Fragen hinzuzufügen (2)
            Console.WriteLine("Um das Spiel zu starten 1 drücken. Um die ausgewählte Datei zu bearbeiten 2 drücken.");

            var modiKey = Console.ReadKey().KeyChar;

            int modi = 0;

            //prüfen, ob eine Zahl angegeben wurde
            //Wenn ungültige Zahl (oder ein anderes Zeichen, als ein Zahl) angegeben wurde Fehlermeldung und Aufruf zum erneuten Versuch
            while(modi == 0)
            {
                if (char.IsDigit(modiKey))
                {
                    modi = Int32.Parse(modiKey.ToString());
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine("Ungültige Eingabe. Bitte erneute versuchen: ");

                    modiKey = Console.ReadKey().KeyChar;
                }
            }

            if(modi == 1)
            {
                //Spiel starten

                List<Frage> fragen = new List<Frage>();

                //alle Fragen aus der Datei auslesen und in eine Liste speichern
                for(int i = 0; i < reader.getLinesCount(); i++)
                {
                    var line = reader.readLine(i);

                    //aus der line ein Objekt der Klasse Frage erstellen und dieses der Liste hinzufügen
                    var lineData = line.Split(';');

                    string frage = lineData[0];
                    int richtigeAntwort = Int32.Parse(lineData[lineData.Length - 1]);

                    string[] antworten = new string[lineData.Length - 2];

                    //alle Antowrtmöglichkeiten durchlaufen (-> theoretisch kompatibel mit mehr als 4 Antowrtmöglichkeiten)
                    for(int j = 1; j < lineData.Length - 1; j++)
                    {
                        antworten[j - 1] = lineData[j];
                    }


                    fragen.Add(new Frage(frage, antworten, richtigeAntwort));
                }

                //Game Objekt erstellen mit den ausgelesenen Fragen
                Game game = new Game(fragen);

                game.StartGame();

                //15 fragen stellen
                while(game.gestellteFragen != 15)
                {
                    int fragenIndex = game.RandomFragenIndex();
                    game.FrageStellen(fragenIndex);

                    //auf antwort warten
                    var antwortKey = Console.ReadKey().KeyChar;
                    int antwort = 0;
                    Console.WriteLine();

                    //prüfen, ob Eingabe eine Zahl ist -> wenn nicht GameOver
                    if (char.IsDigit(antwortKey))
                    {
                        antwort = Int32.Parse(antwortKey.ToString());
                    }
                    else
                    {
                        Console.WriteLine("Die Eingabe ist ungültig.");
                        game.gameOver();
                    }

                    //antwort überprüfen
                    var richtigGeantwortet = game.AntwortPruefen(fragenIndex, antwort);

                    if(!richtigGeantwortet)
                    {
                        game.gameOver();
                    }

                    Console.WriteLine("Die Antwort ist richtig!!! Beantwortete Fragen: " + game.gestellteFragen + "/15");
                }

            }
            else if(modi == 2)
            {
                Console.WriteLine("Bearbeitung gestartet");
            }
        }

    }
}
