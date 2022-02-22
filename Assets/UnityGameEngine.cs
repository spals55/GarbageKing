using PixupGames.Infrastracture.Game;
using PixupGames.Infrastracture.Services;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnityGameEngine : MonoBehaviour, IGameEngine
{
    [SerializeField] private int _targetFrameRate = 60;
    [SerializeField] private Viewport _viewport;

    private IDataPersistence _dataProvider;

    private void Awake()
    {
        Application.targetFrameRate = _targetFrameRate;
    }

    public void Init(IDataPersistence dataProvider)
    {
        _dataProvider = dataProvider;
    }

    public IViewport GetViewport() => _viewport;

    public IInputDevice GetInputDevice()
    {
        var input = new MobileInputDevice();

        return input;
    }

    private void OnApplicationQuit()
    {
        _dataProvider.Save();
    }
}
