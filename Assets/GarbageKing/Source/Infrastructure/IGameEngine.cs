namespace PixupGames.Infrastracture.Game
{
    public interface IViewport
    {
        IStartGameWindow GetStartGameWindow();
        IPlayGameWindow GetPlayGameWindow();
    }

    public interface IWindow
    {
        void Show();
        void Hide();
    }

    public interface IStartGameWindow : IWindow
    {
        public IButton GetStartGameButton();
    }

    public interface IPlayGameWindow : IWindow
    {

    }

    public interface IButton
    {
        void Press();
        void Release();
    }
}