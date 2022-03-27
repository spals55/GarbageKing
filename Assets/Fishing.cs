using PixupGames.Contracts;
using PixupGames.Infrastracture.Game;
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Fishing : MonoBehaviour
{
    [SerializeField] private Camera _fishingCamera;
    [SerializeField] private Camera _mainCamera;
    [SerializeField] private Viewport _viewport;
    [SerializeField] private FishingRod _fishingRod;
    [SerializeField] private Button _exitFishing;

    private Coroutine _playing;
    private IHero _fisherman;

    private void OnEnable()
    {
        _exitFishing.onClick.AddListener(OnExitFishing);
        _fishingRod.HookedTrash += OnHookedTrash;
    }

    private void OnDisable()
    {
        _exitFishing.onClick.AddListener(OnExitFishing);
        _fishingRod.HookedTrash -= OnHookedTrash;
    }

    public void Enter(IHero fisherman)
    {
        _fisherman = fisherman;
        _mainCamera.gameObject.SetActive(false);
        _fishingCamera.gameObject.SetActive(true);
        _viewport.GetPlayGameWindow().DisableJoystick();
        _exitFishing.gameObject.SetActive(true);

        if (_playing != null)
            StopCoroutine(_playing);

        _playing = StartCoroutine(ToFish());
    }

    private IEnumerator ToFish()
    {
        while (true)
        {
            if (Input.GetMouseButtonDown(0))
            {
                var ray = _fishingCamera.ScreenPointToRay(Input.mousePosition);

                if (Physics.Raycast(ray, out RaycastHit hit))
                {
                     _fishingRod.ThrowHook(hit.point);                  
                }        
            }

            yield return null;
        }
    }

    private void OnHookedTrash(ITrash trash)
    {
        if (_fisherman.Bag.CanAdd(trash.Weight))
        {
            _fisherman.Bag.Add(trash);
        }
        else
        {
            trash.transform.parent = transform;
            trash.transform.localPosition = Vector3.zero;
        }
    }

    private void OnExitFishing()
    {
        if (_playing != null)
            StopCoroutine(_playing);

        _exitFishing.gameObject.SetActive(false);
        _mainCamera.gameObject.SetActive(true);
        _fishingCamera.gameObject.SetActive(false);
        _viewport.GetPlayGameWindow().EnableJoystick();
    }
}
