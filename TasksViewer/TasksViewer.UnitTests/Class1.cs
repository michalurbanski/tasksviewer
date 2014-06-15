using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TasksViewer.UnitTests
{
    [TestFixture]
    public class Class1
    {
        [Test]
        public void Test()
        {
            string a = "string";
            string expected = a;

            Assert.AreEqual(expected, a);
        }

        //Test
    }
}
