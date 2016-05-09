using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using TicketsSorting;
using Assert = NUnit.Framework.Assert;


namespace Tests
{
    [TestClass]
    public class UnitTest
    {
        [TestMethod]
        public void TestCorrectArray()
        {
            var myLinkedList = new Dictionary<string, string>
            {
                {"a", "b"},
                {"c", "d"},
                {"g", "h"},
                {"b", "c"},
                {"d", "e"},
                {"h", "i"},
                {"f", "g"},
                {"i", "j"},
                {"e", "f"}
            };

            var correctList = new Dictionary<string, string>
            {
                {"a", "b"},
                {"b", "c"},
                {"c", "d"},
                {"d", "e"},
                {"e", "f"},
                {"f", "g"},
                {"g", "h"},
                {"h", "i"},
                {"i", "j"}
            };

            var res =  LinkedDictionarySort.DictionarySort(myLinkedList);
            Assert.IsTrue(correctList.SequenceEqual(res));
        }

        [TestMethod]
        public void TestListWithNullsRefs()
        {
            var myLinkedList = new Dictionary<string, string>
            {
                {"a", "b"},
                {"c", "d"},
                {"g", "h"},
            };

            Func<Dictionary<string, string>, Dictionary<string, string>> testDelegate = LinkedDictionarySort.DictionarySort;
            Assert.That(() => testDelegate(myLinkedList), Throws.TypeOf<Exception>()
                .With.Message.EqualTo(LinkedDictionarySort.NullLinksMessage));
        }

        [TestMethod]
        public void NullValue()
        {
            Assert.AreEqual(null, LinkedDictionarySort.DictionarySort(null));
        }

        [TestMethod]
        public void RecursiveData()
        {
            Action <IReadOnlyDictionary<string, string>> testDelegate = LinkedDictionarySort.InvalidData;
            Assert.That(() => testDelegate(new Dictionary<string, string> { { "a", "a"}}), Throws.TypeOf<Exception>()
                .With.Message.EqualTo(LinkedDictionarySort.RecursiveDependingsMessage));
        }
    }
}
