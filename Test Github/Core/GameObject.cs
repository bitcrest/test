using System;

namespace Test_Github.Core
{
    public abstract class GameObject : IGameObject
    {
        static GameObject()
        {
            try
            {
                var x = new Enemy();
                var y = new Unknown();
                //var y = new Player(1);
                x.React(y);
            }
            catch
            {
            }
        }

        public abstract string React(IGameObject other);

        public string ReactSpecialization(IGameObject other)
        {
            throw new Exception();
        }
    }
}