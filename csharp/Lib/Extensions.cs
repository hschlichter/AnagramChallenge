using System.Collections.Immutable;

namespace Anagram
{     
    static class Extensions
    {
        public static ImmutableList<ImmutableList<T>> FixedEvenBatch<T>(this ImmutableList<T> source, int batches)
        {
            var result = ImmutableList.CreateBuilder<ImmutableList<T>>();
            var perBatch = source.Count / batches;
            var remainder = source.Count % batches;
            var currentBatch = 0;
            var batch = ImmutableList.CreateBuilder<T>();
            var counter = 0;
            var leftover = remainder > 0 ? 1 : 0;

            for (var i = 0; i < source.Count; i++)
            {
                batch.Add(source[i]);

                counter++;
                if (counter - leftover >= perBatch)
                {
                    currentBatch++;
                    counter = 0;
                    remainder--;
                    leftover = remainder > 0 ? 1 : 0;

                    result.Add(batch.ToImmutable());
                    batch = ImmutableList.CreateBuilder<T>();
                }
            }

            return result.ToImmutable();
        } 
    }
}