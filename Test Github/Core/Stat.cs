namespace Test_Github.Core
{
    public struct Stat
    {
        public readonly int Hp; // { get; private set; }
        public readonly int MaxHp;

        public Stat(int maxHp, int hp, int mp)
            : this()
        {
            MaxHp = maxHp;
            Hp = hp;
            Mp = mp;
        }

        public int Mp { get; private set; }
    }
}