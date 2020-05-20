using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Asgn
{   
    /*creat a dictionary sorted the a queue of  Huffmantree's node and has a key with integer */
   
    /*the Huffmantree nodes are put into a priority queue, which keeps them in sorted order with smaller counts at the front of the queue*/
    public class PriorityQueue<HuffmanTreeNode>
    {
        private  SortedDictionary<int, Queue<HuffmanTreeNode>> 

        sortedDictionary = new SortedDictionary<int, Queue<HuffmanTreeNode>>();

        public int Count { get; set; }

        /*  A queue that can enqueue an arbitrary set of items, each are associated with a priority*/
        public void Enqueue(HuffmanTreeNode item, int priority)
        {
            ++Count;


            /* If there is a queue that enqueue the itemm or if there is no queue then it create a new one*/
             
            if (!sortedDictionary.ContainsKey(priority))
            {
                sortedDictionary[priority] = new Queue<HuffmanTreeNode>();
            }
                sortedDictionary[priority].Enqueue(item);
        }

        /*when  you dequeue the item and it  makes sure the lowest priority that are dequeued*/
        public HuffmanTreeNode Dequeue()
        {
            --Count;
            /*get the lowest priority key value's element from the dictionary*/
            var item = sortedDictionary.First();

            if (item.Value.Count == 1)
            {
                sortedDictionary.Remove(item.Key);
            }
            return item.Value.Dequeue();
        }
    }
   
    
}
