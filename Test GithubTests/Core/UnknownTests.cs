using NUnit.Framework;
using System;

namespace Test_Github.Core.Tests
{
    [TestFixture]
    public class UnknownTests
    {
        [SetUp]
        public void Setup()
        {
            _me = new Unknown();
        }

        [TearDown]
        public void TearDown()
        {
            _me = null;
        }

        private Unknown _me;

        [Test]
        [ExpectedException(typeof(Exception))]
        public void React_Player_Throws()
        {
            GameObject go = new Player(1);
            _me.React(go);
        }
    }
}