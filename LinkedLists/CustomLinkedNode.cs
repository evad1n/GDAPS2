using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedLists
{
    class CustomLinkedNode<T>
    {
        private T data;

        public T Data
        {
            get { return data; }
            set { data = value; }
        }

        public CustomLinkedNode<T> next { get; set; }

    }
}
