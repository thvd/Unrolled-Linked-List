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
			IList<int> list = new UnrolledLinkedList<int>(5);
			
			
			// test
			Console.WriteLine(list.print());
		}
	}   
}