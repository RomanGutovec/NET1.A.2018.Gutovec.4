using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Algorithms.Interfaces;

namespace Algorithms
{
    /// <summary>
    /// Represents logic of transformation to another view
    /// </summary>
    public static class TransformerCommon
    {
        /// <summary>
        /// transform to another view
        /// </summary>
        /// <exception cref="ArgumentNullException">thrown when source data or logic of transformation is not set</exception>
        /// <typeparam name="TSource">source data to transform</typeparam>
        /// <typeparam name="TResult">result data after transform</typeparam>
        /// <param name="source"></param>
        /// <param name="transformer">method which represents logic for transformation</param>
        /// <returns>result data after transform</returns>
        public static TResult[] Transform<TSource, TResult>(this TSource[] source, Func<TSource, TResult> transformer)
        {
            if (ReferenceEquals(source, null))
            {
                throw new ArgumentNullException($"{nameof(source)} haves null value");
            }

            if (ReferenceEquals(source, null))
            {
                throw new ArgumentNullException($"{nameof(transformer)} haves null value");
            }

            TResult[] result = new TResult[source.Length];
            int i = 0;
            foreach (TSource item in source)
            {
                result[i++] = transformer(item);
            }

            return result;
        }

        /// <summary>
        /// transform to another view
        /// </summary>
        /// <exception cref="ArgumentNullException">thrown when source data or logic of transformation is not set</exception>
        /// <typeparam name="TSource">source data to transform</typeparam>
        /// <typeparam name="TResult">result data after transform</typeparam>
        /// <param name="source"></param>
        /// <param name="transformer">interface method which represents logic for transformation</param>
        /// <returns>result data after transform</returns>
        public static TResult[] Transform<TSource, TResult>(this TSource[] source, ITransform<TSource, TResult> transformer)
        {
            if (ReferenceEquals(source, null))
            {
                throw new ArgumentNullException($"{nameof(source)} haves null value");
            }

            if (ReferenceEquals(source, null))
            {
                throw new ArgumentNullException($"{nameof(transformer)} haves null value");
            }

            return Transform<TSource, TResult>(source, transformer.Transform);
        }
    }
}
