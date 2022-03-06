using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour, ITimer
{
    [SerializeField] private Image _fill;
    [SerializeField] private CanvasGroup _canvasGroup;
    [SerializeField] private float _fadeDuration = 0.5f;

    private Coroutine _waitingComplete;
    private Tweener _fadeTweener;

    public event Action Completed;

    private void OnEnable()
    {
        _canvasGroup.alpha = 0f;
    }

    public void Begin(float seconds)
    {
        if (_waitingComplete != null)
            StopCoroutine(_waitingComplete);

        if (_fadeTweener.IsActive())
            _fadeTweener.Kill();

        _fadeTweener = _canvasGroup.DOFade(1, _fadeDuration);

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
        if (_fadeTweener.IsActive())
            _fadeTweener.Kill();

        _fadeTweener = _canvasGroup.DOFade(0, _fadeDuration);

        _fill.fillAmount = 0f;
        Completed?.Invoke();
    }
}
