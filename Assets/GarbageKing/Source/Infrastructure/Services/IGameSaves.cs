namespace PixupGames.Infrastracture.Services
{
    public interface IGameSaves<T> where T : class
    {
        T Progress();
        void Save(T save);
    }
}