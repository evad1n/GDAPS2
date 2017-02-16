using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace TypingoftheDead
{
    class ZombieData
    {
        List<string> zombies;
        List<string> phrases;
        Random rand = new Random();

        //Load list of phrases to be typed
        public void LoadPhrases(string filename)
        {
            phrases = new List<string>();
            StreamReader input = new StreamReader(filename);
            if (input != null)
            {
                string line;
                while ((line = input.ReadLine()) != null)
                {
                    phrases.Add(line);
                }
                input.Close();
            }
            else
            {
                throw new FileNotFoundException("The file could not be found", filename);
            }


        }

        //Load zombie ascii art
        public void LoadZombies()
        {
            zombies = new List<string>();
            StreamReader input = null;
            string[] files = Directory.GetFiles("../Debug");
            if (files != null)
            {
                foreach (string file in files)
                {
                    if (file.Contains("asciiZombie"))
                    {
                        input = new StreamReader(file);
                        string full = "";
                        string line = null;
                        while ((line = input.ReadLine()) != null)
                        {
                            full += line + "\n";
                        }
                        zombies.Add(full);
                        input.Close();
                    }
                }
            }
            else
            {
                throw new FileNotFoundException("No files in that directory", "Debug");
            }
        }

        //Returns a random phrase from the list of loaded of phrases
        public string RandomPhrase()
        {
            return phrases[rand.Next(phrases.Count)];
        }

        //Returns a random zombie ascii art from the list of loaded zombies
        public string RandomZombie()
        {
            return zombies[rand.Next(zombies.Count)];
        }
    }
}
