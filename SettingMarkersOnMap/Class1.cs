using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace SettingMarkersOnMap
{
      public class Linkedlist
      {
        public class ListNode<T>
        {
            public readonly T Value;
            public readonly ListNode<T> Next;
            public ListNode(T value, ListNode<T> next)
            {
                Value = value;
                Next = next;
            }
        }

        public static ListNode<T> ReplaceElement<T>(ListNode<T> head, T oldElement, T newElement)
        {
            ListNode<T> currentNode = head;
            ListNode<T> newHead = null;
            ListNode<T> prevNode = null;

            while (currentNode != null)
            {
                if (currentNode.Value.Equals(oldElement))
                {
                    ListNode<T> newNode = new ListNode<T>(newElement, currentNode.Next);

                    if (prevNode != null)
                    {
                        prevNode.Next = newNode;
                    }
                    else
                    {
                        newHead = newNode;
                    }
                    break;
                }

                prevNode = currentNode;
                currentNode = currentNode.Next;
            }

            if (newHead == null)
            {
                newHead = head;
            }

            return newHead;
        }


        // Функция объединения двух списков
        public static ListNode<T> MergeLists<T>(ListNode<T> list1, ListNode<T> list2)
        {
            if (list1 == null)
            {
                return list2;
            }
            if (list2 == null)
            {
                return list1;
            }

            ListNode<T> lastNode = list1;
            while (lastNode.Next != null)
            {
                lastNode = lastNode.Next;
            }
            lastNode.Next = list2;
            return list1;
        }
        
  }
   
}
