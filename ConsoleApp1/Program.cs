using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using TransportG;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Class1 class1 = new Class1();
            string routier = class1.GetConnect("http://data.metromobilite.fr/api/linesNear/json?x=5.709360123&y=45.176494599999984&dist=1400&details=true ");
            // déserialisation on met dans une variable donnees le résultat de l'opération depuis la ResponseFromServer
            List<StructureJson> donnees = JsonConvert.DeserializeObject<List<StructureJson>>(routier);


            string routes = class1.GetConnect("http://data.metromobilite.fr/api/routers/default/index/routes ");
            List<DataRoute> DonneeRoutes = JsonConvert.DeserializeObject<List<DataRoute>>(routes);
            foreach (DataRoute test in DonneeRoutes)
            {


                Console.WriteLine("\nNom " + " " + test.longName
                    + "\nNom du bus " + " " + test.shortName + "\n"
                    + "\nCouleur du texte" + " " + test.textColor
                    + "\nCouleur" + " " + test.color
                    + "\nId" + " " + test.id
                    + "\nMode" + " " + test.mode
                    + "\nType" + " " + test.type
                    );
                
            }

            //Dans la variable ArretSansDouble les données groupé par nom, on prend le nom une fois (doublon)
            List<StructureJson> ArretSansDouble = donnees.GroupBy(n => n.name).Select(grp => grp.First()).ToList();

            // Ranger et afficher les objets depuis la liste sans doublon 

            foreach (StructureJson donnee in ArretSansDouble)
            {
                /*pour chaque élement de la structureJson dans données on récupère 
                dans la variable donnee, id, nom... et on affiche*/


                Console.WriteLine("\nArrêt" + " " + donnee.name

                    + "\nLongitude " + " " + donnee.lon
                    + "\nLatitude " + " " + donnee.lat + "\n"
                    + "\nLignes" + " " + donnee.id);

                //les lignes de bus comportant un tableau, on refait un foreach
                foreach (string line in donnee.lines)
                {
                    Console.WriteLine("Lignes" + " " + line);
                }

            }

            //Lecture en console 
            Console.Read();
            //Nettoyer le flux et les réponses 

            Console.ReadKey();

        }

    }

}

