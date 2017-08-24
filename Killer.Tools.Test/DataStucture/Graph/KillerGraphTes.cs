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
            graph.AddVertex("E");
            graph.AddVertex("F");

            var a = graph.Vertexs.First(t => t.VertexValue == "A");
            var b = graph.Vertexs.First(t => t.VertexValue == "B");
            var c = graph.Vertexs.First(t => t.VertexValue == "C");
            var d = graph.Vertexs.First(t => t.VertexValue == "D");
            var e = graph.Vertexs.First(t => t.VertexValue == "E");
            var f = graph.Vertexs.First(t => t.VertexValue == "F");
            graph.AddDirectedEdge(a, b, 5);
            graph.AddDirectedEdge(a, d, 10);
            graph.AddDirectedEdge(a, f, 20);
            graph.AddDirectedEdge(b, a, 5);
            graph.AddDirectedEdge(b, c, 30);
            graph.AddDirectedEdge(c, b, 30);
            graph.AddDirectedEdge(c, d, 26);
            graph.AddDirectedEdge(c, e, 35);
            graph.AddDirectedEdge(d, a, 10);
            graph.AddDirectedEdge(d, c, 26);
            graph.AddDirectedEdge(d, e, 25);
            graph.AddDirectedEdge(e, d, 25);
            graph.AddDirectedEdge(e, c, 35);
            graph.AddDirectedEdge(e, f, 33);
            graph.AddDirectedEdge(f, a, 20);
            graph.AddDirectedEdge(f, e, 33);

            Output();


            graph.DepthTraverse(a, (t) =>
            {
                Console.WriteLine(t.VertexValue + "*");
            });

            graph.NotAllDirectedDepth((t) =>
            {
                Console.WriteLine(t.VertexValue + "-");
            });

            graph.BreadthTraverse(a, (t) =>
            {
                Console.WriteLine(t.VertexValue + "+");
            });


            Console.WriteLine("占行");
            graph.PrimTree(a);
            Console.WriteLine("占行");

            graph.RemoveVertex(d);

            Output();

        }
        public void Output()
        {
            string str = String.Empty;
            foreach (var item in graph.Vertexs)
            {
                if (item.FirstEdge != null)
                {
                    var edge = item.FirstEdge;
                    do
                    {
                        str += $"{item.VertexValue} -> {edge.Vertex.VertexValue}  weight={edge.Weight}\t";
                        edge = edge.Next;
                    } while (edge != null);

                }
                else
                {
                    str = $"{item.VertexValue}";
                }
                Console.WriteLine(str);
                str = string.Empty;
            }
        }
    }

}
