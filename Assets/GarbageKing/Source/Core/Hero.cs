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

        public HandStack HandStack => _handStack;
        public GarbageBag Bag => _garbageCollector.Bag;
        public GarbageCollector GarbageCollector => _garbageCollector;
        public IMovement Movement => _movement;
        public IWallet Wallet => _wallet;
        public IHeroAnimation Animation => _animation;


        public event Action Dead;
        public event Action<IVehicle> SatVehicle;
        public event Action GotOutVehicle;

        private void Update()
        {
            _animation.PlayMovement(_movement.Velocity);
        }

        public void SitDownIn(IVehicle vehicle)
        {
            var placeOffsetY = 0.22f;
            
            transform.transform.parent = vehicle.transform;
            transform.localPosition = new Vector3(0, placeOffsetY, 0);
            transform.rotation = vehicle.transform.rotation;
            _movement.SetKinematic(true);
            _animation.PlayJetskiDrive(true);

            SatVehicle?.Invoke(vehicle);
        }

        public void ExitVehicle(Vector3 position)
        {
            transform.transform.parent = null;
            transform.position = position;
            _movement.SetKinematic(false);
            _animation.PlayJetskiDrive(false);

            GotOutVehicle?.Invoke();
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