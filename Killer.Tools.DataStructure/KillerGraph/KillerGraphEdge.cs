using System;

namespace Killer.Tools.DataStructure.KillerGraph
{
    /// <summary>
    /// 边
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class KillerGraphEdge<T>:IComparable<KillerGraphEdge<T>>
    {
        public KillerVertex<T> BeginVertex { get; set; }
        public KillerVertex<T> EndVertex { get; set; }
        public int Weight { get; set; }
        public KillerGraphEdge()
        {

        }
        public KillerGraphEdge(int weigth,KillerVertex<T> begin, KillerVertex<T> end)
        {
            this.Weight = weigth;
            this.BeginVertex = begin;
            this.EndVertex = end;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public int CompareTo(KillerGraphEdge<T> other)
        {
            return this.Weight.CompareTo(other.Weight);
        }
    }
}
