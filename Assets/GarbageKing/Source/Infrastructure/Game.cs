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
        private readonly IGameEngine _gameEngine;
        private readonly IViewport _viewport;
        private readonly IWorld _world;
        private readonly Shop _shop;

        private IPlayer _player;

        public Game(IWorld world, IGameEngine gameEngine, IViewport viewport, Shop shop)
        {
            _world = world;
            _gameEngine = gameEngine;
            _viewport = viewport;
            _shop = shop;
        }

        public void FixedTick(float time)
        {
            _player.FixedTick(time);
        }

        public void Run()
        {
            _viewport.GetPlayGameWindow().Open();
            Analytics.SendStartLevel();

            IPlayer player = SetupPlayer();
            SetupCamera(player.ControlledHero);
        }

        public void End()
        {
            _player.ControlledHeroDead -= OnHeroDead;
        }

        private IPlayer SetupPlayer()
        {
            _player = new Player(_gameEngine.GetInputDevice());

            IHero hero = _world.SpawnHero(new Vector3(9.8f, -2.39f, 24.2f));

            if (PlayerPrefs.HasKey("Money"))
                hero.Wallet.Add(PlayerPrefs.GetInt("Money"));
            else
                hero.Wallet.Add(1000);

            _shop.Init(hero);

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

        private void OnHeroDead()
        {
            _world.RespawnHero(new Vector3(9.8f, -2.39f, 24.2f));
        }
    }
}