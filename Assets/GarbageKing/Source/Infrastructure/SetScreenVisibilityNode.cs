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

        public override BehaviorNodeStatus OnExecute(long time)
        {
            Debug.Log("Showed");
            _screen.Show();
            return BehaviorNodeStatus.Success;
        }
    }

    public class WaitStartGameButtonClick : BehaviorNode, IDisposable
    {
        private readonly IGameStartButton _button;

        public WaitStartGameButtonClick(IGameStartButton button)
        {
            _button = button;

            _button.GameStartButtonClick += OnGameStartButtonClick;
        }

        public override BehaviorNodeStatus OnExecute(long time)
        {
            return BehaviorNodeStatus.Running;
        }

        private void OnGameStartButtonClick()
        {
            Status = BehaviorNodeStatus.Success;
        }

        public void Dispose()
        {
            _button.GameStartButtonClick -= OnGameStartButtonClick;
        }
    }

    public interface IGameStartButton
    {
        event Action GameStartButtonClick;
    }
}