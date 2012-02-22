using System;
using System.Collections.Generic;

namespace UnrolledLinkedList
{
    class UnrolledLinkedList<T> : MyList<T>
	{
		ArrayNode<T> head;
		public int arraySize;

		public UnrolledLinkedList(int size)
		{
			this.arraySize = size;
			this.head = new ArrayNode<T>(this.arraySize);
		}


		//!//Add//!//
		public void Add(T data)
		{
			if(head.next != null)
				AddToNextNode(head.next, data);
			else if(head.listSize == arraySize)
				CreateNode(head, data);
			else
				head.Add(data);
		}

		private void AddToNextNode(ArrayNode<T> node, T data)
		{
			if(node.next != null)
				AddToNextNode(node.next, data);
			else if(node.listSize == arraySize)
				CreateNode(node, data);
			else
				node.Add(data);
		}

		/// <summary>
		/// Create new arrayNode
		/// </summary>
		private void CreateNode(ArrayNode<T> location, T data)
		{
			ArrayNode<T > node = new ArrayNode<T>(arraySize);
			location.next = node;
			node.Add(data);
		}


		//!//Insert//!//
		public void Insert(int index, T data)
		{
			if(index < head.listSize)
				head.Insert(index, data, this);
			else
				InsertToIndexOfNode(head, index - head.listSize, data);
		}

		private void InsertToIndexOfNode(ArrayNode<T> node, int index, T data)
		{
			if(index < node.next.listSize)
				node.next.Insert(index, data, this);
			else
				InsertToIndexOfNode(node.next, index - node.next.listSize, data);
		}

        //!//Remove//!//
        public bool Remove(T data)
        {
            var dataFound = head.Remove(data);



            return dataFound;
        } 


		//!//Remove an element of a specific index//!//
		public void RemoveAt(int index)
		{
			index -= 1;
			if(index < head.listSize)
				head.RemoveAt(index, this);
			else
				RemoveIndexOfNode(head, index - head.listSize);
		}

		private void RemoveIndexOfNode(ArrayNode<T> node, int index)
		{
			if(index < node.next.listSize)
				node.next.RemoveAt(index, this);
			else
				RemoveIndexOfNode(node.next, index - node.next.listSize);
		}


		//!//Clear//!//
		public void Clear()
		{
			head = new ArrayNode<T>(arraySize);
		}

		//!//Print//!//
		/// <summary>
		/// returns all data in the list separated by a comma.
		/// </summary>
		/// <returns></returns>
		public string Print()
		{
			string returnValue = head.Print();
			return returnValue.Substring(0, returnValue.Length - 2);
		}

        public bool Contains(T data)
        {
            return head.Contains(data);
        }


		public int Sum()
		{
			return head.CalculateSum();
		}

		public int Count()
		{
			return head.GetListSize();
		}

		public int Average()
		{
			return Sum() / Count();
		}
	}
}