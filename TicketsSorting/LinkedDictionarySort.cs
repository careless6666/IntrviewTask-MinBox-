using System;
using System.Collections.Generic;
using System.Linq;

namespace TicketsSorting
{
    public class LinkedDictionarySort
    {
        public const string NullLinksMessage = "Invalid collection. Collection contains null links";
        public const string RecursiveDependingsMessage = "Recursive dependings!";
        /// <summary>
        ///  5 * O(n)
        /// </summary>
        /// <param name="myLinkedList"></param>
        /// <returns></returns>
        public static Dictionary<string, string> DictionarySort(IReadOnlyDictionary<string, string> myLinkedList)
        {
            if (myLinkedList == null)
                return null;

            string first, last;

            //InvalidData(myLinkedList);

            try
            {
                first = myLinkedList.Keys.Except(myLinkedList.Values).SingleOrDefault();
                last = myLinkedList.Values.Except(myLinkedList.Keys).SingleOrDefault();
            }
            catch (Exception)
            {
                //т.к. из текста задания не ясно являются ли циклические зависимости в для нашего двусвясвязного списка валидными, будем считать что нет
                throw new Exception(NullLinksMessage);
            }

            if (first == null)
                return new Dictionary<string, string>();

            var sorted = new Dictionary<string, string> { { first, myLinkedList[first] } };

            var current = myLinkedList[first];
            for (var i = 0; i < myLinkedList.Count; i++)
            {
                if (current == last)
                    continue;

                sorted.Add(current, myLinkedList[current]);
                current = myLinkedList[current];
            }

            return sorted;
        }

        public static void InvalidData(IReadOnlyDictionary<string, string> dict)
        {
            if(dict != null && dict.Any(x => x.Key == x.Value))
                throw new Exception(RecursiveDependingsMessage);
        }
    }
}
