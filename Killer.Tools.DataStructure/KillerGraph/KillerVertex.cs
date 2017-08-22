namespace Killer.Tools.DataStructure.KillerGraph
{
    /// <summary>
    /// 图 中的顶 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class KillerVertex<T>
    {
        public T VertexValue { get; set; }
        public KillerLinkNode<T> FirstEdge { get; set; }
        public bool IsVisited { get; set; }
        public KillerVertex()
        {

        }
        public KillerVertex(T value)
        {
            this.VertexValue = value;
        }
    }
}
