using System;
using System.Collections.Generic;
using System.Linq;

namespace DomainLogic.Utilities
{
    public static class Asserts
    {
        private const string ArgumentCantBeNullMsg = "Argument can't be null";
        private const string ArgumentListCantBeNullOrEmptyMsg = "Argument list can't be null or empty";
        private const string ArgumentCantBeNegativeMsg = "Argument can't be negaitve";
        private const string ArumentCantBeNullOrEmptyStringMsg = "Armgument can't be null of empty string";

        /// <summary>
        /// Checks value is not null
        /// </summary>
        /// <param name="value"></param>
        /// <param name="valueName"></param>
        /// <param name="valueType"></param>
        /// <returns>true or exception</returns>
        public static bool IsNotNull(object value, string valueName = "", string valueType = "")
        {
            if (value == null)
            {
                if (string.IsNullOrEmpty(valueName))
                {
                    throw new ArgumentNullException(ArgumentCantBeNullMsg);
                }
                else
                {
                    throw new ArgumentNullException(valueName, ArgumentCantBeNullMsg);
                }
            }

            return true;
        }

        /// <summary>
        /// Checks list is not null or empty
        /// </summary>
        /// <param name="list"></param>
        /// <param name="listName"></param>
        /// <returns>true or exception</returns>
        public static bool IsNotNullOrEmpty(IList<object> list, string listName = "")
        {
            if (string.IsNullOrEmpty(listName))
            {
                listName = "list";
            }

            IsNotNull(list, listName);

            if (list.Any() == false)
            {
                throw new ArgumentOutOfRangeException(listName, ArgumentListCantBeNullOrEmptyMsg);
            }

            return true;
        }


        public static void IsNotNullOrEmpty(string value, string valueName = "")
        {
            if (string.IsNullOrEmpty(valueName))
            {
                valueName = "string value";
            }

            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentOutOfRangeException(valueName, ArumentCantBeNullOrEmptyStringMsg);
            }
        }


        public static void IsNotNegative(int value, string valueName = "")
        {
            if (value < 0)
                throw new ArgumentOutOfRangeException(valueName, ArgumentCantBeNegativeMsg);
        }

        public static void IsNotNegative(decimal value, string valueName = "")
        {
            if (value < 0)
                throw new ArgumentOutOfRangeException(valueName, ArgumentCantBeNegativeMsg);
        }

        public static void IsNotNullOrEmpty(List<object> entities)
        {
            throw new NotImplementedException();
        }

    }
}


