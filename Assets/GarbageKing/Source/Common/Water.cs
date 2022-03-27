using PixupGames.Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour, IWater
{
    [SerializeField] private ParticleSystem _splashEffectTemplate;

    public void PlaySplashEffect(Vector3 position)
    {
        var splashEffect = Instantiate(_splashEffectTemplate, transform.position, Quaternion.identity);
        splashEffect.transform.position = new Vector3(position.x, transform.position.y, position.z);
        splashEffect.Play();
    }
}
