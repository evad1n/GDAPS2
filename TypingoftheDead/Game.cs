using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TypingoftheDead
{
    class Game
    {
        private int score;
        private int lives;
        private ZombieData zombie;

        public Game()
        {
            //Load zombie art and phrases to type
            zombie = new ZombieData();
            zombie.LoadPhrases("phrases.txt");
            zombie.LoadZombies();
        }

        public void PlayGame()
        {
            string currentZombie;
            string currentPhrase;
            int lastAttack;
            int attackTime;
            int index;
            int highScore;

            score = 0;
            lives = 3;
            index = 0;
            lastAttack = 0;

            //Retrieve local high score
            try
            {
                highScore = ReadScore();
            }
            catch
            {
                highScore = 0;
            }

            Console.WriteLine("Welcome to the Typing of the Dead");
            Console.WriteLine("Current High Score: " + highScore);

            //Generate first enemy
            Console.WriteLine("\nA zombie has appeared!");
            currentPhrase = zombie.RandomPhrase();
            currentZombie = zombie.RandomZombie();
            Console.WriteLine(currentZombie);
            Console.WriteLine(currentPhrase);
            
            while (lives > 0)
            {
                //Set time to type in phrase
                attackTime = 5000 - (score * 5);
                //Make sure there is enough time
                if (attackTime < 1500)
                {
                    attackTime = 1500;
                }
                    //Check for key presses
                    while (Console.KeyAvailable)
                {
                    ConsoleKeyInfo key = Console.ReadKey(true);
                    string letter = key.KeyChar.ToString();

                    //If letter is correct
                    if (letter == currentPhrase.Substring(index, 1))
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write(letter);
                        Console.ForegroundColor = ConsoleColor.Gray;

                        //If it is the last letter of the phrase
                        if (index == currentPhrase.Length - 1)
                        {
                            lastAttack = 0;
                            score += 100;
                            Console.WriteLine("\n\nNice job");
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine("Score: " + score);
                            Console.ForegroundColor = ConsoleColor.Gray;

                            //Generate a new enemy
                            Console.WriteLine("\nA zombie has appeared!");
                            currentPhrase = zombie.RandomPhrase();
                            currentZombie = zombie.RandomZombie();
                            Console.WriteLine(currentZombie);
                            Console.WriteLine(currentPhrase);
                            index = 0;
                        }
                        else
                        {
                            index++;
                        }
                    }
                    else
                    {
                        //Incorrect letter
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write(letter);
                        Console.ForegroundColor = ConsoleColor.Gray;
                        index = 0;
                    } 
                }

                System.Threading.Thread.Sleep(50);
                lastAttack += 50;

                //If enough time has passed the zombie attacks
                if(lastAttack > attackTime)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nYou were hit!");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    lives--;
                    Console.WriteLine("You have " + lives + " left!");
                    lastAttack = 0;
                    index = 0;

                    //Generate a new enemy
                    Console.WriteLine("\nA zombie has appeared!");
                    currentPhrase = zombie.RandomPhrase();
                    currentZombie = zombie.RandomZombie();
                    Console.WriteLine(currentZombie);
                    Console.WriteLine(currentPhrase);
                }

            }
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("GAME OVER \nFinal Score: " + score);
            Console.ForegroundColor = ConsoleColor.Gray;
            if (score > highScore)
            {
                Console.WriteLine("You beat the old high score of: " + highScore);
                WriteScore();
            }
        }

        //Reads the high score in from the hiScore.dat file
        public int ReadScore()
        {
            int highScore;
            using (Stream outStream = File.OpenRead("hiScore.dat"))
            {
                BinaryReader output = new BinaryReader(outStream);
                highScore = output.ReadInt32();
            }
            return highScore;
        }

        //Writes a new high score into the hiScore.dat file
        public void WriteScore()
        {
            using (Stream inStream = File.OpenWrite("hiScore.dat"))
            {
                BinaryWriter input = new BinaryWriter(inStream);
                input.Write(score);
            }
        }
    }
}
