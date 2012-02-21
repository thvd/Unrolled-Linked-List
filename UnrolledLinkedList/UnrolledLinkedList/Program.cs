using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UnrolledLinkedList
{
    class Program
    {
        static void Main(string[] args)
        {
            iList<int> list = new UnrolledLinkedList<int>(5);
        }
    }

    interface iList<T>
    {
        void add(T data);
        void insert(int index, T data);
        void remove(int index);
        string print();
        void clear();
        int sum();
        int getListSize();
        int average();
    }

    class UnrolledLinkedList<T> : iList<T>
    {
        arrayNode<T> head;
        public int arraySize;

        public UnrolledLinkedList(int size)
        {
            this.arraySize = size;
            head = new arrayNode<T>(arraySize);
        }


        //!//Add//!//
        public void add(T data)
        {
            if (head.next != null)
                addToNextNode(head.next, data);
            else
                if (head.listSize == arraySize)
                    createNode(head, data);
                else
                    head.add(data);
        }

        private void addToNextNode(arrayNode<T> node, T data)
        {
            if (node.next != null)
                addToNextNode(node.next, data);
            else
                if (node.listSize == arraySize)
                    createNode(node, data);
                else
                    node.add(data);
        }

        /// <summary>
        /// Create new arrayNode
        /// </summary>
        private void createNode(arrayNode<T> location, T data)
        {
            arrayNode<T> node = new arrayNode<T>(arraySize);
            location.next = node;
            node.add(data);
        }


        //!//Insert//!//
        public void insert(int index, T data)
        {
            if (index < head.listSize)
                head.insert(index, data, this);
            else
                insertToIndexOfNode(head, index - head.listSize, data);
        }

        private void insertToIndexOfNode(arrayNode<T> node, int index, T data)
        {
            if (index < node.next.listSize)
                node.next.insert(index, data, this);
            else
                insertToIndexOfNode(node.next, index - node.next.listSize, data);
        }


        //!//Remove//!//
        public void remove(int index)
        {
            index -= 1;
            if (index < head.listSize)
                head.remove(index, this);
            else
                removeIndexOfNode(head, index - head.listSize);
        }

        private void removeIndexOfNode(arrayNode<T> node, int index)
        {
            if (index < node.next.listSize)
                node.next.remove(index, this);
            else
                removeIndexOfNode(node.next, index - node.next.listSize);
        }


        //!//Clear//!//
        public void clear()
        {
            head = new arrayNode<T>(arraySize);
        }

        //!//Print//!//
        /// <summary>
        /// returns all data in the list splitted by a comma.
        /// </summary>
        /// <returns></returns>
        public string print()
        {
            string returnValue = head.print();
            returnValue = returnValue.Substring(0, returnValue.Length - 2);
            return returnValue;
        }

        public int sum()
        {
            return head.calculateSum();
        }

        public int getListSize()
        {
            return head.getListSize();
        }

        public int average()
        {
            return sum() / getListSize();
        }
    }

    class arrayNode<T>
    {
        public arrayNode<T> next;
        public T[] list;

        public int listSize;

        public arrayNode(int size)
        {
            list = new T[size];
            this.listSize = 0;
        }

        public void add(T data)
        {
            list[listSize] = data;
            listSize += 1;
        }

        public void insert(int index, T data, UnrolledLinkedList<T> completeList)
        {
            arrayNode<T> newNode = createNode(completeList);
            for (int i = index; i < listSize; i++)
            {
                newNode.add(list[i]);
            }
            list[index] = data;
            listSize = index + 1;
        }

        public void remove(int index, UnrolledLinkedList<T> unrolledLinkedList)
        {
            listSize -= 1;
            for (int i = index + 1; i < listSize; i++)
            {
                list[i] = list[i + 1];
            }
        }

        private arrayNode<T> createNode(UnrolledLinkedList<T> completeList)
        {
            arrayNode<T> node = new arrayNode<T>(completeList.arraySize);
            node.next = this.next;
            this.next = node;

            return node;
        }

        /// <summary>
        /// returns sum of all integers in array
        /// </summary>
        /// <returns></returns>
        public int calculateSum()
        {
            int returnValue = 0;
            for (int i = 0; i < listSize; i++)
            {
                int currentvalue = int.Parse(list[i].ToString());
                returnValue += currentvalue;
            }
            if (next != null)
                returnValue += next.calculateSum();

            return returnValue;
        }

        /// <summary>
        /// Create string with content of all next nodes.
        /// </summary>
        /// <returns></returns>
        public string print()
        {
            string returnValue = "";
            for (int i = 0; i < listSize; i++)
            {
                returnValue += list[i] + ", ";
            }
            if (next != null)
                returnValue += next.print();

            return returnValue;
        }

        public int getListSize()
        {
            int size = 0;

            size += listSize;

            if (next != null)
                size += next.getListSize();

            return size;
        }
    }
}
