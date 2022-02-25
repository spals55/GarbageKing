using PixupGames.Infrastracture.Services;

namespace PixupGames.Infrastracture.Game
{
    public class Game : IGame
    {
        private readonly IDataPersistence _dataPersistence;
        private readonly IGameEngine _gameEngine;
        private readonly IViewport _viewport;
        private readonly IWorld _world;
        private readonly IPlayer _player;

        public Game(IDataPersistence dataPersistence, IWorld world, IGameEngine gameEngine, IPlayer player)
        {
            _world = world;
            _player = player;
            _dataPersistence = dataPersistence;
            _gameEngine = gameEngine;
            _viewport = _gameEngine.GetViewport();
        }

        public void Run()
        {
            _viewport.GetStartGameWindow().Show();
            InitPlayer();
            CreateWorld();
            UnlockRegions();
        }

        private void CreateWorld()
        {          
            ICamera camera = _world.CreateCamera();
            camera.SetTarget(_player.ControlledCharacter);

            UnlockRegions();
        }

        private void InitPlayer()
        {
            ICharacter character = _world.CreateCharacter();
            IInputDevice inputDevice = _gameEngine.GetInputDevice();

            _player.Init(inputDevice, character);
        }

        private void UnlockRegions()
        {
            return;

            foreach (var region in _dataPersistence.Data.World.Regions)
            {
                if (region.IsOpen)
                {
                    _world.UnlockRegion(region.Id);
                }
            }
        }
    }
}