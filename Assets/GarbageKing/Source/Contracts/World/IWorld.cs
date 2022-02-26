using PixupGames.Infrastracture.Game;
using PixupGames.Infrastracture.Services;

public interface IWorld
{
    void Init(IAssetsFactory assetsFactory, IDataPersistence dataPersistence);
    IPlayer CreatePlayer();
    ICamera CreateCamera();
    void UnlockRegion(int id);
}
