using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TalentTreeTraversal
{
    class Program
    {
        static void Main(string[] args)
        {
            TalentTreeNode root = new TalentTreeNode("Assassin", true);
            TalentTreeNode rootA = new TalentTreeNode("Bow", true);
            TalentTreeNode rootB = new TalentTreeNode("Throwing Dagger", false);
            TalentTreeNode rootAA = new TalentTreeNode("Double Arrow", false);
            TalentTreeNode rootAB = new TalentTreeNode("Fire Arrow", true);
            TalentTreeNode rootBA = new TalentTreeNode("Fan of Daggers", false);
            TalentTreeNode rootBB = new TalentTreeNode("Poison Dagger", false);

            root.Left = rootA;
            root.Right = rootB;
            rootA.Left = rootAA;
            rootA.Right = rootAB;
            rootB.Left = rootBA;
            rootB.Right = rootBB;

            Console.WriteLine("All abilities:");
            root.ListAllAbilities();
            Console.WriteLine("\nAll known abilites:");
            root.ListKnownAbilities();
            Console.WriteLine("\nAll possible abilites:");
            root.ListPossibleAbilities();
        }
    }
}
