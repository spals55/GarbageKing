using PixupGames.Infrastracture.Game;
using PixupGames.Infrastracture.Services;

public interface IPlayer : ICameraTarget
{
    public IWallet Wallet { get; }
    ICharacter Character { get; }

    void Init(IInputDevice inputDevice, IPlayGameWindow playWindow, IWallet wallet);
}
