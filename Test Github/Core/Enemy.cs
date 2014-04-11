namespace Test_Github.Core
{
    public class Enemy : GameObject
    {
        private string ReactSpecialization(Enemy other)
        {
            // from web again
            // from web + local
            // First branch!!!!!
            // A
            // B
            return "Enemy vs Enemy";
        }

        public override string React(IGameObject other)
        {
            return ReactSpecialization(other as dynamic);
        }
    }
}