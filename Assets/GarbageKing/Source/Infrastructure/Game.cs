using DG.Tweening;
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

        private IPlayer _player;

        public Game(IDataPersistence dataPersistence, IWorld world, IGameEngine gameEngine, IViewport viewport)
        {
            _world = world;
            _dataPersistence = dataPersistence;
            _gameEngine = gameEngine;
            _viewport = viewport;
        }

        public void FixedTick(float time)
        {
            _player.FixedTick(time);
        }

        public void Run()
        {
            _viewport.GetStartGameWindow().Close();
            _viewport.GetPlayGameWindow().Open();

            IPlayer player = SetupPlayer();
            SetupCamera(player.ControlledHero);

            UnlockRegions();
        }

        public void End()
        {
            _player.ControlledHeroDead -= OnHeroDead;

            _dataPersistence.Save();
        }

        private IPlayer SetupPlayer()
        {
            _player = new Player(_gameEngine.GetInputDevice());

            IHero hero = _world.SpawnHero(_dataPersistence.Data.World.Hero.LastPosition);
            hero.Wallet.Add(5000);

            _player.ControlledHero = hero;
            _viewport.GetPlayGameWindow().Init(hero.Wallet, hero.Bag);

            _player.ControlledHeroDead += OnHeroDead;

            return _player;
        }

        private void SetupCamera(ICameraTarget target)
        {
            ICamera camera = _world.Camera;
            camera.SetTarget(target);
        }

        private void UnlockRegions()
        {
            foreach (var region in _dataPersistence.Data.World.Regions)
                if (region.IsOpen)
                    _world.UnlockRegion(region.GUID);
        }

        private void OnHeroDead()
        {
            _world.RespawnHero(_dataPersistence.Data.World.Hero.LastPosition);
        }
    }
}