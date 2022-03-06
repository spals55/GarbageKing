using DG.Tweening;
using PixupGames.Infrastracture.Services;
using System;
using System.Collections.Generic;
using Unity.Collections;
using UnityEditor;
using UnityEngine;

namespace PixupGames.Infrastracture.Game
{
    public class Region : MonoBehaviour, IRegion, IUnlockable
    {
        private const float UnlockDuration = 0.6f;

        [SerializeField] private string _guid;
        [SerializeField] private List<UnlockZone> _unlockZone;
        [SerializeField] private ParticleSystem _unlockEffect;

        private IDataPersistence _persistence;

        public string GUID => _guid;

        private void OnValidate()
        {
#if UNITY_EDITOR
            if (string.IsNullOrEmpty(_guid))
            {
                _guid = Guid.NewGuid().ToString();
                EditorUtility.SetDirty(gameObject);
            }
#endif
        }

#if UNITY_EDITOR
        [ContextMenu("Regenerate Region GUID")]
        public void RegenerateGUID()
        {
            _guid = Guid.NewGuid().ToString();
            EditorUtility.SetDirty(gameObject);
        }
#endif

        public void Init(IDataPersistence persistence)
        {
            _persistence = persistence;
        }

        public void Unlock(bool animate)
        {
            gameObject.SetActive(true);

            if (animate)
            {
                UnlockZones();
                //_unlockEffect.Play();
                transform.localScale = Vector3.zero;
                transform.DOScale(1, UnlockDuration);
            }
        }

        private void UnlockZones()
        {
            foreach (var buyZone in _unlockZone)
            {
                if(buyZone.GUID == "Lala")
                {
                    buyZone.Unlock(false);
                }
            }
        }
    }
}

