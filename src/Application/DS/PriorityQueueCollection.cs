using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TouristChallenge1.Domain.Models;

namespace TouristChallenge1.Application.DS
{
    public class PriorityQueueCollection : LinkedList<Node>
    {
        public void AddNodeWithPriority(Node node)
        {
            if(this.Count == 0)
            {
                this.AddFirst(node);
            } else
            {
                if(node.Value >= this.Last.Value.Value)
                {
                    this.AddLast(node);
                } else
                {
                    for (LinkedListNode<Node> it = this.First; it != null; it = it.Next)
                    {
                        if(node.Value <= it.Value.Value)
                        {
                            this.AddBefore(it, node);
                            break;
                        }
                    }
                }
            }
        }
    

    public bool HasInitial(string initial)
    {
        for (LinkedListNode<Node> it = this.First; it != null; it = it.Next)
        {
            if (it.Value.Name == initial) { return true; }
        }
        return false;
    }


}

}
