using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    public static class ExtensionTransformerCommon
    {
        public static TSource[] Filter<TSource>(this TSource[] number, Predicate<TSource> predicate)
        {
            List<TSource> result = new List<TSource>();
            for (int i = 0; i < number.Length; i++)
            {
                if (predicate(number[i]))
                {
                    result.Add(number[i]);
                }
            }

            return result.ToArray();
        }

        public static TSource[] Filter<TSource>(this TSource[] number, IPredicate<TSource> predicate)
        {
            if (ReferenceEquals(number, null))
            {
                throw new ArgumentNullException($"Source data {nameof(number)} haves null value");
            }

            if (number.Length == 0)
            {
                throw new ArgumentNullException($"Source array {nameof(number)} is empty");
            }

            if (ReferenceEquals(predicate, null))
            {
                throw new ArgumentNullException($"Source condition {nameof(predicate)} haves null value");
            }

            return Filter<TSource>(number, predicate.Condition);
        }
    }
}
