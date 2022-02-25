namespace PixupGames.Infrastracture.Game
{
    public interface IViewport
    {
        IStartGameWindow GetStartGameWindow();
        IPlayGameWindow GetPlayGameWindow();
    }
}