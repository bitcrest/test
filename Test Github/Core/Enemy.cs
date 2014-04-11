namespace Test_Github.Core
{
    public class Enemy : GameObject
    {
        public string ReactSpecialization(Enemy other)
        {
            // from web
            // from web again
            // from web + local

            return "Enemy vs Enemy";
        }

        public override string React(IGameObject other)
        {
            return ReactSpecialization(other as dynamic);
        }
    }
}
