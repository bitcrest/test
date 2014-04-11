namespace Test_Github.Core
{
    public class Unknown : GameObject
    {
        public override string React(IGameObject other)
        {
            return ReactSpecialization(other);
        }
    }
}