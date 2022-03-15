using PixupGames.Core;
using PixupGames.Infrastracture.Game;
using PixupGames.Infrastracture.Services;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnityGameEngine : MonoBehaviour, IGameEngine
{
    [SerializeField] private int _targetFrameRate = 60;
    [SerializeField] private Viewport _viewport;
    [SerializeField] private MainCamera _camera;

    private IGame _game;

    private void Awake()
    {
        Application.targetFrameRate = _targetFrameRate;
    }

    private void Start()
    {
        _game.Run();
    }

    private void FixedUpdate()
    {
        _game.FixedTick(Time.time);
    }

    public void Init(IGame game)
    {
        _game = game;
    }

    public IViewport GetViewport() => _viewport;

    public ICamera Camera => _camera;

    public IInputDevice GetInputDevice()
    {
        var input = new MobileInputDevice();

        return input;
    }

    private void OnApplicationQuit()
    {
        _game.End();
    }
}
