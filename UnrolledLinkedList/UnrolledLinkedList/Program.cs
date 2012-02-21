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
			ICollection<int> list = new UnrolledLinkedList<int>(5);

            for (int i = 0; i < 15; i++)
            {
                list.Add(i);
            }
			// test
			Console.WriteLine(list.Print());
            Console.ReadLine();
		}
	}   
}