using PixupGames.Infrastracture.Services;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace PixupGames.Infrastracture.Game
{
    public class GameEntryPoint : MonoBehaviour
    {
        [SerializeField] private int _targetFrameRate = 60;

        private GameSaves<PlayerProgress> _playerProgress;
        private InputService _inputService;

        private IBehaviorNode _gameBehaviorTree;

        private void Awake()
        {
            Application.targetFrameRate = _targetFrameRate;

            _inputService = new MobileInputService();
            _playerProgress = new GameSaves<PlayerProgress>(new PlayerProgress(10), "PlayerProgress");

            _gameBehaviorTree = new SequenceNode(new IBehaviorNode[]
            {
                new SetScreensInvisibilityNode(new IScreen[]
                {
       
                }),
                //new SetScreenVisibilityNode(),
                //new WaitStartGameButtonClick(),
                new SetScreensInvisibilityNode(new IScreen[]
                {
                    //_startScreen,
                }),
            });

        }

        private void Update()
        {
            if (_gameBehaviorTree.Status == BehaviorNodeStatus.Idle)
            {
                _gameBehaviorTree.Execute(Time.deltaTime);
            }
        }
    }
}