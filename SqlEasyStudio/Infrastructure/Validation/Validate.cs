

using System;
using System.Collections.Generic;

namespace SqlEasyStudio.Infrastructure.Validation
{
    public static class Validate
    {
        public static void IsTrue(bool expression)
        {
            IsTrue(expression, "The validated expression is false");
        }

        public static void IsTrue(bool expression, string message)
        {
            if (!expression)
                throw new ArgumentException(message);
        }

        public static void NotEmpty<T>(ICollection<T> collection)
        {
            NotEmpty(collection, "The validated collection is empty");
        }

        public static void NotEmpty<T>(ICollection<T> collection, string message)
        {
            if (collection == null || collection.Count == 0)
                throw new ArgumentException(message);
        }

        public static void NotEmpty(string value)
        {
            NotEmpty(value, "The validated string is empty");
        }

        public static void NotEmpty(string value, string message)
        {
            if (string.IsNullOrEmpty(value))
                throw new ArgumentException(message);
        }

        public static void NotNull(object obj)
        {
            if (obj == null)
                throw new ArgumentException("The validate object is null");
        }

        public static void NotNull(object obj, string message)
        {
            if (obj == null)
                throw new ArgumentException(message);
        }
    }
}
