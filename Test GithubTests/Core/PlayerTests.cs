using NUnit.Framework;
using System;

namespace Test_Github.Core.Tests
{
    [TestFixture]
    public class PlayerTests
    {
        [SetUp]
        public void Setup()
        {
            _me = new Player(10);
        }

        [TearDown]
        public void TearDown()
        {
            _me = null;
        }

        private Player _me;

        [Test(Description = "Test invalid ctor")]
        [ExpectedException(typeof (ArgumentException), ExpectedMessage = "Max Hp must be above zero")]
        public void PlayerInvalidMaxHpTest()
        {
            _me = new Player(0);
        }

        [Test(Description = "Test normal ctor")]
        public void PlayerTest()
        {
            _me = new Player(10);
        }

        [Test]
        public void ReactSpecializationVsEnemyTest()
        {
            GameObject go = new Enemy();
            string x = _me.React(go);
            Assert.That(x, Is.EqualTo("Player vs Enemy"));
        }

        [Test]
        public void ReactSpecializationVsPlayerTest()
        {
            GameObject go = new Player(1);
            string x = _me.React(go);
            Assert.That(x, Is.EqualTo("Player vs Player"));
        }

        [Test]
        [ExpectedException(typeof (Exception))]
        public void ReactSpecializationVsUnknownTest()
        {
            GameObject go = new Unknown();
            string x = _me.React(go);
        }

        [Test]
        public void ReviveTest()
        {
            Assert.AreEqual(1, 1);
        }
    }
}