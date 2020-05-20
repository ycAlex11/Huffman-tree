using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Asgn
{
    /*the structure of huffman tree nodes, can keep track of children and parents*/
   public class HuffmanNode
    {
        public HuffmanNode Parent { get; set; }
        public HuffmanNode Left { get; set; }
        public HuffmanNode Right { get; set; }
        public char Value { get; set; }
        public int Count { get; set; }

    }
}
