using PixupGames.Contracts;
using PixupGames.Infrastracture.Services;

namespace PixupGames.Infrastracture.Game
{
    public interface IPlayGameWindow : IWindow
    {
        void DisableJoystick();
        void EnableJoystick();
        void Init(IWallet wallet, IGarbageBag garbageBag);
    }
}