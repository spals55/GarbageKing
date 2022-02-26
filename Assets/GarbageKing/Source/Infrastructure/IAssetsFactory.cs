namespace PixupGames.Infrastracture.Game
{
    public interface IAssetsFactory
    {
        T Load<T>();
    }
}