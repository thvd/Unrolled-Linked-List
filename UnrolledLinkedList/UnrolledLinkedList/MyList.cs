using System;

namespace UnrolledLinkedList
{
	interface MyList<T>
	{
		void Add(T data);
		void Insert(int index, T data);
		void RemoveAt(int index);
        bool Remove(T data);
		string Print();
		void Clear();
        bool Contains(T data);
		int Sum();
		int Count();
		int Average();
	}
}