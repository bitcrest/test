using NUnit.Framework;
using System;

namespace Test_Github.Core.Tests
{
    [TestFixture]
    public class EnemyTests
    {
        [TearDown]
        public void TearDown()
        {
            _me = null;
        }

        [TestFixtureSetUp]
        public void Setup()
        {
            _me = new Enemy();
        }

        private Enemy _me;

        [Test]
        [ExpectedException(typeof(Exception))]
        public void ReactSpecializationVsPlayerTest()
        {
            GameObject go = new Player(1);
            string x = _me.React(go);
        }
    }
}