using Microsoft.Practices.Unity;

namespace Test_Github.Core
{
    public class Team
    {
        private readonly IGameObject _member;

        [InjectionConstructor]
        public Team(IGameObject member)
        {
            _member = member;
        }

        public string MemberReact(IGameObject other)
        {
            return _member.React(other);
        }
    }
}