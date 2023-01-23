using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinqToSql.Queries.ObjectModels;

namespace LinqToSql.Queries
{
    /*
     *public static IEnumerable<TSource> Where<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate); 
     *public static IEnumerable<TSource> Where<TSource>(this IEnumerable<TSource> source, Func<TSource, int, bool> predicate);
     */
    public class Q3Where : QBase
    {
        public override void QToObjects()
        {
            IEnumerable<int> ids = Models.items.Where(x => x.Name == "Vlad").Select(x => x.Id);
            Out(ids);

            IEnumerable<A> persons = Models.items.Where(x => x.Name.Contains("Vlad"));
            Out(persons);

            List<int> intList = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            IEnumerable<int> filteredData = intList.Where(num => num > 5);
            Out(filteredData);
            IEnumerable<int> filteredResult = from num in intList
                                              where num > 5
                                              select num;
            Out(filteredResult);

            Func<int, bool> predicate = i => i > 5;
            IEnumerable<int> filtered = intList.Where(predicate);
            Out(filtered);

            IEnumerable<int> filtered2 = intList.Where(num => CheckNumber(num));
            Out(filtered2);

            var OddNumbersWithIndexPosition = intList.Select((el, index) => new { Element = el, Index = index})
            .Where(x => x.Index % 2 != 0)
            .Select(x => new
            {
                Number = x.Element,
                IndexPosition = x.Index
            });

            Out(OddNumbersWithIndexPosition);

            var filtered3 = intList.Where(num => num > 5).Where(num => num % 2 == 0);
            Out(filtered3);
        }

        public static bool CheckNumber(int number)
        {
            if (number > 5)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
