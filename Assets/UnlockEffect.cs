using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockEffect : MonoBehaviour
{
    [SerializeField] private ParticleSystem _unlockParticle;
    [SerializeField] private UnlockSettings _settings;

    public void Play()
    {
        var ulockParticle = Instantiate(_unlockParticle, transform.position, Quaternion.identity);
        ulockParticle.Play();

        transform.localScale = Vector3.zero;
        transform.DOScale(1, _settings.Duration).SetEase(Ease.OutBack);
    }
}
