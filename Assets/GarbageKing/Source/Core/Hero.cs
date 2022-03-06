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
        [SerializeField] private HeroResourcesStack _resourcesStack;
        [SerializeField] private GarbageCollector _garbageCollector;

        public IMovement Movement => _movement;
        public IGarbageBag Bag => _garbageCollector.Bag;
        public IWallet Wallet { get; private set; }

        public void Init(IWallet wallet)
        {
            Wallet = wallet;
        }

        private void Update()
        {
            _animation.PlayMovement(_movement.Velocity);
        }

        public void Move(Vector3 direction)
        {
            _movement.Move(direction);
        }

        private void OnTriggerStay(Collider other)
        {
            if (other.TryGetComponent(out ITrashBlockStack stack))
            {
                if (stack.CanGet)
                {
                     var block = stack.Get();
                   _resourcesStack.Add(block);
                }
            }
        }
    }
}