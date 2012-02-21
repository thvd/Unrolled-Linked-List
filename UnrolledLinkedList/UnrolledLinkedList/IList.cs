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
		int Sum();
		int GetListSize();
		int Average();
	}
}