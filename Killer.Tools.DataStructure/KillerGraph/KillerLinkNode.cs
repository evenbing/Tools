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
        /// <summary>
        /// 权重
        /// </summary>
        public int Weight { get; set; }
        public KillerLinkNode()
        {

        }
        public KillerLinkNode(KillerVertex<T> vertex, KillerLinkNode<T> next,int weight=0)
        {
            this.Vertex = vertex;
            this.Next = next;
            this.Weight = weight;
        }
    }
}
