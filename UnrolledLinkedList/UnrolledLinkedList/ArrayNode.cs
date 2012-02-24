using System;

namespace UnrolledLinkedList
{
	class ArrayNode<T>
	{
		public ArrayNode<T> next;
		public T[] list;
		public int pointer;

		public ArrayNode(int size)
		{
			this.list = new T[size];
			this.pointer = 0;
		}

		public void Add(T data)
		{
			this.list[pointer] = data;
			this.pointer += 1;
		}

		public void Insert(int index, T data, UnrolledLinkedList<T> completeList)
		{
			ArrayNode<T> newNode = CreateNode(completeList);
			for (int i = index; i < pointer; i++) 
            {
				newNode.Add(list[i]);
			}
			list[index] = data;
			pointer = index + 1;
		}

        public bool Remove(T data)
        {
            var foundData = false;

            //return Array.Exists(this.list, item => item.Equals(data));
            for (int i = 0; i < pointer; i++)
            {
                if (list[i].Equals(data))
                    return true;
            }

            foundData = next.Remove(data);

            return foundData;
        }

		public void RemoveAt(int index, UnrolledLinkedList<T> unrolledLinkedList)
		{
			pointer -= 1;
			for (int i = index + 1; i < pointer; i++) {
				list[i] = list[i + 1];
			}
		}

		private ArrayNode<T> CreateNode(UnrolledLinkedList<T> completeList)
		{
            ArrayNode<T> node = new ArrayNode<T>(completeList.Length);
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
			for (int i = 0; i < pointer; i++) 
            {
				int currentvalue = int.Parse(list[i].ToString());
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
        public override string ToString()
        {
            T[] arrayWithoutNull = Array.FindAll(this.list, item => item != null);

            string returnValue = String.Join(", ", arrayWithoutNull);

            if (next != null)
                returnValue += next.ToString();

            return returnValue + ((next == null) 
                ? "" 
                : next.ToString());
        }

		public int GetPointer()
		{
            return pointer + ((next == null) 
                ? 0
                : next.GetPointer());
		}

        public bool Contains(T data)
        {
            bool returnValue = false;

            if (next != null)
                returnValue = next.Contains(data);


            if (Array.Exists(this.list, item => item.Equals(data)))
                return true;

            return returnValue;
        }

        public int IndexOf(T data)
        {
            int foundIndex = -1;

            if (next != null) 
            {
                foundIndex = next.IndexOf(data);
            }

            if (foundIndex >= 0) 
            {
                return foundIndex;
            }

            int selfIndex = Array.FindIndex(this.list, item => item.Equals(data));

            return selfIndex;
        }
    }
}