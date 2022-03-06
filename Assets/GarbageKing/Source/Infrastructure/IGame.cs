namespace PixupGames.Infrastracture.Game
{
    public interface IGame : IFixedUpdateLoop
    {
        void Run();
        void Save();
    }
}