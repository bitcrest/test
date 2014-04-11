using System;

namespace Test_Github.Core
{
    public class Player : GameObject
    {
        public Player(int maxHp)
        {
            if (maxHp <= 0) throw new ArgumentException("Max Hp must be above zero");
            MaxHp = maxHp;
        }

        public int Hp { get; set; }

        public int MaxHp { get; private set; }

        public string ReactSpecialization(Player other)
        {
            return "Player vs Player";
        }

        public string ReactSpecialization(Enemy other)
        {
            return "Player vs Enemy";
        }

        public void Revive()
        {
            Hp = MaxHp;
        }

        public override string React(IGameObject other)
        {
            return ReactSpecialization(other as dynamic);
        }
    }
}