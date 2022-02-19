using PixupGames.UI;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace PixupGames.Infrastracture.Game
{
    public class SetScreenVisibilityNode : BehaviorNode
    {
        private readonly IScreen _screen;

        public SetScreenVisibilityNode(IScreen screen)
        {
            _screen = screen;
        }

        public override BehaviorNodeStatus OnExecute(float time)
        {
            Debug.Log("Showed");
            _screen.Show();
            return BehaviorNodeStatus.Success;
        }
    }

    public class WaitStartGameButtonClick : BehaviorNode
    {
        private readonly IGameStartButton _button;

        public WaitStartGameButtonClick(IGameStartButton button)
        {
            _button = button;
        }

        public override BehaviorNodeStatus OnExecute(float time)
        {
            return BehaviorNodeStatus.Running;
        }
    }

    public interface IGameStartButton
    {
        event Action GameStartButtonClick;
    }
}