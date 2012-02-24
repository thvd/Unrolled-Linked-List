using System;
using System.Collections.Generic;

namespace UnrolledLinkedList
{
    class UnrolledLinkedList<T> : IList<T>
	{
		private ArrayNode<T> head;
		private int arraySize;

		public UnrolledLinkedList(int size)
		{
			this.arraySize = size;
			this.head = new ArrayNode<T>(this.arraySize);
		}

        public int Length 
        {
            get 
            {
                return this.arraySize;
            }
        }

		//!//Add//!//
		public void Add(T data)
		{
			if(head.next != null)
				AddToNextNode(head.next, data);
			else if(head.pointer == arraySize)
				CreateNode(head, data);
			else
				head.Add(data);
		}

		private void AddToNextNode(ArrayNode<T> node, T data)
		{
			if(node.next != null)
				AddToNextNode(node.next, data);
			else if(node.pointer == arraySize)
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
			if(index < head.pointer)
				head.Insert(index, data, this);
			else
				InsertToIndexOfNode(head, index - head.pointer, data);
		}

		private void InsertToIndexOfNode(ArrayNode<T> node, int index, T data)
		{
			if(index < node.next.pointer)
				node.next.Insert(index, data, this);
			else
				InsertToIndexOfNode(node.next, index - node.next.pointer, data);
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
			if(index < head.pointer)
				head.RemoveAt(index, this);
			else
				RemoveIndexOfNode(head, index - head.pointer);
		}

		private void RemoveIndexOfNode(ArrayNode<T> node, int index)
		{
			if(index < node.next.pointer)
				node.next.RemoveAt(index, this);
			else
				RemoveIndexOfNode(node.next, index - node.next.pointer);
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
			string returnValue = head.ToString();
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
			return head.GetPointer();
		}

		public int Average()
		{
			return Sum() / Count();
		}

        public int IndexOf(T item)
        {
            throw new NotImplementedException();
        }

        public T this[int index]
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }


        public void CopyTo(T[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        int ICollection<T>.Count
        {
            get { throw new NotImplementedException(); }
        }

        public bool IsReadOnly
        {
            get { throw new NotImplementedException(); }
        }

        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}