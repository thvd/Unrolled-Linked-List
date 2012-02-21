using System;

namespace UnrolledLinkedList
{
	class UnrolledLinkedList<T> : IList<T>
	{
		ArrayNode<T> head;
		public int arraySize;

		public UnrolledLinkedList(int size)
		{
			this.arraySize = size;
			this.head = new ArrayNode<T>(this.arraySize);
		}


		//!//Add//!//
		public void add(T data)
		{
			if(head.next != null)
				addToNextNode(head.next, data);
			else if(head.listSize == arraySize)
				createNode(head, data);
			else
				head.add(data);
		}

		private void addToNextNode(ArrayNode<T> node, T data)
		{
			if(node.next != null)
				addToNextNode(node.next, data);
			else if(node.listSize == arraySize)
				createNode(node, data);
			else
				node.add(data);
		}

		/// <summary>
		/// Create new arrayNode
		/// </summary>
		private void createNode(ArrayNode<T> location, T data)
		{
			ArrayNode<T > node = new ArrayNode<T>(arraySize);
			location.next = node;
			node.add(data);
		}


		//!//Insert//!//
		public void insert(int index, T data)
		{
			if(index < head.listSize)
				head.insert(index, data, this);
			else
				insertToIndexOfNode(head, index - head.listSize, data);
		}

		private void insertToIndexOfNode(ArrayNode<T> node, int index, T data)
		{
			if(index < node.next.listSize)
				node.next.insert(index, data, this);
			else
				insertToIndexOfNode(node.next, index - node.next.listSize, data);
		}


		//!//Remove//!//
		public void remove(int index)
		{
			index -= 1;
			if(index < head.listSize)
				head.remove(index, this);
			else
				removeIndexOfNode(head, index - head.listSize);
		}

		private void removeIndexOfNode(ArrayNode<T> node, int index)
		{
			if(index < node.next.listSize)
				node.next.remove(index, this);
			else
				removeIndexOfNode(node.next, index - node.next.listSize);
		}


		//!//Clear//!//
		public void clear()
		{
			head = new ArrayNode<T>(arraySize);
		}

		//!//Print//!//
		/// <summary>
		/// returns all data in the list separated by a comma.
		/// </summary>
		/// <returns></returns>
		public string print()
		{
			string returnValue = head.print();
			return returnValue.Substring(0, returnValue.Length - 2);
		}

		public int sum()
		{
			return head.calculateSum();
		}

		public int getListSize()
		{
			return head.getListSize();
		}

		public int average()
		{
			return sum() / getListSize();
		}
	}
}