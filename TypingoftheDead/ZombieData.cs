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
        Random rand;

        public void LoadPhrases(string filename)
        {
            StreamReader sr = new StreamReader(filename);
        }

        public void LoadZombies()
        {

        }

        public string RandomPhrase()
        {
            return phrases[rand.Next(phrases.Count)];
        }

        public string RandomZombie()
        {
            return zombies[rand.Next(zombies.Count)];
        }
    }
}
