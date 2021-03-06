﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CustomStack
{
    class GameStack : IStack
    {
        string[] list;

        private int count;

        public int Count
        {
            get { return count; }
        }

        public bool IsEmpty
        {
            get { return count == 0; }
        }

        public GameStack(int size)
        {
            list = new string[size];
        }

        public void Push(string s)
        {
            if(count == list.Length)
            {
                throw new IndexOutOfRangeException("The stack is full");
            }
            else
            {
                list[count] = s;
                count++;
            }
        }

        public string Pop()
        {
            if(count > 0)
            {
                string temp = list[count - 1];
                count--;
                return temp;
            }
            else
            {
                return null;
            }
        }

        public string Peek()
        {
            return list[count - 1];
        }
    }
}
