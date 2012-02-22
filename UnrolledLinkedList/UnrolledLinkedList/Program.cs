using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UnrolledLinkedList
{
	class Program
	{
		static void Main (string[] args)
		{
            MyList<int> list = new UnrolledLinkedList<int>(5);

            for (int i = 0; i < 15000; i++)
            {
                list.Add(i);
            }
            Console.Write(list.Sum() + " / ");
            Console.Write(list.Count() + " = ");
            Console.WriteLine(list.Average());
			Console.WriteLine(list.Print());
            Console.ReadLine();
		}
	}   
}