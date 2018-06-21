using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace TransportG
{
    public class Class1
    {
        public String GetConnect(string url)
        {
            //creation de la requete pour l url
            WebRequest request = WebRequest.Create(url);

            //Avoir une réponse
            WebResponse response = request.GetResponse();
            // visualisation du status.  
            Console.WriteLine(((HttpWebResponse)response).StatusDescription);
            //obtenir le contenu du container de flux  retourné par le serveur.  
            Stream dataStream = response.GetResponseStream();
            // Ouvrir le flux en utilisant un Lecteur de flux pour un access facile.  
            StreamReader reader = new StreamReader(dataStream);
            // Lire le contenu  
            string responseFromServer = reader.ReadToEnd();
            // Afficher le contenu.  
            //Console.WriteLine(responseFromServer);
            
            reader.Close();

            response.Close();
            return (responseFromServer);
        }
            }
    }

