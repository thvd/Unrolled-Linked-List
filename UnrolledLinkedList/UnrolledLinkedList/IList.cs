using System;

namespace UnrolledLinkedList
{
	interface IList<T>
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
}