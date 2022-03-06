using PixupGames.Contracts;
using PixupGames.Core;
using PixupGames.Infrastracture.Services;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace PixupGames.Infrastracture.Game
{
    public class Game : IGame
    {
        private readonly IDataPersistence _dataPersistence;
        private readonly IGameEngine _gameEngine;
        private readonly IViewport _viewport;
        private readonly IWorld _world;
        private readonly IPlayer _player;

        public Game(IDataPersistence dataPersistence, IWorld world, IGameEngine gameEngine)
        {
            _world = world;
            _dataPersistence = dataPersistence;
            _gameEngine = gameEngine;
            _viewport = _gameEngine.GetViewport();

            _player = new Player(_gameEngine.GetInputDevice());
        }

        public void FixedTick(float time)
        {
            _player.FixedTick(time);
        }

        public void Run()
        {
            _viewport.GetStartGameWindow().Hide();
            _viewport.GetPlayGameWindow().Show();

            Initialize();
            UnlockRegions();
        }

        public void Save() => _dataPersistence.Save();

        private void Initialize()
        {
            ICamera camera = _gameEngine.Camera;
            IHero hero = _world.CreateHero(_dataPersistence.Data.World.Hero.LastPosition);
            IWallet wallet = new Wallet(2500);

            hero.Init(wallet);
            camera.SetTarget(hero);
            _player.SetControlledHero(hero);
            _viewport.GetPlayGameWindow().Init(hero.Wallet, hero.Bag);
        }

        private void UnlockRegions()
        {
            foreach (var region in _dataPersistence.Data.World.Regions)
            {
                if (region.IsOpen)
                {
                    _world.UnlockRegion(region.GUID);
                }
            }
        }
    }
}