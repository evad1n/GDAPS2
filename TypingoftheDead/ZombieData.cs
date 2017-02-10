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
            StreamReader input = null;
            try
            {
                input = new StreamReader(filename);
                string line;
                while ((line = input.ReadLine()) != null)
                {
                    phrases.Add(line);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error with file: " +e.Message);
            }
            finally
            {
                if (input != null)
                {
                    input.Close();
                }
            }
        }

        public void LoadZombies()
        {
            StreamReader input = null;
            string[] files = Directory.GetFiles("Assets");
            foreach(string file in files)
            {
                if(file.StartsWith("asciiZombie"))
                {
                    try
                    {
                        input = new StreamReader(file);
                        string line;
                        while ((line = input.ReadLine()) != null)
                        {
                            zombies.Add(line);
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Error with file: " + e.Message);
                    }
                    finally
                    {
                        if (input != null)
                        {
                            input.Close();
                        }
                    }
                }
            }
            try
            {
                string line;
                while ((line = input.ReadLine()) != null)
                {
                    phrases.Add(line);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error with file: " + e.Message);
            }
            finally
            {
                if (input != null)
                {
                    input.Close();
                }
            }
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
