using PixupGames.Infrastracture.Game;
using PixupGames.Infrastracture.Services;

public interface IWorld
{
    void Init(IAssetsFactory assetsFactory, IDataPersistence dataPersistence);
    ICharacter CreateCharacter();
    ICamera CreateCamera();
    void UnlockRegion(int id);
}
