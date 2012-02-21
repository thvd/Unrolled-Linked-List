using System;

namespace UnrolledLinkedList
{
	class ArrayNode<T>
	{
		public ArrayNode<T> next;
		public T[] list;
		public int listSize;

		public ArrayNode(int size)
		{
			list = new T[size];
			this.listSize = 0;
		}

		public void add(T data)
		{
			list [listSize] = data;
			listSize += 1;
		}

		public void insert(int index, T data, UnrolledLinkedList<T> completeList)
		{
			ArrayNode<T> newNode = createNode(completeList);
			for(int i = index; i < listSize; i++) {
				newNode.add(list [i]);
			}
			list [index] = data;
			listSize = index + 1;
		}

		public void remove(int index, UnrolledLinkedList<T> unrolledLinkedList)
		{
			listSize -= 1;
			for(int i = index + 1; i < listSize; i++) {
				list [i] = list [i + 1];
			}
		}

		private ArrayNode<T> createNode(UnrolledLinkedList<T> completeList)
		{
			ArrayNode<T > node = new ArrayNode<T>(completeList.arraySize);
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
			for(int i = 0; i < listSize; i++) {
				int currentvalue = int.Parse(list [i].ToString());
				returnValue += currentvalue;
			}
			if(next != null)
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
			for(int i = 0; i < listSize; i++) {
				returnValue += list [i] + ", ";
			}
			if(next != null)
				returnValue += next.print();

			return returnValue;
		}

		public int getListSize()
		{
			int size = listSize;

			if(next != null)
				size += next.getListSize();

			return size;
		}
	}
}