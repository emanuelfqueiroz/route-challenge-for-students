using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TouristChallenge1.Domain.Models
{
    public class Node
    {
        public string Name { get; private set; }
        public decimal Value { get; set; }

        public Node PreviousNode { get; set; }

        public Node(string name, decimal value = int.MaxValue, Node previousNode = null)
        {
            this.Name = name;
            this.Value = value;
            this.PreviousNode = previousNode;
        }
    }
}
