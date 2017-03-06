using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TalentTreeTraversal
{
    class TalentTreeNode
    {
        string name;
        bool learned;

        public TalentTreeNode Left { get; set; }
        public TalentTreeNode Right { get; set; }
        public TalentTreeNode(string name, bool learned)
        {
            this.name = name;
            this.learned = learned;
            Left = null;
            Right = null;
        }

        public void ListAllAbilities()
        {
            if (Left != null)
                Left.ListAllAbilities();
            Console.WriteLine(name);
            if (Right != null)
                Right.ListAllAbilities();
        }

        public void ListKnownAbilities()
        {
            if (learned)
            {
                Console.WriteLine(name);
                if (Left != null)
                    Left.ListKnownAbilities();
                if (Right != null)
                    Right.ListKnownAbilities();
            }
        }

        public void ListPossibleAbilities()
        {
            if (learned)
            {
                if (Left != null)
                    Left.ListPossibleAbilities();
                if (Right != null)
                    Right.ListPossibleAbilities();
            }
            else
            {
                Console.WriteLine(name);
            }
        }
    }
}
