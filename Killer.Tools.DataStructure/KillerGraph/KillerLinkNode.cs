namespace Killer.Tools.DataStructure.KillerGraph
{
    /// <summary>
    /// 用户连接边
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class KillerLinkNode<T>
    {
        public KillerVertex<T> Vertex { get; set; }
        public KillerLinkNode<T> Next { get; set; }
        public KillerLinkNode()
        {

        }
        public KillerLinkNode(KillerVertex<T> vertex, KillerLinkNode<T> next)
        {
            this.Vertex = vertex;
            this.Next = next;
        }
    }
}
