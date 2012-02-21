using System;

namespace UnrolledLinkedList
{
	interface IList<T>
	{
		void Add(T data);
		void Insert(int index, T data);
		void Remove(int index);
		string Print();
		void Clear();
        bool Contains(T data);
		int Sum();
		int Count();
		int Average();
	}
}