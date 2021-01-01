using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccessLibrary.Extensions
{
    public static class EFQuerryExtensions
    {
        public static IQueryable<T> OrderByRandom<T>(this IQueryable<T> querry)
        {
            Random rng = new Random();
            var skip = (int)(rng.NextDouble() * querry.Count());
            return querry.Skip(skip);
        }
    }
}
