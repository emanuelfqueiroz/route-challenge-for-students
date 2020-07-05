using System;
using System.Runtime.Serialization;

namespace Algorithms.ShortestPath.Dijkstra
{
    [Serializable]
    internal class GraphBuilderException : Exception
    {
        public GraphBuilderException()
        {
        }

        public GraphBuilderException(string message) : base(message)
        {
        }

        public GraphBuilderException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected GraphBuilderException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}