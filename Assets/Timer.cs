using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour, ITimer
{
    [SerializeField] private Image _fill;

    private Coroutine _waitingComplete;

    public event Action Completed;

    public void Begin(float seconds)
    {
        if (_waitingComplete != null)
            StopCoroutine(_waitingComplete);

           _waitingComplete = StartCoroutine(WaitingComplete(seconds));
    }

    public void Stop()
    {
        StopCoroutine(_waitingComplete);
    }

    private IEnumerator WaitingComplete(float seconds)
    {
        var elapsedTime = 0f;

        while (elapsedTime <= seconds)
        {
            elapsedTime += Time.deltaTime;
            _fill.fillAmount = elapsedTime / seconds;

            yield return null;
        }

        Complete();
    }

    private void Complete()
    {
        _fill.fillAmount = 0f;
        Completed?.Invoke();
    }
}
