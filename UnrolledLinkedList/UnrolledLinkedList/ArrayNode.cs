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

		public void Add(T data)
		{
			list [listSize] = data;
			listSize += 1;
		}

		public void Insert(int index, T data, UnrolledLinkedList<T> completeList)
		{
			ArrayNode<T> newNode = CreateNode(completeList);
			for(int i = index; i < listSize; i++) {
				newNode.Add(list [i]);
			}
			list [index] = data;
			listSize = index + 1;
		}

		public void Remove(int index, UnrolledLinkedList<T> unrolledLinkedList)
		{
			listSize -= 1;
			for(int i = index + 1; i < listSize; i++) {
				list [i] = list [i + 1];
			}
		}

		private ArrayNode<T> CreateNode(UnrolledLinkedList<T> completeList)
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
		public int CalculateSum()
		{
			int returnValue = 0;
			for(int i = 0; i < listSize; i++) {
				int currentvalue = int.Parse(list [i].ToString());
				returnValue += currentvalue;
			}
			if(next != null)
				returnValue += next.CalculateSum();

			return returnValue;
		}

		/// <summary>
		/// Create string with content of all next nodes.
		/// </summary>
		/// <returns></returns>
		public string Print()
		{
			string returnValue = "";
			for(int i = 0; i < listSize; i++) {
				returnValue += list [i] + ", ";
			}
			if(next != null)
				returnValue += next.Print();

			return returnValue;
		}

		public int GetListSize()
		{
			int size = listSize;

			if(next != null)
				size += next.GetListSize();

			return size;
		}

        public bool Contains(T data)
        {
            bool returnValue = false;

            if (next != null)
                returnValue = next.Contains(data);

            for (int i = 0; i < listSize; i++)
            {
                if (list[i].Equals(data))
                    return true;
            }

            return returnValue;
        }
    }
}