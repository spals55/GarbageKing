using PixupGames.Contracts;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace PixupGames.Core
{
    [RequireComponent(typeof(HeroMovement), typeof(HeroAnimation))]
    public class Hero : MonoBehaviour, IHero
    {
        [SerializeField] private HeroMovement _movement;
        [SerializeField] private HeroAnimation _animation;
        [SerializeField] private HandStack _handStack;
        [SerializeField] private GarbageCollector _garbageCollector;
        [SerializeField] private Wallet _wallet;

        public IMovement Movement => _movement;
        public IGarbageBag Bag => _garbageCollector.Bag;
        public IWallet Wallet => _wallet;
        public IHeroAnimation Animation => _animation;


        public event Action Dead;

        private void Update()
        {
            _animation.PlayMovement(_movement.Velocity);
        }

        public void Move(Vector3 direction)
        {
            _movement.Move(direction);
        }

        public ITrashBlock GetTrashBlock()
        {
            return _handStack.Get();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out IChest chest))
            {
                chest.Open();
            }

            if (other.TryGetComponent(out IWater water))
            {
                Dead?.Invoke();
            }
        }

        private void OnTriggerStay(Collider other)
        {
            if (other.TryGetComponent(out ITrashBlockStack stack))
            {
                if (stack.CanGet && !_handStack.IsFull)
                {
                     var block = stack.Get();
                   _handStack.Add(block);
                }
            }
        }

    }
}