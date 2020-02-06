using System;
using System.Collections.Generic;
using System.Linq;

namespace LCMergeKSortedLists
{
    class Program
    {
        static void Main(string[] args)
        {
            ListNode l1 = new ListNode(1);
            l1.next = new ListNode(4);
            l1.next.next = new ListNode(5);

            ListNode l2 = new ListNode(1);
            l2.next = new ListNode(3);
            l2.next.next = new ListNode(4);

            ListNode l3 = new ListNode(2);
            l3.next = new ListNode(6);

            ListNode[] lists = new ListNode[] { l1, l2, l3 };

            ListNode mergedList;

            mergedList = MergeKLists(lists);

            while (mergedList != null)
            {
                Console.WriteLine(mergedList.val);
                mergedList = mergedList.next;
            }

            ListNode MergeKLists(ListNode[] lists)
            {
                ListNode mergedList = new ListNode(0);
                ListNode linkBuilder = mergedList;

                List<int> LLtoList = new List<int>();

                int index = 0;

                while (index < lists.Length)
                {
                    while (lists[index] != null)
                    {
                        LLtoList.Add(lists[index].val);
                        lists[index] = lists[index].next;
                    }
                    index++;
                }

                LLtoList.Sort();

                foreach (var value in LLtoList)
                {
                    linkBuilder.next = new ListNode(value);
                    linkBuilder = linkBuilder.next;
                }

                return mergedList.next;
            }
        }
    }
    
    public class ListNode {
        public int val;
        public ListNode next;
        public ListNode(int x) { val = x; }
    }    
}
