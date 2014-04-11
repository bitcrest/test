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
        public void Ctor_NegativeMaxHp_Throws()
        {
            new Player(-10);
        }

        [Test(Description = "Test normal ctor")]
        public void Ctor_PositveMaxHp_Created()
        {
            new Player(10);
        }

        [Test(Description = "Test invalid ctor")]
        [ExpectedException(typeof (ArgumentException), ExpectedMessage = "Max Hp must be above zero")]
        public void Ctor_ZeroMaxHp_Throws()
        {
            new Player(0);
        }

        [Test]
        public void React_Enemy_OtherAttacked()
        {
            GameObject go = new Enemy();
            string x = _me.React(go);
            Assert.That(x, Is.EqualTo("Player vs Enemy"));
        }

        [Test]
        public void React_Player_OtherAttacked()
        {
            GameObject go = new Player(1);
            string x = _me.React(go);
            Assert.That(x, Is.EqualTo("Player vs Player"));

            var p = go as Player;
            p.Hp = 10;
            x = _me.React(go);
            Assert.That(x, Is.EqualTo("Player vs Player"));
        }

        [Test]
        [ExpectedException(typeof (Exception))]
        public void React_Unknown_Throws()
        {
            GameObject go = new Unknown();
            _me.React(go);
        }

        [Test]
        public void Revive_Nil_HpFilled()
        {
            _me.Hp -= 1;
            _me.Revive();
            Assert.AreEqual(_me.Hp, _me.MaxHp);
        }
    }
}