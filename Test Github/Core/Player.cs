using System;
using System.Collections.Generic;

namespace Test_Github.Core
{
    public class Player : GameObject
    {
        private static readonly IEqualityComparer<Player> TableHpMaxHpComparerInstance = new TableHpMaxHpEqualityComparer();

        private readonly Dictionary<string, string> table = new Dictionary<string, string>();

        public Player(int maxHp)
        {
            if (maxHp <= 0) throw new ArgumentException("Max Hp must be above zero");
            MaxHp = maxHp;
        }

        public static IEqualityComparer<Player> TableHpMaxHpComparer
        {
            get { return TableHpMaxHpComparerInstance; }
        }

        public int Hp { get; set; }

        public int MaxHp { get; private set; }

        protected bool Equals(Player other)
        {
            return Hp == other.Hp && MaxHp == other.MaxHp && Equals(table, other.table);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((Player)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = Hp;
                hashCode = (hashCode * 397) ^ MaxHp;
                hashCode = (hashCode * 397) ^ (table != null ? table.GetHashCode() : 0);
                return hashCode;
            }
        }

        private string ReactSpecialization(Player other)
        {
            if (other.Hp < 1)
            {
                other.Revive();
            }
            else
            {
                Revive();
            }
            return "Player vs Player";
        }

        private string ReactSpecialization(Enemy other)
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

        private sealed class TableHpMaxHpEqualityComparer : IEqualityComparer<Player>
        {
            public bool Equals(Player x, Player y)
            {
                if (ReferenceEquals(x, y)) return true;
                if (ReferenceEquals(x, null)) return false;
                if (ReferenceEquals(y, null)) return false;
                if (x.GetType() != y.GetType()) return false;
                return Equals(x.table, y.table) && x.Hp == y.Hp && x.MaxHp == y.MaxHp;
            }

            public int GetHashCode(Player obj)
            {
                unchecked
                {
                    int hashCode = (obj.table != null ? obj.table.GetHashCode() : 0);
                    hashCode = (hashCode * 397) ^ obj.Hp;
                    hashCode = (hashCode * 397) ^ obj.MaxHp;
                    return hashCode;
                }
            }
        }
    }
}