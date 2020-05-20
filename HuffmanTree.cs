using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Asgn
{
    internal class HuffmanTree
    {
        private HuffmanNode root;
        public HuffmanTree(IEnumerable<KeyValuePair<char, int>> counts)
        {
            var priorityQueue = new PriorityQueue<HuffmanNode>();

            /*loop for  kvp in counts and enqueues a new huffmantree node with its frequency */
            foreach (KeyValuePair<char, int> kvp in counts)
            {
                priorityQueue.Enqueue(new HuffmanNode { Value = kvp.Key, Count = kvp.Value }, kvp.Value);
            }

            /* Dequeue the minimum frequencies node */
            /*creat a new node and the two nodes are set as children for the new node*/
            /*loop unit it gets the root node*/
            while (priorityQueue.Count > 1)
            {
                HuffmanNode n1 = priorityQueue.Dequeue();
                HuffmanNode n2 = priorityQueue.Dequeue();
                var n3 = new HuffmanNode { Left = n1, Right = n2, Count = n1.Count + n2.Count };
                n1.Parent = n3;
                n2.Parent = n3;
                priorityQueue.Enqueue(n3, n3.Count);
            }
            root = priorityQueue.Dequeue();
        }
        /*construct a binary representation of the path, it assigns left and right with '0' and '1' respectively */
        private void Encode(HuffmanNode node, string path, IDictionary<char, string> encodings)
        {
            if (node.Left != null)
            {

                Encode(node.Left, path + "0", encodings);
                Encode(node.Right, path + "1", encodings);

            }
            else
            {
                encodings.Add(node.Value, path);
            }
        }
        /* create a dictionary that the symbol is the key */
        public IDictionary<char, string> CreateEncodings()
        {
            var encodings = new Dictionary<char, string>();
            Encode(root, "", encodings);
            return encodings;
        }
    }
}
