namespace Test_Github.Core
{
    public static class ReactAspect
    {
        public static string ReactSpecialization(Player me, Enemy other)
        {
            return "Enemy vs Player";
        }

        public static string ReactSpecialization(Enemy me, Enemy other)
        {
            return "Enemy vs Enemy";
        }
    }
}