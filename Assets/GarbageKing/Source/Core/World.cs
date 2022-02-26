using PixupGames.Infrastracture.Game;
using PixupGames.Infrastracture.Services;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class World : MonoBehaviour, IWorld
{
    [SerializeField] private MainCamera _camera;
    [SerializeField] private Player _player;
    [SerializeField] private List<Region> _regions;

    private IAssetsFactory _assetsFactory;
    private IDataPersistence _dataPersistence;

    public void Init(IAssetsFactory assetsFactory, IDataPersistence dataPersistence)
    {
        _assetsFactory = assetsFactory;
        _dataPersistence = dataPersistence;
    }

    public IPlayer CreatePlayer() => _player;

    public ICamera CreateCamera() => _camera;

    public void UnlockRegion(int id)
    {
        foreach (var region in _regions)
        {
            if (region.Id == id)
            {
                region.Unlock();
            }
        }
    }
}
