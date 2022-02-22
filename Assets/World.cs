using PixupGames.Infrastracture.Game;
using PixupGames.Infrastracture.Services;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class World : MonoBehaviour, IWorld
{
    [SerializeField] private MainCamera _camera;
    [SerializeField] private Character _character;
    [SerializeField] private List<Region> _regions;

    private IAssetsFactory _assetsFactory;
    private IDataPersistence _dataPersistence;

    public void Init(IAssetsFactory assetsFactory, IDataPersistence dataPersistence)
    {
        _assetsFactory = assetsFactory;
        _dataPersistence = dataPersistence;
    }

    public ICharacter CreateCharacter() => _character;

    public ICamera CreateCamera() => _camera;

    public void UnlockRegion(string regionName)
    {
        foreach (var region in _regions)
        {
            if (region.Name == regionName)
            {
                region.Unlock();
            }
        }
    }
}
