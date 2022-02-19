using UnityEngine;

namespace PixupGames.Infrastracture.Game
{
    public class SetScreensInvisibilityNode : BehaviorNode
    {
        private readonly IScreen[] _screens;

        public SetScreensInvisibilityNode(IScreen[] screens)
        {
            _screens = screens;
        }

        public override BehaviorNodeStatus OnExecute(float time)
        {
            foreach (var screen in _screens)
                screen.Hide();

            return BehaviorNodeStatus.Success;
        }
    }
}