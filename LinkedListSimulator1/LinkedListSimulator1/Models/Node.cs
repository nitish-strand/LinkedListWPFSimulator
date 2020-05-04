using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedListSimulator1.Models
{
    public class Node
    {
        public object data;
        public Node next;
        public Node(object data)
        {
            this.data = data;
            next = null;
        }
    }
}
