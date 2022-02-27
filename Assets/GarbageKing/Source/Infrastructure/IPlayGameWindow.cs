namespace PixupGames.Infrastracture.Game
{
    public interface IPlayGameWindow : IWindow
    {
        void ChangeCapacity(int capacity, int maxCapacity);
        void RenderMoney(int money);
    }
}