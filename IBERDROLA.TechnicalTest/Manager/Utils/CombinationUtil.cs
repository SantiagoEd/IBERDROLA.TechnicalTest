namespace IBERDROLA.TechnicalTest.Manager.Utils
{
    internal static class CombinationUtil
    {
        #region Combination Old
        /*
        internal static IEnumerable<T[]> Combinations<T>(this IEnumerable<T> elements, int k)
        {
            List<T[]> result = new List<T[]>();

            if (k == 0)
            {
                // single combination: empty set
                result.Add(new T[0]);
            }
            else
            {
                int current = 1;
                foreach (T element in elements)
                {
                    // combine each element with (k - 1)-combinations of subsequent elements
                    result.AddRange(elements
                        .Skip(current++)
                        .Combinations(k - 1)
                        .Select(combination => (new T[] { element }).Concat(combination).ToArray())
                        );
                }
            }

            return result;
        }
        */
        #endregion
        internal static IEnumerable<T[]> Combinations<T>(this IEnumerable<T> elements, int k)
            => k == 0 ?
                    new[] { new T[0] } :
                    elements.SelectMany((e, i)
                            => elements.Skip(i + 1)
                                       .Combinations(k - 1)
                                       .Select(c => (new T[] { e })
                                       .Concat(c)
                                       .ToArray()));
    }
}
