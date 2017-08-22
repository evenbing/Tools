using Killer.Tools.DataStructure.KillerGraph;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Killer.Tools.Test.DataStucture.Graph
{
    [TestClass]
    public class KillerGraphTest
    {
        KillerLinkGraph<string> graph;
        [TestInitialize]
        public void Init()
        {
            graph = new KillerLinkGraph<string>();
        }
        [TestMethod]
        public void Test()
        {
            graph.AddVertex("A");
            graph.AddVertex("B");
            graph.AddVertex("C");
            graph.AddVertex("D");

            var a = graph.Vertexs.First(t => t.VertexValue == "A");
            var b = graph.Vertexs.First(t => t.VertexValue == "B");
            var c = graph.Vertexs.First(t => t.VertexValue == "C");
            var d = graph.Vertexs.First(t => t.VertexValue == "D");

            graph.AddDirectedEdge(a, b);
            graph.AddDirectedEdge(a, b);
            graph.AddDirectedEdge(a, c);
            graph.AddDirectedEdge(c, d);
            graph.AddDirectedEdge(b, d);

            string str = String.Empty;
            foreach (var item in graph.Vertexs)
            {
                if (item.FirstEdge != null)
                {
                    var edge = item.FirstEdge;
                    do
                    {
                        str += $"{item.VertexValue} -> {edge.Vertex.VertexValue} \t";
                        edge = edge.Next;
                    } while (edge != null);
                    Console.WriteLine(str);
                    str = string.Empty;
                }
            }

        }
    }
}
