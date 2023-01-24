using LinqToSql.Queries.ObjectModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqToSql.Queries
{
    /*
     * public static IOrderedEnumerable<TSource> OrderBy<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector);
     * public static IOrderedEnumerable<TSource> OrderBy<TSource, TKey>(this IEnumerable<TSource> source, Funct<Source, TKey> keySelector, IComparer<Tkey> comparer);
     */
    public class Q4OrderBy : QBase
    {
        public override void QToObjects()
        {
            IEnumerable<A> ascendedOrder = Models.items.OrderBy(x => x.Name);
            Out(ascendedOrder);

            IEnumerable<B> ascendedOrder2 = from t in Models.items
                                            join b in Models.items2 on t.Id equals b.Id
                                            orderby b.City descending
                                            select b;
            Out(ascendedOrder2);

            IList<A> descendedOrder = Models.items.OrderByDescending(x => x.Email).ToList();
            Out(descendedOrder);

            IEnumerable<A> descendedOrder2 = from t in Models.items
                                             orderby t.Name descending
                                             select t;
            Out(descendedOrder2);

            IEnumerable<A> descendedOrder3 = (from t in Models.items
                                              select t).OrderByDescending(x => x.Name);
            Out(descendedOrder3);

            IEnumerable<A> descendedOrder4 = from t in Models.items
                                             orderby t.Name, t.Email descending
                                             select t;
            Out(descendedOrder4);

            IEnumerable<A> descendedOrder5 = Models.items.OrderBy(x => new { x.Name, x.Email });
            Out(descendedOrder5);

        }
    }
}
