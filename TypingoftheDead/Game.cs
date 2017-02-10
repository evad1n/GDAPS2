using System;
using System.Collections.Generic;
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
            zombie = new ZombieData();
            score = 0;
            lives = 3;
        }

        public void PlayGame()
        {
            string currentZombie;
            string currentPhrase;
            int lastAttack = 0;
            int index;

            zombie.LoadPhrases("Assets/phrases");
            zombie.LoadZombies();

            Console.WriteLine("Welcome to the Typing of the Dead");

            while(lives > 0)
            {
                Console.WriteLine("A zombie has appeared!");
                currentPhrase = zombie.RandomPhrase();
                currentZombie = zombie.RandomZombie();
                Console.WriteLine(currentPhrase);
                Console.WriteLine(currentZombie);

                index = 0;
                //Check for key presses
                while (Console.KeyAvailable)
                {
                    ConsoleKeyInfo key = Console.ReadKey(true);
                    string letter = key.KeyChar.ToString();

                    if (letter == currentPhrase.Substring(index, index + 1))
                    {
                        index++;
                        if(index == currentPhrase.Length - 1)
                        {
                            Console.WriteLine("Nice job");
                        }
                    } 
                }

                System.Threading.Thread.Sleep(50);
                lastAttack += 50;

                //If enough time has passed the zombie attacks
                if(lastAttack > 5000)
                {
                    Console.WriteLine("You were hit!");
                    lives--;
                    lastAttack = 0;
                }

            }
            Console.WriteLine("GAME OVER \nFinal Score: " + score);
        }
    }
}
