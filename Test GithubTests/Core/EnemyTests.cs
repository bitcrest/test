using NUnit.Framework;
using System;

namespace Test_Github.Core.Tests
{
    [TestFixture]
    public class EnemyTests
    {
        [TestFixtureTearDown]
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
        public void React_Player_OtherAttacked()
        {
            GameObject go = new Enemy();
            string x = _me.React(go);
            Assert.That(x, Is.EqualTo("Enemy vs Enemy"));
        }

        [Test]
        [ExpectedException(typeof(Exception))]
        public void React_Player_Throws()
        {
            GameObject go = new Player(1);
            _me.React(go);
        }

        [Test]
        [ExpectedException(typeof(Exception))]
        public void React_Unknown_Throws()
        {
            GameObject go = new Unknown();
            _me.React(go);
        }
    }
}