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

        public override BehaviorNodeStatus OnExecute(long time)
        {
            Debug.Log("hide");

            foreach (var screen in _screens)
                screen.Hide();

            return BehaviorNodeStatus.Success;
        }
    }
}