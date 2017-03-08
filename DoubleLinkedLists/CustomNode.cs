using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoubleLinkedLists
{
    class CustomNode<T>
    {
        public CustomNode<T> previous { get; set; }
        public CustomNode<T> next { get; set; }

        public T Data { get; set; }

        //Set previous and next to null on creation 
        public CustomNode(T data)
        {
            this.Data = data;
            previous = null;
            next = null;
        }

    }
}
